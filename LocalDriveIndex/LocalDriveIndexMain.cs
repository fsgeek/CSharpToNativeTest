using Microsoft.Win32.SafeHandles;
using Serilog;
using CommandLine;
using NativeSupportLibrary;
using NativeCalls;
using System.Diagnostics;
using System.Reflection.Metadata;

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


            UNICODE_STRING c_drive = new UNICODE_STRING("\\??\\C:\\");
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            OBJECT_ATTRIBUTES objattr = new OBJECT_ATTRIBUTES(handle, c_drive, OBJECT_ATTRIBUTES.OBJ_CASE_INSENSITIVE);
            ACCESS_MASK mask = (UInt32)(ACCESS_MASK.GENERIC_READ | ACCESS_MASK.SYNCHRONIZE);
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            FILE_ATTRIBUTES fileAttr = 0;
            SHARE_ACCESS shareAccess = SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_WRITE;
            CREATE_DISPOSITION disposition = CREATE_DISPOSITION.FILE_OPEN;
            CREATE_OPTIONS options = CREATE_OPTIONS.FILE_DIRECTORY_FILE | CREATE_OPTIONS.FILE_SYNCHRONOUS_IO_NONALERT;
            EXTENDED_ATTRIBUTE ea = new EXTENDED_ATTRIBUTE();
            NtStatusCode status = SystemCalls.NtCreateFile(ref handle, mask, objattr, ref statusBlock, (LARGE_INTEGER)0, fileAttr, shareAccess, disposition, options, ea);


            Debug.Assert(NtStatusCode.STATUS_SUCCESS == status);

            IntPtr buffer = IntPtr.Zero;
            UInt32 bufferLength = 0;

            status = SystemCalls.NtQueryDirectoryFile(handle, new EVENT(), new APC(), ref statusBlock, ref buffer, ref bufferLength, FILE_INFORMATION_CLASS.FileIdExtdBothDirectoryInformation, false, null, false);

            Debug.Assert(NtStatusCode.STATUS_SUCCESS == status, $"NtQueryDirectoryFile failed: {NtStatusToString.StatusToString(status)} ({status:X})");

            Console.WriteLine($"Received {statusBlock.Information} bytes back");

            // Now let's try to parse the data

            FILE_ID_EXTD_BOTH_DIR_INFORMATION dirInfo = new FILE_ID_EXTD_BOTH_DIR_INFORMATION();
            dirInfo.AddEntries(buffer, (UInt32) statusBlock.Information);
            

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
            status = SystemCalls.NtQueryDirectoryFile(handle, new EVENT(), new APC(), ref statusBlock, ref buffer, ref bufferLength, FILE_INFORMATION_CLASS.FileNamesInformation, true, null, true);

            Debug.Assert(NtStatusCode.STATUS_SUCCESS == status, $"NtQueryDirectoryFile failed: {NtStatusToString.StatusToString(status)} ({status:X})");

            Console.WriteLine($"Received {statusBlock.Information} bytes back (query names info)");

            FILE_NAMES_INFORMATION fileInfo = new FILE_NAMES_INFORMATION();

            bool done = false;

            while (!done)
            {
                fileInfo.AddEntries(buffer, bufferLength);

                status = SystemCalls.NtQueryDirectoryFile(handle, new EVENT(), new APC(), ref statusBlock, ref buffer, ref bufferLength, FILE_INFORMATION_CLASS.FileNamesInformation, true, null, false);

                if (NtStatusCode.STATUS_SUCCESS != status)
                {
                    done = true;
                }
            }

            Console.WriteLine($"Directory Listing (query names) has {dirInfo.Entries.Count} entries");

            foreach (var entry in fileInfo.Entries)
            {
                Console.WriteLine($"{entry.FileName}");
                UNICODE_STRING unicodeFileName = new UNICODE_STRING(entry.FileName);
                OBJECT_ATTRIBUTES fileOA = new OBJECT_ATTRIBUTES(handle, unicodeFileName, OBJECT_ATTRIBUTES.OBJ_CASE_INSENSITIVE | OBJECT_ATTRIBUTES.OBJ_DONT_REPARSE);
                SafeFileHandle fileHandle = new SafeFileHandle(IntPtr.Zero, true);
                FILE_ACCESS_MASK fileAccessMask = new FILE_ACCESS_MASK(FILE_ACCESS_MASK.SYNCHRONIZE);
                
                status = SystemCalls.NtCreateFile(ref fileHandle, fileAccessMask, fileOA, ref statusBlock, null, 0, SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_WRITE | SHARE_ACCESS.FILE_SHARE_DELETE, CREATE_DISPOSITION.FILE_OPEN, CREATE_OPTIONS.FILE_SYNCHRONOUS_IO_NONALERT, new EXTENDED_ATTRIBUTE());

                if (NtStatusCode.STATUS_SUCCESS == status)
                {
                    Console.WriteLine($"Successfully opened {entry.FileName}");
                }
                else
                {
                    Console.WriteLine($"Failed to open {entry.FileName} due to error {status.ToString()} ({status})");
                }

                status = SystemCalls.NtClose(ref fileHandle);
            }


            foreach (var entry in fileInfo.Entries)
            {
                FILE_NETWORK_OPEN_INFORMATION fileNetworkOpenInfo = new FILE_NETWORK_OPEN_INFORMATION();
                UNICODE_STRING unicodeFileName = new UNICODE_STRING(entry.FileName);
                OBJECT_ATTRIBUTES fileOA = new OBJECT_ATTRIBUTES(handle, unicodeFileName, OBJECT_ATTRIBUTES.OBJ_CASE_INSENSITIVE | OBJECT_ATTRIBUTES.OBJ_DONT_REPARSE);

                Console.WriteLine($"{entry.FileName}");

                status = SystemCalls.NtQueryFullAttributesFile(fileOA, ref fileNetworkOpenInfo);
                if (NtStatusCode.STATUS_SUCCESS != status)
                {
                    Console.WriteLine($"\tUnable to open {entry.FileName} status is {status.ToString()} ({status:X})");
                    continue;
                }

                Console.WriteLine($"\tCreationTime: {DateTime.FromFileTime(fileNetworkOpenInfo.CreationTime)}");
                Console.WriteLine($"\tLastAccessTime: {DateTime.FromFileTime(fileNetworkOpenInfo.LastAccessTime)}");
                Console.WriteLine($"\tLastWriteTime: {DateTime.FromFileTime(fileNetworkOpenInfo.LastWriteTime)}");
                Console.WriteLine($"\tChangeTime: {DateTime.FromFileTime(fileNetworkOpenInfo.ChangeTime)}");
                Console.WriteLine($"\tEndOfFile: {fileNetworkOpenInfo.EndOfFile}");
                Console.WriteLine($"\tAllocationSize: {fileNetworkOpenInfo.AllocationSize}");
                Console.WriteLine($"\tAttributes: {FILE_ATTRIBUTES.ToString(fileNetworkOpenInfo.FileAttributes)}");
            }




            SystemCalls.NtClose(ref handle);

            // Prior work has been focused on static data sets.  To make this a useful system service we need to support dynamic data collection, which
            // gives rise to the systems problem that are at the heart of my research.
            Log.Information("Test Done");
            Log.CloseAndFlush();
        }
    }
}
