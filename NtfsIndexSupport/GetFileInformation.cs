using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata;
using NativeSupportLibrary;
using NativeCalls;
using NativeTypes;


namespace NtfsIndexSupport
{
    public class GetFileInformation
    {

        private SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        FILE_NETWORK_OPEN_INFORMATION fileBasicAttributes;

        public Int64 CreationTime { get { return fileBasicAttributes.CreationTime; } }
        public Int64 LastAccessTime { get { return fileBasicAttributes.LastAccessTime; } }
        public Int64 LastWriteTime { get { return fileBasicAttributes.LastWriteTime; } }
        public Int64 ChangeTime { get { return fileBasicAttributes.ChangeTime; } }
        public Int64 FileSize { get { return fileBasicAttributes.EndOfFile; } }
        public Int64 SpaceUsed { get { return fileBasicAttributes.AllocationSize; } }

        public Int64 FileIdentifier;

        private void RetrieveFileInformation()
        {
        }

        /// <summary>
        /// This is the "here's a fully qualified path to a file" version of the constructor.
        /// 
        /// There are two variants:
        ///     - The name is a native file name in which case it looks like "\\Device\HarddiskVolume1\..." and must be opened using the native API
        ///     - The name is relative to the Win32 namespace, in which case it looks like "C:\foo..." or "\\?\C:\foo..." and the Win32 API can be used.
        /// </summary>
        /// <param name="FullPathToFile"></param>
        /// <param name="native"></param>
        public GetFileInformation(string FullPathToFile, bool native = false)
        {

        }

        /// <summary>
        /// This is the "here's a name to use relative to an existing open handle" version of the constructor.
        ///
        /// The name can be null in which case it is a reopen of the same handle.
        /// The name can be non-null in which case it is relative to the existing handle.
        ///
        /// Note that for NTFS the name could be a stream name, in which case it is relative to the file
        /// for the existing handle (streams are not relative to other streams, they are relative to
        /// the containing file).
        /// 
        /// </summary>
        /// <param name="ExistingHandle"></param>
        /// <param name="RelativePathToFile"></param>
        ///
        public GetFileInformation(Handle ExistingHandle, string? RelativePathToFile)
        {

        }

        /// <summary>
        /// This is the "here's a 64 bit file identifier relative to an existing open handle" version of the constructor.
        /// 
        /// This will use the native API to open the file relative to the file identifier.
        /// 
        /// </summary>
        /// <param name="ExistingHandle"></param>
        /// <param name="FileIdentifier"></param>
        /// 
        public GetFileInformation(Handle ExistingHandle, Int64 FileIdentifier)
        {

        }

        /// <summary>
        /// This is the "here's a 128 bit file identifier relative to an existing open handle" version of the constructor.
        /// 
        /// This is presently only supported by NTFS (object ID) or ReFS (which uses 128 bit file IDs).  At least for now
        /// I will leave this as a placeholder since I don't expect to implement it here.
        /// </summary>
        /// <param name="ExistingHandle"></param>
        /// <param name="ExtendedFileIdentifier"></param>
        public GetFileInformation(Handle ExistingHandle, byte[] ExtendedFileIdentifier)
        {

        }

        /// <summary>
        /// Given an existing file handle, use it to retrieve the information about this file.
        /// </summary>
        /// <param name="ExistingHandle"></param>
        public GetFileInformation(SafeFileHandle ExistingHandle)
        {
        }

        ~GetFileInformation()
        {
            handle.Dispose();
        }


#if false
        private void foo()
        {
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
            dirInfo.AddEntries(buffer, (UInt32)statusBlock.Information);


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
            status = SystemCalls.NtQueryDirectoryFile(handle, new EVENT(), new APC(), ref statusBlock, ref buffer, bufferLength, FILE_INFORMATION_CLASS.FileNamesInformation, true, null, true);

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

        }
    }
#endif // false
    }
}