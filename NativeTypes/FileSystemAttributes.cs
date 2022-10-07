using Microsoft.Win32.SafeHandles;
using NativeSupportLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NativeCalls;
using NativeTypes;

namespace NativeTypes
{
    public class FILE_SYSTEM_ATTRIBUTE_FLAGS
    {
        public const UInt32 FILE_CASE_SENSITIVE_SEARCH = (UInt32)0x00000001;
        public const UInt32 FILE_CASE_PRESERVED_NAMES = (UInt32)0x00000002;
        public const UInt32 FILE_UNICODE_ON_DISK = (UInt32)0x00000004;
        public const UInt32 FILE_PERSISTENT_ACLS = (UInt32)0x00000008;
        public const UInt32 FILE_FILE_COMPRESSION = (UInt32)0x00000010;
        public const UInt32 FILE_VOLUME_QUOTAS = (UInt32)0x00000020;
        public const UInt32 FILE_SUPPORTS_SPARSE_FILES = (UInt32)0x00000040;
        public const UInt32 FILE_SUPPORTS_REPARSE_POINTS = (UInt32)0x00000080;
        public const UInt32 FILE_SUPPORTS_REMOTE_STORAGE = (UInt32)0x00000100;
        public const UInt32 FILE_RETURNS_CLEANUP_RESULT_INFO = (UInt32)0x00000200;
        public const UInt32 FILE_SUPPORTS_POSIX_UNLINK_RENAME = (UInt32)0x00000400;
        public const UInt32 FILE_SUPPORTS_BYPASS_IO = (UInt32)0x00000800;
        public const UInt32 FILE_VOLUME_IS_COMPRESSED = (UInt32)0x00008000;
        public const UInt32 FILE_SUPPORTS_OBJECT_IDS = (UInt32)0x00010000;
        public const UInt32 FILE_SUPPORTS_ENCRYPTION = (UInt32)0x00020000;
        public const UInt32 FILE_NAMED_STREAMS = (UInt32)0x00040000;
        public const UInt32 FILE_READ_ONLY_VOLUME = (UInt32)0x00080000;
        public const UInt32 FILE_SEQUENTIAL_WRITE_ONCE = (UInt32)0x00100000;
        public const UInt32 FILE_SUPPORTS_TRANSACTIONS = (UInt32)0x00200000;
        public const UInt32 FILE_SUPPORTS_HARD_LINKS = (UInt32)0x00400000;
        public const UInt32 FILE_SUPPORTS_EXTENDED_ATTRIBUTES = (UInt32)0x00800000;
        public const UInt32 FILE_SUPPORTS_OPEN_BY_FILE_ID = (UInt32)0x01000000;
        public const UInt32 FILE_SUPPORTS_USN_JOURNAL = (UInt32)0x02000000;
        public const UInt32 FILE_SUPPORTS_INTEGRITY_STREAMS = (UInt32)0x04000000;
        public const UInt32 FILE_SUPPORTS_BLOCK_REFCOUNTING = (UInt32)0x08000000;
        public const UInt32 FILE_SUPPORTS_SPARSE_VDL = (UInt32)0x10000000;
        public const UInt32 FILE_DAX_VOLUME = (UInt32)0x20000000;
        public const UInt32 FILE_SUPPORTS_GHOSTING = (UInt32)0x40000000;

        private static List<UInt32> _FileSystemAttributeFlags = new List<UInt32>()
            {
            FILE_CASE_SENSITIVE_SEARCH,
            FILE_CASE_PRESERVED_NAMES, //0x00000002;
            FILE_UNICODE_ON_DISK, //0x00000004;
            FILE_PERSISTENT_ACLS, //0x00000008;
            FILE_FILE_COMPRESSION, //0x00000010;
            FILE_VOLUME_QUOTAS, //0x00000020;
            FILE_SUPPORTS_SPARSE_FILES, //0x00000040;
            FILE_SUPPORTS_REPARSE_POINTS, //0x00000080;
            FILE_SUPPORTS_REMOTE_STORAGE, //0x00000100;
            FILE_RETURNS_CLEANUP_RESULT_INFO, //0x00000200;
            FILE_SUPPORTS_POSIX_UNLINK_RENAME, //0x00000400;
            FILE_SUPPORTS_BYPASS_IO, //0x00000800;
            FILE_VOLUME_IS_COMPRESSED, //0x00008000;
            FILE_SUPPORTS_OBJECT_IDS, //0x00010000;
            FILE_SUPPORTS_ENCRYPTION, //0x00020000;
            FILE_NAMED_STREAMS, //0x00040000;
            FILE_READ_ONLY_VOLUME, //0x00080000;
            FILE_SEQUENTIAL_WRITE_ONCE, //0x00100000;
            FILE_SUPPORTS_TRANSACTIONS, //0x00200000;
            FILE_SUPPORTS_HARD_LINKS, //0x00400000;
            FILE_SUPPORTS_EXTENDED_ATTRIBUTES, //0x00800000;
            FILE_SUPPORTS_OPEN_BY_FILE_ID, //0x01000000;
            FILE_SUPPORTS_USN_JOURNAL, //0x02000000;
            FILE_SUPPORTS_INTEGRITY_STREAMS, //0x04000000;
            FILE_SUPPORTS_BLOCK_REFCOUNTING, //0x08000000;
            FILE_SUPPORTS_SPARSE_VDL, //0x10000000;
            FILE_DAX_VOLUME, //0x20000000;
            FILE_SUPPORTS_GHOSTING, //0x40000000;
            };

        public static string TestFlagValue(UInt32 Flags, UInt32 FlagToTest)
        {
            if ((Flags & FlagToTest) != 0)
            {
                switch (FlagToTest)
                {
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_CASE_SENSITIVE_SEARCH: //0x00000001;
                        return "FILE_CASE_SENSITIVE_SEARCH";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_CASE_PRESERVED_NAMES: //0x00000002;
                        return "FILE_CASE_PRESERVED_NAMES";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_UNICODE_ON_DISK: //0x00000004;
                        return "FILE_UNICODE_ON_DISK";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_PERSISTENT_ACLS: //0x00000008;
                        return "FILE_PERSISTENT_ACLS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_FILE_COMPRESSION: //0x00000010;
                        return "FILE_FILE_COMPRESSION";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_VOLUME_QUOTAS: //0x00000020;
                        return "FILE_VOLUME_QUOTAS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_SPARSE_FILES: //0x00000040;
                        return "FILE_SUPPORTS_SPARSE_FILES";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_REPARSE_POINTS: //0x00000080;
                        return "FILE_SUPPORTS_REPARSE_POINTS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_REMOTE_STORAGE: //0x00000100;
                        return "FILE_CASE_SENSITIVE_SEARCH";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_RETURNS_CLEANUP_RESULT_INFO: //0x00000200;
                        return "FILE_RETURNS_CLEANUP_RESULT_INFO";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_POSIX_UNLINK_RENAME: //0x00000400;
                        return "FILE_SUPPORTS_POSIX_UNLINK_RENAME";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_BYPASS_IO: //0x00000800;
                        return "FILE_SUPPORTS_BYPASS_IO";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_VOLUME_IS_COMPRESSED: //0x00008000;
                        return "FILE_VOLUME_IS_COMPRESSED";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_OBJECT_IDS: //0x00010000;
                        return "FILE_SUPPORTS_OBJECT_IDS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_ENCRYPTION: //0x00020000;
                        return "FILE_SUPPORTS_ENCRYPTION";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_NAMED_STREAMS: //0x00040000;
                        return "FILE_NAMED_STREAMS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_READ_ONLY_VOLUME: //0x00080000;
                        return "FILE_READ_ONLY_VOLUME";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SEQUENTIAL_WRITE_ONCE: //0x00100000;
                        return "FILE_SEQUENTIAL_WRITE_ONCE";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_TRANSACTIONS: //0x00200000;
                        return "FILE_SUPPORTS_TRANSACTIONS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_HARD_LINKS: //0x00400000;
                        return "FILE_SUPPORTS_HARD_LINKS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_EXTENDED_ATTRIBUTES: //0x00800000;
                        return "FILE_SUPPORTS_EXTENDED_ATTRIBUTES";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_OPEN_BY_FILE_ID: //0x01000000;
                        return "FILE_SUPPORTS_OPEN_BY_FILE_ID";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_USN_JOURNAL: //0x02000000;
                        return "FILE_SUPPORTS_USN_JOURNAL";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_INTEGRITY_STREAMS: //0x04000000;
                        return "FILE_SUPPORTS_INTEGRITY_STREAMS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_BLOCK_REFCOUNTING: //0x08000000;
                        return "FILE_SUPPORTS_BLOCK_REFCOUNTING";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_SPARSE_VDL: //0x10000000;
                        return "FILE_SUPPORTS_SPARSE_VDL";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_DAX_VOLUME: //0x20000000;
                        return "FILE_DAX_VOLUME";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_GHOSTING: //0x40000000;
                        return "FILE_SUPPORTS_GHOSTING";
                }
            }

            throw new InvalidDataException("Invalid flag passed");

        }
        public static string ExtractFileSystemAttributeFlags(UInt32 Flags)
        {
            string flags = "";
            bool firstFlag = true;

            // find the first one
            foreach (var Flag in _FileSystemAttributeFlags)
            {
                if ((Flags & Flag) != 0)
                {
                    if (!firstFlag)
                    {
                        flags += "|";
                    }
                    flags += TestFlagValue(Flags, Flag);
                    firstFlag = false;
                }
            }

            return flags;

        }
    }

    public class FILE_FS_VOLUME_INFORMATION
    {
        /*
         * typedef struct _FILE_FS_VOLUME_INFORMATION {
    LARGE_INTEGER VolumeCreationTime;
    ULONG VolumeSerialNumber;
    ULONG VolumeLabelLength;
    BOOLEAN SupportsObjects;
    WCHAR VolumeLabel[1];
} FILE_FS_VOLUME_INFORMATION, *PFILE_FS_VOLUME_INFORMATION;

        */
        private const int VolumeLabelOffset = 18;

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_FS_VOLUME_INFORMATION
        {
            [FieldOffset(0)] public Int64 VolumeCreationTime;
            [FieldOffset(8)] public UInt32 VolumeSerialNumber;
            [FieldOffset(12)] public UInt32 VolumeLabelLength;
            [FieldOffset(16)] public byte SupportsObjects;       
        }

        private _FILE_FS_VOLUME_INFORMATION nativeFsVolumeInformation;

        public string? VolumeLabel { get; private set; }
        public Int64 VolumeCreationTime { get { return nativeFsVolumeInformation.VolumeCreationTime; } }
        public UInt32 VolumeSerialNumber { get { return nativeFsVolumeInformation.VolumeSerialNumber; } }
        public UInt32 VolumeLabelLength { get { return nativeFsVolumeInformation.VolumeLabelLength; } }
        public bool SupportsObjects {  get { return (0 == nativeFsVolumeInformation.SupportsObjects) ? false : true; } }

        public FILE_FS_VOLUME_INFORMATION(SafeFileHandle Handle)
        {
            NtStatusCode status = GetFsInformation(Handle);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException("Unable to get names information for handle.");
            }
        }

        public FILE_FS_VOLUME_INFORMATION(SafeFileHandle Handle, string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFsInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }

        }

        public FILE_FS_VOLUME_INFORMATION(string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFsInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }

        }

        private NtStatusCode GetFsInformation(SafeFileHandle RootHandle, string RelativePathName)
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

            status = GetFsInformation(handle);

            handle.Dispose();
            return status;

        }


        private NtStatusCode GetFsInformation(SafeFileHandle Handle)
        {
            NtStatusCode status = NtStatusCode.STATUS_UNSUCCESSFUL;
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            int bufferLength = 4096;
            IntPtr buffer = Marshal.AllocHGlobal(bufferLength);

            Debug.Assert(IntPtr.Zero != buffer, "Allocation failed");

            while (true)
            {
                status = SystemCalls.NtQueryVolumeInformationFile(Handle, ref statusBlock, buffer, (uint) bufferLength, FS_INFORMATION_CLASS.FileFsVolumeInformation);

                if (!NtStatus.NT_SUCCESS(status))
                {
                    Console.WriteLine($"NtQueryVolumeInformationFile failed for FileFsVolumeInformation {NtStatusToString.StatusToString(status)} ({status:X})");
                    break;
                }

                unsafe
                {
                    nativeFsVolumeInformation = Marshal.PtrToStructure<_FILE_FS_VOLUME_INFORMATION>(buffer);
                    VolumeLabel = Marshal.PtrToStringUni(buffer + VolumeLabelOffset, (int) nativeFsVolumeInformation.VolumeLabelLength / 2);
                }

                break;
            }


            if (buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }

            return status;
        }

    }

    public class FILE_FS_ATTRIBUTE_INFORMATION
    {
        public UInt32 FileSystemAttributes;
        public Int32 MaximumComponentNameLength;
        public string FileSystemName;

        public static FILE_FS_ATTRIBUTE_INFORMATION GetFsAttributeInformation(SafeFileHandle Handle)
        {
            // Check file system characteristics
            FILE_FS_ATTRIBUTE_INFORMATION fsAttrInfo = new FILE_FS_ATTRIBUTE_INFORMATION();
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
#if false
            // TODO: fix this so it worksNtStatusCode status = SystemCalls.NtQueryVolumeInformationFile(Handle, ref statusBlock, ref fsAttrInfo);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException($"NtQueryVolumeInformationFile failed, status {status} ({status:X}) = {NtStatusToString.StatusToString(status)}");
            }
#endif // false

            return fsAttrInfo;

        }

        private FILE_FS_ATTRIBUTE_INFORMATION()
        {
            FileSystemAttributes = 0;
            MaximumComponentNameLength = 0;
            FileSystemName = "Unknown";
        }
    }

}
