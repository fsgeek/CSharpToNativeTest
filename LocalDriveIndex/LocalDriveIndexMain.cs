using Microsoft.Win32.SafeHandles;
using Serilog;
using CommandLine;
using NativeSupportLibrary;
using NativeCalls;
using System.Diagnostics;
using System.Reflection.Metadata;
using NativeTypes;
using System.Security.Cryptography;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace LocalDriveIndex
{
    class Program
    {

        public class Options
        {
            [Option(Default = (int)Serilog.Events.LogEventLevel.Information, HelpText = "Log Level")]
            public int LogLevel { get; set; }
        }

        static void RunOptions(Options opts)
        {
            int loglevel = 3;

            if (null != opts)
            {
                if ((opts.LogLevel < (int)Serilog.Events.LogEventLevel.Verbose) || (opts.LogLevel > (int)Serilog.Events.LogEventLevel.Fatal))
                {
                    Console.WriteLine($"LogLevel must be between {(int)Serilog.Events.LogEventLevel.Fatal} (Fatal messages only) and {(int)Serilog.Events.LogEventLevel.Information} ()");
                }
                loglevel = opts.LogLevel;

                switch (loglevel)
                {
                    case (int)Serilog.Events.LogEventLevel.Verbose:
                        Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose().WriteTo.Console().CreateLogger();
                        break;
                    case (int)Serilog.Events.LogEventLevel.Debug:
                        Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().CreateLogger();
                        break;
                    case (int)Serilog.Events.LogEventLevel.Information:
                        Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();
                        break;
                    case (int)Serilog.Events.LogEventLevel.Warning:
                        Log.Logger = new LoggerConfiguration().MinimumLevel.Warning().WriteTo.Console().CreateLogger();
                        break;
                    case (int)Serilog.Events.LogEventLevel.Error:
                        Log.Logger = new LoggerConfiguration().MinimumLevel.Error().WriteTo.Console().CreateLogger();
                        break;
                    default:
                        Log.Logger = new LoggerConfiguration().MinimumLevel.Fatal().WriteTo.Console().CreateLogger();
                        break;
                }
            }
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
            Console.WriteLine(errs);
            throw new InvalidProgramException("Invalid command line option");
        }

        static void GetFileInfo(string ParentDirectory, string FileName)
        {

        }

        public class FILESYSTEM_METADATA
        {

        }

        public class FILESYSTEM_VOLUME_METADATA
        {
            public FILESYSTEM_METADATA FileSystem;
            // TODO: add all the nifty volume level information here.
        }

        public class FILE_METADATA
        {
            // Reference back to the containing silo
            public FILESYSTEM_VOLUME_METADATA Volume; // reference to the volume

            // What fields do I want to expose?
            public UInt64 CreationTime;
            public UInt64 LastAccessTime;
            public UInt64 LastWriteTime;
            public UInt64 ChangeTime;
            public UInt32 FileAttributes;
            public Int64 AllocationSize;
            public Int64 EndOfFile;
            public UInt32 NumberOfLinks;
            public bool DeletePending;
            public bool Directory;
            public bool AlternateDataStream;
            public bool MetadataAttributes; // what is this?
            public bool IsRemote;
            public UInt16 NodeNumber; // is this supported by any file system? FILE_NUMA_NODE_INFORMATION
            // FILE_MEMORY_PARTITION_INFORMATION
            public Dictionary<string, byte[]> ExtendedAttributes;
            public Int64 FileId; // FILE_STAT_INFORMATION - is this one really provided?
            public UInt32 ReparseTag;
            // ACCESS_MASK EffectiveAccess - this doesn't look like a static property, it looks dynmaic
            public UInt32 LxFlags;
            public UInt32 LxUid;
            public UInt32 LxGid;
            public UInt32 LxMode;
            public UInt32 LxDeviceIdMajor;
            public UInt32 LxDeviceIdMinor;
            public UInt32 FileCaseSensitivityFlags;
            public UInt32 KnownFolderType; // FILE_KNOWN_FOLDER_TYPE

            // FILE_COMPRESSION_INFORMATION
            public bool Compressed;
            public Int64 CompressedFileSize;
            public UInt16 CompressionFormat;
            public byte CompressionUnitShift;
            public byte ChunkShift;
            public byte ClusterShift;

            public List<FILE_STREAM_INFORMATION> Streams;
            // public FILE_TRACKING_INFORMATION Tracking; - FILE_TRACKING_INFORMATION

            // FileReparsePointInformation
            // public FILE_REPARSE_POINT_INFORMATION ReparsePoint; 

            // FileHardLinkInformation

            // FileHardLinkFullIdInformation
            // FileNetworkPhysicalNameInformation

        }

        /// <summary>
        /// This function is probably mis-named: it can work on an individual file stream, but
        /// most of the time this is indistinguishable from file.
        /// 
        /// Given an open handle (with FILE_READ_DATA access) this will map the file, compute the
        /// checksum of the file, and return it.
        /// </summary>
        /// <param name="fileHandle"></param>
        static byte[] GetFileChecksum(SafeFileHandle fileHandle)
        {
            SHA512 hash = new SHA512Managed();
            FileStream fileStream = new FileStream(fileHandle, FileAccess.Read);
            MemoryMappedFile mappedFile = MemoryMappedFile.CreateFromFile(fileStream, null, 0, MemoryMappedFileAccess.Read, HandleInheritability.None, true);
            return hash.ComputeHash(mappedFile.CreateViewStream(0,0, MemoryMappedFileAccess.Read));
        }

        static byte[] GetFileChecksum(string FullPathNameToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            FILE_ACCESS_MASK fileAccessMask = new FILE_ACCESS_MASK(FILE_ACCESS_MASK.GENERIC_READ | FILE_ACCESS_MASK.SYNCHRONIZE);
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            FILE_ATTRIBUTES fileAttr = 0;
            SHARE_ACCESS shareAccess = SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_DELETE;
            CREATE_DISPOSITION disposition = CREATE_DISPOSITION.FILE_OPEN;
            CREATE_OPTIONS options = CREATE_OPTIONS.FILE_SYNCHRONOUS_IO_NONALERT | CREATE_OPTIONS.FILE_NON_DIRECTORY_FILE;
            EXTENDED_ATTRIBUTE ea = new EXTENDED_ATTRIBUTE();
            UNICODE_STRING unicodeFileName = new UNICODE_STRING(FullPathNameToFile);
            OBJECT_ATTRIBUTES objattr = new OBJECT_ATTRIBUTES(handle, unicodeFileName, OBJECT_ATTRIBUTES.OBJ_CASE_INSENSITIVE | OBJECT_ATTRIBUTES.OBJ_DONT_REPARSE);
            NtStatusCode status = SystemCalls.NtCreateFile(ref handle, fileAccessMask, objattr, ref statusBlock, (LARGE_INTEGER)0, 0, shareAccess, disposition, options, ea);

            if (!NtStatus.NT_SUCCESS(status))
            {
                return new byte[0];
            }

            byte[] hash = GetFileChecksum(handle);

            handle.Dispose();
            return hash;

        }

        static async Task Main(string[] args)
        {

            Parser.Default.ParseArguments<Options>(args).WithParsed(RunOptions).WithNotParsed(HandleParseError);

            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose).CreateLogger();
            Log.Information("Start Test");
            Log.Verbose("Verbose enabled");
            Log.Debug("Debug enabled");
            Log.Information("Information enabled");
            Log.Warning("Warning enabled");
            Log.Error("Error enabled");
            Log.Fatal("Fatal enabled");
            Log.Information("Test Starting");

            string rootDir = @"\??\C:\";

            FILE_FS_VOLUME_INFORMATION fsVolInfo = new FILE_FS_VOLUME_INFORMATION(rootDir);

            Console.WriteLine($"FsVolumeInformation for {rootDir}:");
            Console.WriteLine($"\tVolume Creation Time: {DateTime.FromFileTime(fsVolInfo.VolumeCreationTime)}");
            Console.WriteLine($"\tVolume Serial Number: {fsVolInfo.VolumeSerialNumber}");
            Console.WriteLine($"\t Volume Label Length: {fsVolInfo.VolumeLabelLength}");
            Console.WriteLine($"\t        Volume Label: {fsVolInfo.VolumeLabel}");

            FILE_FS_ATTRIBUTE_INFORMATION fsAttributeInfo = new FILE_FS_ATTRIBUTE_INFORMATION(rootDir);

            Console.WriteLine($"FsAttributeInformation for {rootDir}:");
            Console.WriteLine($"\t    FileSystemAttributes: {fsAttributeInfo.FileSystemAttributes.FileSystemAttributeFlags:X}: {fsAttributeInfo.FileSystemAttributes}");
            Console.WriteLine($"\t MaximumComponent Length: {fsAttributeInfo.MaximumComponentLength}");
            Console.WriteLine($"\t          FileSystemName: {fsAttributeInfo.FileSystemName}");

            FILE_FS_FULL_SIZE_INFORMATION_EX fsFullSizeInfoEx = new FILE_FS_FULL_SIZE_INFORMATION_EX(rootDir);
            Console.WriteLine($"FsFullSizeInformationEx for {rootDir}:");
            Console.WriteLine($"\t          ActualTotalAllocationUnits: {fsFullSizeInfoEx.ActualTotalAllocationUnits}");
            Console.WriteLine($"\t      ActualAvailableAllocationUnits: {fsFullSizeInfoEx.ActualAvailableAllocationUnits}");
            Console.WriteLine($"\tActualPoolUnavailableAllocationUnits: {fsFullSizeInfoEx.ActualPoolUnavailableAllocationUnits}");
            Console.WriteLine($"\t          CallerTotalAllocationUnits: {fsFullSizeInfoEx.CallerTotalAllocationUnits}");
            Console.WriteLine($"\t      CallerAvailableAllocationUnits: {fsFullSizeInfoEx.CallerAvailableAllocationUnits}");
            Console.WriteLine($"\tCallerPoolUnavailableAllocationUnits: {fsFullSizeInfoEx.CallerPoolUnavailableAllocationUnits}");
            Console.WriteLine($"\t                 UsedAllocationUnits: {fsFullSizeInfoEx.UsedAllocationUnits}");
            Console.WriteLine($"\t        TotalReservedAllocationUnits: {fsFullSizeInfoEx.TotalReservedAllocationUnits}");
            Console.WriteLine($"\t VolumeStorageReserveAllocationUnits: {fsFullSizeInfoEx.VolumeStorageReserveAllocationUnits}");
            Console.WriteLine($"\t   AvailableCommittedAllocationUnits: {fsFullSizeInfoEx.AvailableCommittedAllocationUnits}");
            Console.WriteLine($"\t        PoolAvailableAllocationUnits: {fsFullSizeInfoEx.PoolAvailableAllocationUnits}");
            Console.WriteLine($"\t            SectorsPerAllocationUnit: {fsFullSizeInfoEx.SectorsPerAllocationUnit}");
            Console.WriteLine($"\t                      BytesPerSector: {fsFullSizeInfoEx.BytesPerSector}");

            try
            {
                FILE_FS_METADATA_SIZE_INFORMATION fsMetadataSizeInfo = new FILE_FS_METADATA_SIZE_INFORMATION(rootDir);
                Console.WriteLine($"FsFullSizeInformationEx for {rootDir}:");
                Console.WriteLine($"\t        TotalMetadataAllocationUnits: {fsMetadataSizeInfo.TotalMetadataAllocationUnits}");
                Console.WriteLine($"\t            SectorsPerAllocationUnit: {fsMetadataSizeInfo.SectorsPerAllocationUnit}");
                Console.WriteLine($"\t                      BytesPerSector: {fsMetadataSizeInfo.BytesPerSector}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FILE_FS_METADATA_SIZE not available. Exception {ex}");
            }

            FILE_FS_SECTOR_SIZE_INFORMATION fsSectorSizeInfo = new FILE_FS_SECTOR_SIZE_INFORMATION(rootDir);
            Console.WriteLine($"FsSectorSizeInformation for {rootDir}:");
            Console.WriteLine($"\t                                LogicalBytesPerSector: {fsSectorSizeInfo.LogicalBytesPerSector}");
            Console.WriteLine($"\t                   PhysicalBytesPerSectorForAtomicity: {fsSectorSizeInfo.PhysicalBytesPerSectorForAtomicity}");
            Console.WriteLine($"\t                 PhysicalBytesPerSectorForPerformance: {fsSectorSizeInfo.PhysicalBytesPerSectorForPerformance}");
            Console.WriteLine($"\tFileSystemEffectivePhysicalBytesPerSectorForAtomicity: {fsSectorSizeInfo.FileSystemEffectivePhysicalBytesPerSectorForAtomicity}");
            Console.WriteLine($"\t                                                Flags: {fsSectorSizeInfo.Flags}");
            Console.WriteLine($"\t                             SectorsPerAllocationUnit: {fsSectorSizeInfo.SectorsPerAllocationUnit}");
            Console.WriteLine($"\t                                       BytesPerSector: {fsSectorSizeInfo.BytesPerSector}");

            FILE_FS_DEVICE_INFORMATION fsDeviceInfo = new FILE_FS_DEVICE_INFORMATION(rootDir);
            Console.WriteLine($"FsDeviceInformation for {rootDir}:");
            Console.WriteLine($"\t     DeviceType: {fsDeviceInfo.DeviceType:x}");
            Console.WriteLine($"\tCharacteristics: {fsDeviceInfo.Characteristics:X}");

            // This information seems to be correct.
            FILE_FS_SIZE_INFORMATION fsSizeInfo = new FILE_FS_SIZE_INFORMATION(rootDir);
            Console.WriteLine($"FsSizeInformation for {rootDir}:");
            Console.WriteLine($"\t    TotalAllocationUnits: {fsSizeInfo.TotalAllocationUnits}");
            Console.WriteLine($"\tAvailableAllocationUnits: {fsSizeInfo.AvailableAllocationUnits}");
            Console.WriteLine($"\tSectorsPerAllocationUnit: {fsSizeInfo.SectorsPerAllocationUnit}");
            Console.WriteLine($"\t          BytesPerSector: {fsSizeInfo.BytesPerSector}");

            FILE_ID_EXTD_BOTH_DIR_INFORMATION dirInfo = new FILE_ID_EXTD_BOTH_DIR_INFORMATION(rootDir);

            Console.WriteLine($"Directory Listing has {dirInfo.Entries.Count} entries");

            foreach (var entry in dirInfo.Entries)
            {
                Console.WriteLine($"{entry.FileName}");
                if (null != entry.ShortName && entry.ShortName.Length > 0 && entry.ShortName.Length != entry.FileName.Length)
                {
                    Console.WriteLine($"\tShortName: {entry.ShortName}");
                }
                Console.WriteLine($"\tFileIndex:{entry.FileIndex:X}");
                Console.WriteLine($"\tCreationTime: {DateTime.FromFileTime(entry.CreationTime)}");
                Console.WriteLine($"\tLastAccessTime: {DateTime.FromFileTime(entry.LastAccessTime)}");
                Console.WriteLine($"\tLastWriteTime: {DateTime.FromFileTime(entry.LastWriteTime)}");
                Console.WriteLine($"\tChangeTime: {DateTime.FromFileTime(entry.ChangeTime)}");
                Console.WriteLine($"\tEndOfFile: {entry.EndOfFile}");
                Console.WriteLine($"\tAllocationSize: {entry.AllocationSize}");
                Console.WriteLine($"\tAttributes: {FILE_ATTRIBUTES.ToString(entry.FileAttributes)}");
                if (0 != (FILE_ATTRIBUTES.REPARSE_POINT & entry.FileAttributes))
                {
                    Console.WriteLine($"\tReparsePointTag: {entry.ReparsePointTag:X}");
                }
                Console.WriteLine($"\tEaSize: {entry.EaSize}");
                Console.WriteLine($"\tFileId:{entry.FileId}");
            }

            //
            // Now let's try it with just names
            //
            FILE_NAMES_INFORMATION fileInfo = new FILE_NAMES_INFORMATION(rootDir);

            Console.WriteLine($"Directory Listing (query names) has {fileInfo.Entries.Count} entries");

            foreach (var entry in fileInfo.Entries)
            {

                FILE_NETWORK_OPEN_INFORMATION fileNetworkOpenInfo;
                FILE_INTERNAL_INFORMATION fileInternalInfo;
                FILE_STREAM_INFORMATION fileStreams;
                string fullPathName = rootDir + "\\" + entry.FileName;

                try
                {
                    fileNetworkOpenInfo = new FILE_NETWORK_OPEN_INFORMATION(fullPathName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unable to open {fullPathName} Exception {ex}");
                    continue;
                }

                Console.WriteLine($"{entry.FileName}");

                Console.WriteLine($"\tCreationTime: {DateTime.FromFileTime(fileNetworkOpenInfo.CreationTime)}");
                Console.WriteLine($"\tLastAccessTime: {DateTime.FromFileTime(fileNetworkOpenInfo.LastAccessTime)}");
                Console.WriteLine($"\tLastWriteTime: {DateTime.FromFileTime(fileNetworkOpenInfo.LastWriteTime)}");
                Console.WriteLine($"\tChangeTime: {DateTime.FromFileTime(fileNetworkOpenInfo.ChangeTime)}");
                Console.WriteLine($"\tEndOfFile: {fileNetworkOpenInfo.EndOfFile}");
                Console.WriteLine($"\tAllocationSize: {fileNetworkOpenInfo.AllocationSize}");
                Console.WriteLine($"\tAttributes: {FILE_ATTRIBUTES.ToString(fileNetworkOpenInfo.FileAttributes)}");

                if (0 == (fileNetworkOpenInfo.FileAttributes & FILE_ATTRIBUTES.DIRECTORY) && (fileNetworkOpenInfo.EndOfFile > 0))
                {

                    StringBuilder sb = new StringBuilder();
                    var hash = GetFileChecksum(fullPathName);
                    foreach (byte b in GetFileChecksum(fullPathName))
                    {
                        sb.Append(b.ToString("X2"));
                    }
                    Console.WriteLine($"\tHash (Length is {hash.Length}): {sb}");
                }

                try
                {
                    fileInternalInfo = new FILE_INTERNAL_INFORMATION(fullPathName);
                    Console.WriteLine($"\tInternalInformation: {fileInternalInfo.IndexNumber}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\tInternalInformation failed. {ex}");
                }

                try
                {
                    fileStreams = new FILE_STREAM_INFORMATION(fullPathName);
                    if (fileStreams.Entries.Count > 0)
                    {
                        Console.WriteLine($"\tStreams ({fileStreams.Entries.Count}):");

                        foreach (var stream in fileStreams.Entries)
                        {
                            Console.WriteLine($"\t\t{stream.StreamName} : {stream.StreamSize}");
                        }
                    }
                    Console.WriteLine($"Need to dump streams list here: {fileStreams.Entries.Count}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\tInternalInformation failed. {ex}");
                }

            }

            // Prior work has been focused on static data sets.  To make this a useful system service we need to support dynamic data collection, which
            // gives rise to the systems problem that are at the heart of my research.
            Log.Information("Test Done");
            Log.CloseAndFlush();
        }
    }
}
