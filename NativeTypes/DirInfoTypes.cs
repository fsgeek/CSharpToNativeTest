using Microsoft.Win32.SafeHandles;
using NativeSupportLibrary;
using NativeCalls;
using NativeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static NativeTypes.FILE_NAMES_INFORMATION;

namespace NativeTypes
{
    public class FILE_NAMES_INFORMATION
    {
        private const UInt16 FileNameOffset = 12;
        // Note: this value is pretty arbitrary.  It might be useful to measure it at some point and pick
        // an optimal number (e.g., so it covers 90%+ of directories without reallocation?
        //
        private const int DefaultSize = 256;

        public class FILE_NAME
        {
            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_NAMES_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public UInt32 FileIndex;
                [FieldOffset(8)] public UInt32 FileNameLength;
            }

            private _FILE_NAMES_INFORMATION rawFileNameInformation;
            public UInt32 FileIndex { get { return rawFileNameInformation.FileIndex; } }
            public string? FileName { get; private set; }

            public FILE_NAME(IntPtr Buffer, ref UInt32 nextEntryOffset)
            {
                rawFileNameInformation = Marshal.PtrToStructure<_FILE_NAMES_INFORMATION>(Buffer);
                nextEntryOffset = rawFileNameInformation.NextEntryOffset;
                FileName = Marshal.PtrToStringUni(Buffer + FileNameOffset);
            }
        }

        public List<FILE_NAME> Entries = new List<FILE_NAME>(DefaultSize);

        private unsafe void AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            Debug.Assert(IntPtr.Zero != Buffer, "Invalid null buffer passed.");

            IntPtr current = Buffer;

            while (current.ToInt64() < (Buffer.ToInt64() + (int)BufferLength))
            {
                UInt32 nextEntryOffset = 0;
                Entries.Add(new FILE_NAME(current, ref nextEntryOffset));
                if (0 == nextEntryOffset)
                {
                    break; // last entry marked as zero
                }
                current = IntPtr.Add(current, (int)nextEntryOffset);
            }
        }

        public FILE_NAMES_INFORMATION(SafeFileHandle DirectoryHandle)
        {
            NtStatusCode status = GetDirectoryInformation(DirectoryHandle);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException("Unable to get names information for handle.");
            }
        }

        public FILE_NAMES_INFORMATION(string FullPathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetDirectoryInformation(handle, FullPathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(FullPathToFile, (int)status);
            }

        }

        public FILE_NAMES_INFORMATION(SafeFileHandle RootHandle, string PathToFile)
        {
            NtStatusCode status = GetDirectoryInformation(RootHandle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }

        }

        private NtStatusCode GetDirectoryInformation(SafeFileHandle RootHandle, string RelativePathName)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            FILE_ACCESS_MASK fileAccessMask = new FILE_ACCESS_MASK(FILE_ACCESS_MASK.GENERIC_READ | FILE_ACCESS_MASK.SYNCHRONIZE);
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            FILE_ATTRIBUTES fileAttr = 0;
            SHARE_ACCESS shareAccess = SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_WRITE | SHARE_ACCESS.FILE_SHARE_DELETE;
            CREATE_DISPOSITION disposition = CREATE_DISPOSITION.FILE_OPEN;
            CREATE_OPTIONS options = CREATE_OPTIONS.FILE_SYNCHRONOUS_IO_NONALERT | CREATE_OPTIONS.FILE_DIRECTORY_FILE;
            EXTENDED_ATTRIBUTE ea = new EXTENDED_ATTRIBUTE();
            UNICODE_STRING unicodeFileName = new UNICODE_STRING(RelativePathName);
            OBJECT_ATTRIBUTES objattr = new OBJECT_ATTRIBUTES(RootHandle, unicodeFileName, OBJECT_ATTRIBUTES.OBJ_CASE_INSENSITIVE | OBJECT_ATTRIBUTES.OBJ_DONT_REPARSE);
            NtStatusCode status = SystemCalls.NtCreateFile(ref handle, fileAccessMask, objattr, ref statusBlock, (LARGE_INTEGER)0, 0, shareAccess, disposition, options, ea);

            if (!NtStatus.NT_SUCCESS(status))
            {
                return status;
            }

            status = GetDirectoryInformation(handle);
            handle.Dispose();
            return status;
        }

        private NtStatusCode GetDirectoryInformation(SafeFileHandle DirectoryHandle)
        {
            NtStatusCode status = NtStatusCode.STATUS_UNSUCCESSFUL;
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            int bufferLength = 1024 * 1024; // another arbitrary choice.
            IntPtr buffer = Marshal.AllocHGlobal(bufferLength);

            Debug.Assert(IntPtr.Zero != buffer, "Allocation failed");

            while (true)
            {
                status = SystemCalls.NtQueryDirectoryFile(DirectoryHandle, new EVENT(), new APC(), ref statusBlock, ref buffer, (uint)bufferLength, FILE_INFORMATION_CLASS.FileNamesInformation, false, null, false);

                if ((status == NtStatusCode.STATUS_NO_SUCH_FILE) || (status == NtStatusCode.STATUS_NO_MORE_FILES))
                {
                    status = NtStatusCode.STATUS_SUCCESS;
                    // This indicates there are no more entries to read from this directory
                    break;
                }

                if (!NtStatus.NT_SUCCESS(status))
                {
                    break;
                }

                Debug.Assert(statusBlock.Information > 0, "Success but returned no data? How can this be?");

                AddEntries(buffer, (UInt32)statusBlock.Information);

            }

            if (buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }

            return status;
        }
    }

    public class FILE_ID_EXTD_BOTH_DIR_INFORMATION
    {
        const UInt16 ShortNameOffset = 90;
        const UInt16 FileNameOffset = 114;

        // Note: this value is pretty arbitrary.  It might be useful to measure it at some point and pick
        // an optimal number (e.g., so it covers 90%+ of directories without reallocation?
        private const int DefaultSize = 256;

        public class FILE_ID_EXTD_BOTH_DIR
        {
            const UInt16 ShortNameOffset = 90;
            const UInt16 FileNameOffset = 114;

            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_ID_EXTD_BOTH_DIR_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public UInt32 FileIndex;
                [FieldOffset(8)] public Int64 CreationTime;
                [FieldOffset(16)] public Int64 LastAccessTime;
                [FieldOffset(24)] public Int64 LastWriteTime;
                [FieldOffset(32)] public Int64 ChangeTime;
                [FieldOffset(40)] public Int64 EndOfFile;
                [FieldOffset(48)] public Int64 AllocationSize;
                [FieldOffset(56)] public UInt32 FileAttributes;
                [FieldOffset(60)] public UInt32 FileNameLength;
                [FieldOffset(64)] public UInt32 EaSize;
                [FieldOffset(68)] public UInt32 ReparsePointTag;
                [FieldOffset(72)] public _FILE_ID_128 FileId;
                [FieldOffset(88)] public UInt16 ShortNameLength;
                [FieldOffset(ShortNameOffset)] public fixed char ShortName[12];

            }

            private _FILE_ID_EXTD_BOTH_DIR_INFORMATION rawFileIdExtdBothDirInformation;
            public UInt32 FileIndex { get { return rawFileIdExtdBothDirInformation.FileIndex; } }
            public Int64 CreationTime { get { return rawFileIdExtdBothDirInformation.CreationTime; } }
            public Int64 LastAccessTime { get { return rawFileIdExtdBothDirInformation.LastAccessTime; } }
            public Int64 LastWriteTime { get { return rawFileIdExtdBothDirInformation.LastWriteTime; } }
            public Int64 ChangeTime { get { return rawFileIdExtdBothDirInformation.ChangeTime; } }
            public Int64 EndOfFile { get { return rawFileIdExtdBothDirInformation.EndOfFile; } }
            public Int64 AllocationSize { get { return rawFileIdExtdBothDirInformation.AllocationSize; } }
            public UInt32 FileAttributes {  get { return rawFileIdExtdBothDirInformation.FileAttributes; } }
            public UInt32 FileNameLength { get { return rawFileIdExtdBothDirInformation.FileNameLength; } }
            public UInt32 EaSize {  get { return rawFileIdExtdBothDirInformation.EaSize; } }
            public UInt32 ReparsePointTag {  get { return rawFileIdExtdBothDirInformation.ReparsePointTag; } }
            public readonly FILE_ID_128 FileId;
            public readonly string? FileName;
            public readonly string? ShortName;

            public FILE_ID_EXTD_BOTH_DIR(IntPtr Buffer, ref UInt32 nextEntryOffset)
            {
                rawFileIdExtdBothDirInformation = Marshal.PtrToStructure<_FILE_ID_EXTD_BOTH_DIR_INFORMATION>(Buffer);
                nextEntryOffset = rawFileIdExtdBothDirInformation.NextEntryOffset;
                FileId = new FILE_ID_128(rawFileIdExtdBothDirInformation.FileId);
                FileName = Marshal.PtrToStringUni(Buffer + FileNameOffset);
                if (rawFileIdExtdBothDirInformation.ShortNameLength > 0)
                {
                    ShortName = Marshal.PtrToStringUni(Buffer + ShortNameOffset);
                }

            }
        }

        public List<FILE_ID_EXTD_BOTH_DIR> Entries = new List<FILE_ID_EXTD_BOTH_DIR>(DefaultSize);

        private unsafe void AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            Debug.Assert(IntPtr.Zero != Buffer, "Invalid null buffer passed.");

            IntPtr current = Buffer;

            while (current.ToInt64() < (Buffer.ToInt64() + (int)BufferLength))
            {
                UInt32 nextEntryOffset = 0;
                Entries.Add(new FILE_ID_EXTD_BOTH_DIR(current, ref nextEntryOffset));
                if (0 == nextEntryOffset)
                {
                    break; // last entry marked as zero
                }
                IntPtr.Add(current, (int)nextEntryOffset);
                current = IntPtr.Add(current, (int)nextEntryOffset);
            }
        }

        public FILE_ID_EXTD_BOTH_DIR_INFORMATION(SafeFileHandle DirectoryHandle)
        {
            GetDirectoryInformation(DirectoryHandle);
        }

        public FILE_ID_EXTD_BOTH_DIR_INFORMATION(string FullPathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetDirectoryInformation(handle, FullPathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(FullPathToFile, (int)status);
            }


        }

        public FILE_ID_EXTD_BOTH_DIR_INFORMATION(SafeFileHandle RootHandle, string PathToFile)
        {
            NtStatusCode status = GetDirectoryInformation(RootHandle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }

        }

        private NtStatusCode GetDirectoryInformation(SafeFileHandle RootHandle, string RelativePathName)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            FILE_ACCESS_MASK fileAccessMask = new FILE_ACCESS_MASK(ACCESS_MASK.GENERIC_READ|FILE_ACCESS_MASK.SYNCHRONIZE);
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            FILE_ATTRIBUTES fileAttr = 0;
            SHARE_ACCESS shareAccess = SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_WRITE | SHARE_ACCESS.FILE_SHARE_DELETE;
            CREATE_DISPOSITION disposition = CREATE_DISPOSITION.FILE_OPEN;
            CREATE_OPTIONS options = CREATE_OPTIONS.FILE_SYNCHRONOUS_IO_NONALERT | CREATE_OPTIONS.FILE_DIRECTORY_FILE;
            EXTENDED_ATTRIBUTE ea = new EXTENDED_ATTRIBUTE();
            UNICODE_STRING unicodeFileName = new UNICODE_STRING(RelativePathName);
            OBJECT_ATTRIBUTES objattr = new OBJECT_ATTRIBUTES(RootHandle, unicodeFileName, OBJECT_ATTRIBUTES.OBJ_CASE_INSENSITIVE | OBJECT_ATTRIBUTES.OBJ_DONT_REPARSE);
            NtStatusCode status = SystemCalls.NtCreateFile(ref handle, fileAccessMask, objattr, ref statusBlock, (LARGE_INTEGER)0, 0, shareAccess, disposition, options, ea);

            if (!NtStatus.NT_SUCCESS(status))
            {
                return status;
            }

            status = GetDirectoryInformation(handle);
            handle.Dispose();
            return status;
        }

        private NtStatusCode GetDirectoryInformation(SafeFileHandle DirectoryHandle)
        {
            NtStatusCode status = NtStatusCode.STATUS_UNSUCCESSFUL;
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            int bufferLength = 1024 * 1024; // another arbitrary choice.
            IntPtr buffer = Marshal.AllocHGlobal(bufferLength);

            Debug.Assert(IntPtr.Zero != buffer, "Allocation failed");

            while (true)
            {
                status = SystemCalls.NtQueryDirectoryFile(DirectoryHandle, new EVENT(), new APC(), ref statusBlock, ref buffer, (uint)bufferLength, FILE_INFORMATION_CLASS.FileIdExtdBothDirectoryInformation, false, null, false);

                if ((status == NtStatusCode.STATUS_NO_SUCH_FILE) || (status == NtStatusCode.STATUS_NO_MORE_FILES))
                {
                    status = NtStatusCode.STATUS_SUCCESS;
                    // This indicates there are no more entries to read from this directory
                    break;
                }

                if (!NtStatus.NT_SUCCESS(status))
                {
                    break;
                }

                Debug.Assert(statusBlock.Information > 0, "Success but returned no data? How can this be?");

                AddEntries(buffer, (UInt32)statusBlock.Information);

            }

            if (buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }

            return status;
        }
    }
}
