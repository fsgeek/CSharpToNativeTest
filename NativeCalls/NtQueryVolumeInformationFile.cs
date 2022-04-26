using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;


namespace NativeCalls
{
    public partial class SystemCalls
    {
        public enum FS_INFORMATION_CLASS
        {
            FileFsVolumeInformation = 1,
            FileFsLabelInformation,
            FileFsSizeInformation,
            FileFsDeviceInformation,
            FileFsAttributeInformation,
            FileFsControlInformation,
            FileFsFullSizeInformation,
            FileFsObjectIdInformation,
            FileFsDriverPathInformation,
            FileFsVolumeFlagsInformation,
            FileFsSectorSizeInformation,
            FileFsDataCopyInformation,
            FileFsMetadataSizeInformation,
            FileFsFullSizeInformationEx,
            FileFsMaximumInformation
        }

        public struct FILE_FS_VOLUME_INFORMATION
        {
            public UInt64 VolumeCreationTime;
            public UInt32 VolumeSerialNumber;
            public bool SupportsObjects;
            public string VolumeLabel;

        }

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _FILE_FS_VOLUME_INFORMATION
        {
            [FieldOffset(0)] public UInt64 VolumeCreationTime;
            [FieldOffset(8)] public UInt32 VolumeSerialNumber;
            [FieldOffset(12)] public UInt32 VolumeLabelLength;
            [FieldOffset(16)] public UInt32 SupportsObjects;
            // [FieldOffset(20)] public UInt16 VolumeLabel; // multi-byte
        }

        public static NtStatusCode NtQueryVolumeInformationFile(
            SafeFileHandle Handle,
            ref IO_STATUS_BLOCK IoStatusBlock,
            ref FILE_FS_VOLUME_INFORMATION FsVolumeInformation)
        {
            NtStatusCode status;
            int bufferSize = 4096; // arbitrary value
            IntPtr buffer = Marshal.AllocHGlobal(bufferSize);
            _FILE_FS_VOLUME_INFORMATION rawVolInfo;

            if (IntPtr.Zero == buffer)
            {
                throw new InsufficientMemoryException("Could not allocate buffer");
            }

            status = (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtQueryVolumeInformationFile(
                Handle.DangerousGetHandle(),
                IoStatusBlock,
                buffer,
                (UInt32)bufferSize,
                (UInt32)FS_INFORMATION_CLASS.FileFsAttributeInformation);

            if (NtStatus.NT_SUCCESS(status))
            {
                rawVolInfo = Marshal.PtrToStructure<_FILE_FS_VOLUME_INFORMATION>(buffer);

                FsVolumeInformation.VolumeCreationTime = rawVolInfo.VolumeCreationTime;
                FsVolumeInformation.VolumeSerialNumber = rawVolInfo.VolumeSerialNumber;
                FsVolumeInformation.SupportsObjects = (0 != rawVolInfo.SupportsObjects);
                FsVolumeInformation.VolumeLabel = Marshal.PtrToStringUni(buffer + Marshal.SizeOf(rawVolInfo), (int)rawVolInfo.VolumeLabelLength / sizeof(char));
            }

            Marshal.FreeHGlobal(buffer);
            buffer = IntPtr.Zero;

            return status;
        }


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
                NtStatusCode status = NtQueryVolumeInformationFile(Handle, ref statusBlock, ref fsAttrInfo);

                if (!NtStatus.NT_SUCCESS(status))
                {
                    throw new IOException($"NtQueryVolumeInformationFile failed, status {status} ({status:X}) = {NtStatusToString.StatusToString(status)}");
                }

                return fsAttrInfo;

            }

            private FILE_FS_ATTRIBUTE_INFORMATION()
            {
                FileSystemAttributes = 0;
                MaximumComponentNameLength = 0;
                FileSystemName = "Unknown";
            }
        }

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _FILE_FS_ATTRIBUTE_INFORMATION
        {
            [FieldOffset(0)] public UInt32 FileSystemAttributes;
            [FieldOffset(4)] public Int32 MaximumComponentNameLength;
            [FieldOffset(8)] public UInt32 FileSystemNameLength;
            // [FieldOffset(12)] public Char FileSystemName;
        }


        public static NtStatusCode NtQueryVolumeInformationFile(
            SafeFileHandle Handle,
            ref IO_STATUS_BLOCK IoStatusBlock,
            ref FILE_FS_ATTRIBUTE_INFORMATION FsAttributeInformation)
        {
            NtStatusCode status;
            int bufferSize = 4096;
            IntPtr buffer = Marshal.AllocHGlobal(bufferSize); // arbitrary value

            if (IntPtr.Zero == buffer)
            {
                throw new InsufficientMemoryException("Could not allocate buffer");
            }

            status = (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtQueryVolumeInformationFile(
                Handle.DangerousGetHandle(),
                IoStatusBlock,
                buffer,
                (UInt32)bufferSize,
                (UInt32)FS_INFORMATION_CLASS.FileFsAttributeInformation);

            if (NtStatus.NT_SUCCESS(status))
            {
                _FILE_FS_ATTRIBUTE_INFORMATION rawAttributeInfo = Marshal.PtrToStructure<_FILE_FS_ATTRIBUTE_INFORMATION>(buffer);
                FsAttributeInformation.FileSystemAttributes = rawAttributeInfo.FileSystemAttributes;
                FsAttributeInformation.MaximumComponentNameLength = rawAttributeInfo.MaximumComponentNameLength;
                FsAttributeInformation.FileSystemName = Marshal.PtrToStringUni(buffer + Marshal.SizeOf(rawAttributeInfo), (int)rawAttributeInfo.FileSystemNameLength / sizeof(char));
            }

            Marshal.FreeHGlobal(buffer);
            buffer = IntPtr.Zero;

            return status;
        }

    }
}

