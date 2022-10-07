using Microsoft.Win32.SafeHandles;
using NativeSupportLibrary;
using System.Diagnostics;
using System.Runtime.InteropServices;
using NativeCalls;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Data;

namespace NativeTypes
{
    public class FILE_BASIC_INFORMATION
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_BASIC_INFORMATION
        {
            [FieldOffset(0)] public Int64 CreationTime;
            [FieldOffset(8)] public Int64 LastAccessTime;
            [FieldOffset(16)] public Int64 LastWriteTime;
            [FieldOffset(24)] public Int64 ChangeTime;
            [FieldOffset(32)] public UInt32 FileAttributes;

        }

        private _FILE_BASIC_INFORMATION nativeBasicInformationBlock;

        public Int64 CreationTime { get { return nativeBasicInformationBlock.CreationTime; } }
        public Int64 LastAccessTime { get { return nativeBasicInformationBlock.LastAccessTime; } }
        public Int64 LastWriteTime {  get { return nativeBasicInformationBlock.LastWriteTime; } }
        public Int64 ChangeTime { get {return nativeBasicInformationBlock.ChangeTime; } }
        public UInt32 FileAttributes { get { return nativeBasicInformationBlock.FileAttributes; } }

        public FILE_BASIC_INFORMATION(SafeFileHandle Handle)
        {
            GetFileInformation(Handle);
        }

        public FILE_BASIC_INFORMATION(SafeFileHandle Handle, string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFileInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }
        }

        public FILE_BASIC_INFORMATION(string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFileInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }
        }

        private NtStatusCode GetFileInformation(SafeFileHandle RootHandle, string RelativePathName)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            FILE_ACCESS_MASK fileAccessMask = new FILE_ACCESS_MASK(FILE_ACCESS_MASK.FILE_READ_ATTRIBUTES | FILE_ACCESS_MASK.SYNCHRONIZE);
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

            status = GetFileInformation(handle);

            handle.Dispose();
            return status;
        }

        private NtStatusCode GetFileInformation(SafeFileHandle FileHandle)
        {
            NtStatusCode status = NtStatusCode.STATUS_UNSUCCESSFUL;
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            uint bufferLength = 65536; // big enough for most anything hopefully.
            IntPtr buffer = Marshal.AllocHGlobal((int) bufferLength);

            Debug.Assert(IntPtr.Zero != buffer, "Allocation failed");

            while (true)
            {
                status = SystemCalls.NtQueryInformationFile(FileHandle, ref statusBlock, buffer, bufferLength, FILE_INFORMATION_CLASS.FileBasicInformation);


                if (!NtStatus.NT_SUCCESS(status))
                {
                    Console.WriteLine($"NtQueryInformationFile failed for FileBasicInformation {NtStatusToString.StatusToString(status)} ({status:X})");
                    break;
                }

                nativeBasicInformationBlock = Marshal.PtrToStructure<_FILE_BASIC_INFORMATION>(buffer);
            }


            if (buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }

            return status;

        }
    }

    public class FILE_STANDARD_INFORMATION
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_STANDARD_INFORMATION
        {
            [FieldOffset(0)] public Int64 AllocationSize;
            [FieldOffset(8)] public Int64 EndOfFile;
            [FieldOffset(16)] public UInt32 NumberOfLinks;
            [FieldOffset(24)] public bool DeletePending;
            [FieldOffset(25)] public bool Directory;
        }

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_STANDARD_INFORMATION_EX
        {
            [FieldOffset(0)] public Int64 AllocationSize;
            [FieldOffset(8)] public Int64 EndOfFile;
            [FieldOffset(16)] public UInt32 NumberOfLinks;
            [FieldOffset(24)] public bool DeletePending;
            [FieldOffset(25)] public bool Directory;
            [FieldOffset(26)] public bool AlternateStream;
            [FieldOffset(27)] public bool MetadataAttribute;
        }

        private _FILE_STANDARD_INFORMATION nativeStandardInformation;
        private _FILE_STANDARD_INFORMATION_EX nativeStandardInformationEx;
        private bool ExtendedInformation = false;
        private IntPtr buffer = IntPtr.Zero;

        public Int64 AllocationSize {  get {  return ExtendedInformation ? nativeStandardInformationEx.AllocationSize : nativeStandardInformation.AllocationSize; } }
        public Int64 EndOfFile { get { return ExtendedInformation ? nativeStandardInformationEx.EndOfFile : nativeStandardInformation.EndOfFile; } }
        public UInt32 NumberOfLinks { get { return ExtendedInformation ? nativeStandardInformationEx.NumberOfLinks : nativeStandardInformation.NumberOfLinks; } }
        public bool DeletePending { get { return ExtendedInformation ? nativeStandardInformationEx.DeletePending : nativeStandardInformation.DeletePending; } }
        public bool Directory { get { return ExtendedInformation ? nativeStandardInformationEx.Directory : nativeStandardInformation.Directory; } }
        public bool AlternateStream { get { if (!ExtendedInformation) { throw new IOException("No Extended Information Available"); } return nativeStandardInformationEx.AlternateStream; } }
        public bool MetadataAttribute { get { if (!ExtendedInformation) { throw new IOException("No Extended Information Available"); } return nativeStandardInformationEx.MetadataAttribute; } }

        public FILE_STANDARD_INFORMATION(SafeFileHandle Handle)
        {
            GetFileInformation(Handle);
        }

        public FILE_STANDARD_INFORMATION(SafeFileHandle Handle, string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFileInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }
        }

        public FILE_STANDARD_INFORMATION(string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFileInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }
        }

        private NtStatusCode GetFileInformation(SafeFileHandle RootHandle, string RelativePathName)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            FILE_ACCESS_MASK fileAccessMask = new FILE_ACCESS_MASK(FILE_ACCESS_MASK.FILE_READ_ATTRIBUTES | FILE_ACCESS_MASK.SYNCHRONIZE);
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

            status = GetFileInformation(handle);

            handle.Dispose();
            return status;
        }

        private NtStatusCode GetFileInformation(SafeFileHandle FileHandle)
        {
            NtStatusCode status = NtStatusCode.STATUS_UNSUCCESSFUL;
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            uint bufferLength = 4096; // big enough for most anything hopefully.
            IntPtr buffer = Marshal.AllocHGlobal((int)bufferLength);

            Debug.Assert(IntPtr.Zero != buffer, "Allocation failed");

            while (true)
            {
                status = SystemCalls.NtQueryInformationFile(FileHandle, ref statusBlock, buffer, bufferLength, FILE_INFORMATION_CLASS.FileStandardInformation);


                if (!NtStatus.NT_SUCCESS(status))
                {
                    Console.WriteLine($"NtQueryInformationFile failed for FileBasicInformation {NtStatusToString.StatusToString(status)} ({status:X})");
                    break;
                }

                unsafe
                {
                    if (statusBlock.Information > (ulong)sizeof(_FILE_STANDARD_INFORMATION))
                    {
                        Debug.Assert(statusBlock.Information == (ulong)sizeof(_FILE_STANDARD_INFORMATION_EX), $"Unexpected return size {sizeof(_FILE_STANDARD_INFORMATION_EX)}");
                        nativeStandardInformationEx = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION_EX>(buffer);
                    }
                    else
                    {
                        nativeStandardInformation = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION>(buffer);
                    }
                }
            }


            if (buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }

            return status;

        }

    }

    public class FILE_INTERNAL_INFORMATION
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_INTERNAL_INFORMATION
        {
            [FieldOffset(0)] public Int64 IndexNumber;
        }

        private _FILE_INTERNAL_INFORMATION nativeInternalInformation;
        public const int MinimumBufferSize = 8;
        public Int64 IndexNumber => nativeInternalInformation.IndexNumber;

        public FILE_INTERNAL_INFORMATION(IntPtr Buffer)
        {
            nativeInternalInformation = Marshal.PtrToStructure<_FILE_INTERNAL_INFORMATION>(Buffer);
        }


        public FILE_INTERNAL_INFORMATION(string FullPathToFile)
        {
            SafeFileHandle RootHandle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetInternalInformation(RootHandle, FullPathToFile);
            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(FullPathToFile, (int)status);
            }
        }

        public FILE_INTERNAL_INFORMATION(SafeFileHandle RootHandle, string PathToFile)      
        {
            NtStatusCode status = GetInternalInformation(RootHandle, PathToFile);
            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }
        }

        private NtStatusCode GetInternalInformation(SafeFileHandle RootHandle, string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            FILE_ACCESS_MASK fileAccessMask = new FILE_ACCESS_MASK(FILE_ACCESS_MASK.SYNCHRONIZE);
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            FILE_ATTRIBUTES fileAttr = 0;
            SHARE_ACCESS shareAccess = SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_WRITE | SHARE_ACCESS.FILE_SHARE_DELETE;
            CREATE_DISPOSITION disposition = CREATE_DISPOSITION.FILE_OPEN;
            CREATE_OPTIONS options = CREATE_OPTIONS.FILE_SYNCHRONOUS_IO_NONALERT;
            EXTENDED_ATTRIBUTE ea = new EXTENDED_ATTRIBUTE();
            UNICODE_STRING unicodeFileName = new UNICODE_STRING(PathToFile);
            OBJECT_ATTRIBUTES objattr = new OBJECT_ATTRIBUTES(RootHandle, unicodeFileName, OBJECT_ATTRIBUTES.OBJ_CASE_INSENSITIVE | OBJECT_ATTRIBUTES.OBJ_DONT_REPARSE);
            NtStatusCode status = SystemCalls.NtCreateFile(ref handle, fileAccessMask, objattr, ref statusBlock, (LARGE_INTEGER)0, 0, shareAccess, disposition, options, ea);

            if (!NtStatus.NT_SUCCESS(status))
            {
                Console.WriteLine($"CreateFile failed for GetInternalInformation: {NtStatusToString.StatusToString(status)} ({status:X})");
                return status;
            }

            UInt32 bufferLength = (UInt32)Marshal.SizeOf<_FILE_INTERNAL_INFORMATION>();
            IntPtr buffer = IntPtr.Zero;

            try
            {
                buffer = Marshal.AllocHGlobal((int)bufferLength);
                status = SystemCalls.NtQueryInformationFile(handle, ref statusBlock, buffer, bufferLength, FILE_INFORMATION_CLASS.FileInternalInformation);

                if (!NtStatus.NT_SUCCESS(status))
                {
                    Console.WriteLine($"NtQueryInformationFile failed for FileInternalInformation {NtStatusToString.StatusToString(status)} ({status:X})");
                    throw new IOException(PathToFile, (int)status);
                }

                nativeInternalInformation = Marshal.PtrToStructure<_FILE_INTERNAL_INFORMATION>(buffer);
            }
            finally
            {

                if (IntPtr.Zero != buffer) 
                {
                    Marshal.FreeHGlobal(buffer);
                    buffer = IntPtr.Zero;
                }
                handle.Dispose();
            }
            return status;
        }

    }

    public class FILE_ID_INFORMATION
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_ID_INFORMATION
        {
            [FieldOffset(0)] UInt64 VolumeSerialNumber;
            [FieldOffset(8)] fixed byte FileId[16];
        }

        private _FILE_ID_INFORMATION nativeIdInformation;
        public const int MinimumBufferSize = 24;
        public UInt64 VolumeSerialNumber => VolumeSerialNumber;
        public FILE_ID_128 FileId;

        FILE_ID_INFORMATION(IntPtr Buffer)
        {
            nativeIdInformation = Marshal.PtrToStructure<_FILE_ID_INFORMATION>(Buffer);
            FileId = new FILE_ID_128(Buffer + 8);
        }
    }


    public class FILE_NETWORK_OPEN_INFORMATION
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_NETWORK_OPEN_INFORMATION
        {
            [FieldOffset(0)] public Int64 CreationTime;
            [FieldOffset(8)] public Int64 LastAccessTime;
            [FieldOffset(16)] public Int64 LastWriteTime;
            [FieldOffset(24)] public Int64 ChangeTime;
            [FieldOffset(32)] public Int64 AllocationSize;
            [FieldOffset(40)] public Int64 EndOfFile;
            [FieldOffset(48)] public UInt32 FileAttributes;

            public _FILE_NETWORK_OPEN_INFORMATION()
            {
                CreationTime = 0;
                LastAccessTime = 0;
                LastWriteTime = 0;
                ChangeTime = 0;
                AllocationSize = 0;
                EndOfFile = 0;
                FileAttributes = 0;
            }
        }

        private _FILE_NETWORK_OPEN_INFORMATION nativeOpenInfo;
        public const int MinimumBufferSize = 52; // sizeof (nativeOpenInfo)
        public Int64 CreationTime { get { return nativeOpenInfo.CreationTime; } }
        public Int64 LastAccessTime { get { return nativeOpenInfo.LastAccessTime; } }
        public Int64 LastWriteTime { get { return nativeOpenInfo.LastWriteTime; } }
        public Int64 ChangeTime { get { return nativeOpenInfo.ChangeTime; } }
        public Int64 AllocationSize { get { return nativeOpenInfo.AllocationSize; } }
        public Int64 EndOfFile { get { return nativeOpenInfo.EndOfFile; } }
        public FILE_ATTRIBUTES FileAttributes { get; private set; }

        public FILE_NETWORK_OPEN_INFORMATION(string FullPathToFile)
        {
            SafeFileHandle RootHandle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetNetworkOpenInformation(RootHandle, FullPathToFile);
            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(FullPathToFile, (int)status);
            }
        }

        public FILE_NETWORK_OPEN_INFORMATION(SafeFileHandle RootHandle, string PathToFile)
        {
            NtStatusCode status = GetNetworkOpenInformation(RootHandle, PathToFile);
            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }
        }

        private NtStatusCode GetNetworkOpenInformation(SafeFileHandle RootHandle, string PathToFile)
        {
            UNICODE_STRING unicodeFileName = new UNICODE_STRING(PathToFile);
            OBJECT_ATTRIBUTES fileOA = new OBJECT_ATTRIBUTES(RootHandle, unicodeFileName, OBJECT_ATTRIBUTES.OBJ_CASE_INSENSITIVE | OBJECT_ATTRIBUTES.OBJ_DONT_REPARSE);
            UInt32 bufferLength = (UInt32)Marshal.SizeOf<_FILE_NETWORK_OPEN_INFORMATION>();
            IntPtr buffer = Marshal.AllocHGlobal((int)bufferLength);

            NtStatusCode status = SystemCalls.NtQueryFullAttributesFile(fileOA, buffer, bufferLength);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }

            nativeOpenInfo = Marshal.PtrToStructure<_FILE_NETWORK_OPEN_INFORMATION>(buffer);
            FileAttributes = new FILE_ATTRIBUTES(nativeOpenInfo.FileAttributes);

            Marshal.FreeHGlobal(buffer);
            buffer = IntPtr.Zero;
            return status;
        }

    }

    public class FILE_STREAM_INFORMATION
    {
        public class FILE_STREAM_INFO
        {
            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_STREAM_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public UInt32 StreamNameLength;
                [FieldOffset(8)] public Int64 StreamSize;
                [FieldOffset(16)] public Int64 StreamAllocationSize;
            }

            private const int StreamNameOffset = 24;
            private _FILE_STREAM_INFORMATION nativeStreamInformation;
            public Int64 StreamSize => nativeStreamInformation.StreamSize;
            public Int64 StreamAllocationSize => nativeStreamInformation.StreamAllocationSize;
            public string StreamName;

            public FILE_STREAM_INFO(IntPtr Buffer, ref int NextEntryOffset)
            {
                nativeStreamInformation = Marshal.PtrToStructure<_FILE_STREAM_INFORMATION>(Buffer);
                StreamName = Marshal.PtrToStringUni(Buffer + StreamNameOffset, (int)(nativeStreamInformation.StreamNameLength / 2));
                NextEntryOffset = (int)nativeStreamInformation.NextEntryOffset;
            }

        }

        public List<FILE_STREAM_INFO> Entries = new List<FILE_STREAM_INFO>(16);

        public uint AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            uint count = 0;

            if (IntPtr.Zero != Buffer)
            {
                IntPtr current = Buffer;

                while (current.ToInt64() < (Buffer.ToInt64() + BufferLength))
                {
                    int nextOffset = 0;
                    Entries.Add(new FILE_STREAM_INFO(current, ref nextOffset));
                    count++;

                    if (0 == nextOffset)
                    {
                        break;
                    }
                    current = current + nextOffset;
                }
            }

            return count;
        }

        public FILE_STREAM_INFORMATION(string FullPath)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetStreamInformation(handle, FullPath);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(FullPath, (int)status);
            }

        }

        public FILE_STREAM_INFORMATION(SafeFileHandle RootDirectory, string RelativePath)
        {
            NtStatusCode status = GetStreamInformation(RootDirectory, RelativePath);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(RelativePath, (int)status);
            }

        }

        public FILE_STREAM_INFORMATION(SafeFileHandle FileHandle)
        {
            NtStatusCode status = GetStreamInformation(FileHandle);
            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException($"GetStreamInformation failed {NtStatusToString.StatusToString(status)} {status:X}");
            }
        }

        private NtStatusCode GetStreamInformation(SafeFileHandle RootDirectory, string RelativePathName)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            FILE_ACCESS_MASK fileAccessMask = new FILE_ACCESS_MASK(FILE_ACCESS_MASK.SYNCHRONIZE);
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            FILE_ATTRIBUTES fileAttr = 0;
            SHARE_ACCESS shareAccess = SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_WRITE | SHARE_ACCESS.FILE_SHARE_DELETE;
            CREATE_DISPOSITION disposition = CREATE_DISPOSITION.FILE_OPEN;
            CREATE_OPTIONS options = CREATE_OPTIONS.FILE_SYNCHRONOUS_IO_NONALERT;
            EXTENDED_ATTRIBUTE ea = new EXTENDED_ATTRIBUTE();
            UNICODE_STRING unicodeFileName = new UNICODE_STRING(RelativePathName);
            OBJECT_ATTRIBUTES objattr = new OBJECT_ATTRIBUTES(RootDirectory, unicodeFileName, OBJECT_ATTRIBUTES.OBJ_CASE_INSENSITIVE | OBJECT_ATTRIBUTES.OBJ_DONT_REPARSE);
            NtStatusCode status = SystemCalls.NtCreateFile(ref handle, fileAccessMask, objattr, ref statusBlock, (LARGE_INTEGER)0, 0, shareAccess, disposition, options, ea);

            if (!NtStatus.NT_SUCCESS(status))
            {
                return status;
            }

            status = GetStreamInformation(handle);
            handle.Dispose();
            return status;

        }

        private NtStatusCode GetStreamInformation(SafeFileHandle FileHandle)
        {
            UInt32 bufferLength = 4096;
            NtStatusCode status = NtStatusCode.STATUS_BUFFER_OVERFLOW;
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();

            IntPtr buffer = IntPtr.Zero;
            while (NtStatusCode.STATUS_BUFFER_OVERFLOW == status)
            {
                bufferLength *= 2;

                if (IntPtr.Zero == buffer)
                {
                    Marshal.FreeHGlobal(buffer);
                    buffer = IntPtr.Zero;
                }
                buffer = Marshal.AllocHGlobal((int)bufferLength);
                Debug.Assert(IntPtr.Zero != buffer, "Allocation failed");

                status = SystemCalls.NtQueryInformationFile(FileHandle, ref statusBlock, buffer, bufferLength, FILE_INFORMATION_CLASS.FileStreamInformation);

            }

            if (NtStatus.NT_SUCCESS(status))
            {
                AddEntries(buffer, (uint)statusBlock.Information);
            }

            if (IntPtr.Zero != buffer)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }
            return status;
        }
    }

}