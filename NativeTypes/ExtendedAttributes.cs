using Microsoft.Win32.SafeHandles;
using NativeCalls;
using NativeSupportLibrary;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NativeTypes
{
    public class FILE_FULL_EA_INFORMATION
    {
        public class FILE_FULL_EA_INFO
        {
            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_FULL_EA_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public byte Flags;
                [FieldOffset(5)] public byte EaNameLength;
                [FieldOffset(6)] public UInt16 EaValueLength;
            }

            private const int FullEaNameOffset = 8;

            private _FILE_FULL_EA_INFORMATION fullEaInformation;
            public byte Flags => fullEaInformation.Flags;
            public string EaName;
            public byte[] EaValue;

            public FILE_FULL_EA_INFO(IntPtr Buffer, ref int NextEntryOffset)
            {
                fullEaInformation = Marshal.PtrToStructure<_FILE_FULL_EA_INFORMATION>(Buffer);
                EaName = Marshal.PtrToStringUni(Buffer + FullEaNameOffset, (int)fullEaInformation.EaNameLength / (2));
                EaValue = new byte[fullEaInformation.EaValueLength];
                Marshal.Copy(Buffer + FullEaNameOffset + fullEaInformation.EaNameLength, EaValue, 0, fullEaInformation.EaValueLength);
                NextEntryOffset = (int)fullEaInformation.NextEntryOffset;
            }

            public Dictionary<string, byte[]> Entries;

            public FILE_FULL_EA_INFO(SafeFileHandle Handle)
            {
                Entries = new Dictionary<string, byte[]>();
            }

        }


    }

#if unsafe
    private NtStatusCode GetExtendedAttributeInformation(SafeFileHandle RootDirectory, string PathName)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            FILE_ACCESS_MASK fileAccessMask = new FILE_ACCESS_MASK(FILE_ACCESS_MASK.FILE_READ_EA | FILE_ACCESS_MASK.SYNCHRONIZE);
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            FILE_ATTRIBUTES fileAttr = 0;
            SHARE_ACCESS shareAccess = SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_WRITE | SHARE_ACCESS.FILE_SHARE_DELETE;
            CREATE_DISPOSITION disposition = CREATE_DISPOSITION.FILE_OPEN;
            CREATE_OPTIONS options = CREATE_OPTIONS.FILE_SYNCHRONOUS_IO_NONALERT;
            EXTENDED_ATTRIBUTE ea = new EXTENDED_ATTRIBUTE();
            UNICODE_STRING unicodeFileName = new UNICODE_STRING(PathName);
            OBJECT_ATTRIBUTES objattr = new OBJECT_ATTRIBUTES(RootDirectory, unicodeFileName, OBJECT_ATTRIBUTES.OBJ_CASE_INSENSITIVE | OBJECT_ATTRIBUTES.OBJ_DONT_REPARSE);

            NtStatusCode status = SystemCalls.NtCreateFile(ref handle, fileAccessMask, objattr, ref statusBlock, (LARGE_INTEGER)0, 0, shareAccess, disposition, options, ea);

            if (!NtStatus.NT_SUCCESS(status))
            {
                return status;
            }

            status = GetExtendedAttributeInformation(handle);
            handle.Dispose();
            return status;

        }

        private NtStatusCode GetExtendedAttributeInformation(SafeFileHandle FileHandle)
        {
            UInt32 bufferLength = 65536;
            NtStatusCode status = NtStatusCode.STATUS_UNSUCCESSFUL;
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();

            IntPtr buffer = Marshal.AllocHGlobal((int)bufferLength);
            Debug.Assert(IntPtr.Zero != buffer, "Allocation failed");

            while (true)
            {
                status = SystemCalls.NtQueryEaFile();
            }
        }
#endif // unsafe

}
