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
using System.Reflection.Metadata.Ecma335;
using static NativeTypes.FILE_FS_SECTOR_SIZE_INFORMATION;

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
            FILE_CASE_PRESERVED_NAMES, //= = 0x00000002;
            FILE_UNICODE_ON_DISK, //= = 0x00000004;
            FILE_PERSISTENT_ACLS, //= = 0x00000008;
            FILE_FILE_COMPRESSION, //= = 0x00000010;
            FILE_VOLUME_QUOTAS, //= = 0x00000020;
            FILE_SUPPORTS_SPARSE_FILES, //= = 0x00000040;
            FILE_SUPPORTS_REPARSE_POINTS, //= = 0x00000080;
            FILE_SUPPORTS_REMOTE_STORAGE, //= = 0x00000100;
            FILE_RETURNS_CLEANUP_RESULT_INFO, //= = 0x00000200;
            FILE_SUPPORTS_POSIX_UNLINK_RENAME, //= = 0x00000400;
            FILE_SUPPORTS_BYPASS_IO, //= = 0x00000800;
            FILE_VOLUME_IS_COMPRESSED, //= = 0x00008000;
            FILE_SUPPORTS_OBJECT_IDS, //= = 0x00010000;
            FILE_SUPPORTS_ENCRYPTION, //= = 0x00020000;
            FILE_NAMED_STREAMS, //= = 0x00040000;
            FILE_READ_ONLY_VOLUME, //= = 0x00080000;
            FILE_SEQUENTIAL_WRITE_ONCE, //= = 0x00100000;
            FILE_SUPPORTS_TRANSACTIONS, //= = 0x00200000;
            FILE_SUPPORTS_HARD_LINKS, //= = 0x00400000;
            FILE_SUPPORTS_EXTENDED_ATTRIBUTES, //= = 0x00800000;
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
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_CASE_SENSITIVE_SEARCH: //= = 0x00000001;
                        return "FILE_CASE_SENSITIVE_SEARCH";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_CASE_PRESERVED_NAMES: //= = 0x00000002;
                        return "FILE_CASE_PRESERVED_NAMES";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_UNICODE_ON_DISK: //= = 0x00000004;
                        return "FILE_UNICODE_ON_DISK";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_PERSISTENT_ACLS: //= = 0x00000008;
                        return "FILE_PERSISTENT_ACLS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_FILE_COMPRESSION: //= = 0x00000010;
                        return "FILE_FILE_COMPRESSION";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_VOLUME_QUOTAS: //= = 0x00000020;
                        return "FILE_VOLUME_QUOTAS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_SPARSE_FILES: //= = 0x00000040;
                        return "FILE_SUPPORTS_SPARSE_FILES";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_REPARSE_POINTS: //= = 0x00000080;
                        return "FILE_SUPPORTS_REPARSE_POINTS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_REMOTE_STORAGE: //= = 0x00000100;
                        return "FILE_CASE_SENSITIVE_SEARCH";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_RETURNS_CLEANUP_RESULT_INFO: //= = 0x00000200;
                        return "FILE_RETURNS_CLEANUP_RESULT_INFO";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_POSIX_UNLINK_RENAME: //= = 0x00000400;
                        return "FILE_SUPPORTS_POSIX_UNLINK_RENAME";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_BYPASS_IO: //= = 0x00000800;
                        return "FILE_SUPPORTS_BYPASS_IO";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_VOLUME_IS_COMPRESSED: //= = 0x00008000;
                        return "FILE_VOLUME_IS_COMPRESSED";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_OBJECT_IDS: //= = 0x00010000;
                        return "FILE_SUPPORTS_OBJECT_IDS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_ENCRYPTION: //= = 0x00020000;
                        return "FILE_SUPPORTS_ENCRYPTION";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_NAMED_STREAMS: //= = 0x00040000;
                        return "FILE_NAMED_STREAMS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_READ_ONLY_VOLUME: //= = 0x00080000;
                        return "FILE_READ_ONLY_VOLUME";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SEQUENTIAL_WRITE_ONCE: //= = 0x00100000;
                        return "FILE_SEQUENTIAL_WRITE_ONCE";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_TRANSACTIONS: //= = 0x00200000;
                        return "FILE_SUPPORTS_TRANSACTIONS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_HARD_LINKS: //= = 0x00400000;
                        return "FILE_SUPPORTS_HARD_LINKS";
                    case FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_EXTENDED_ATTRIBUTES: //= = 0x00800000;
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

        public UInt32 FileSystemAttributeFlags { get; private set; }

        public FILE_SYSTEM_ATTRIBUTE_FLAGS(UInt32 Attributes)
        {
            FileSystemAttributeFlags = Attributes;
        }

        public override string ToString()
        {
            return ExtractFileSystemAttributeFlags(FileSystemAttributeFlags);
        }
    }

    public class FILE_FS_VOLUME_INFORMATION
    {
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
        public bool SupportsObjects { get { return (0 == nativeFsVolumeInformation.SupportsObjects) ? false : true; } }

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
                status = SystemCalls.NtQueryVolumeInformationFile(Handle, ref statusBlock, buffer, (uint)bufferLength, FS_INFORMATION_CLASS.FileFsVolumeInformation);

                if (!NtStatus.NT_SUCCESS(status))
                {
                    Console.WriteLine($"NtQueryVolumeInformationFile failed for FileFsVolumeInformation {NtStatusToString.StatusToString(status)} ({status:X})");
                    break;
                }

                unsafe
                {
                    nativeFsVolumeInformation = Marshal.PtrToStructure<_FILE_FS_VOLUME_INFORMATION>(buffer);
                    VolumeLabel = Marshal.PtrToStringUni(buffer + VolumeLabelOffset, (int)nativeFsVolumeInformation.VolumeLabelLength / 2);
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

        private const int FileSystemNameOffset = 12;

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_FS_ATTRIBUTE_INFORMATION
        {
            [FieldOffset(0)] public UInt32 FileSystemAttributes;
            [FieldOffset(4)] public Int32 MaximumComponentLength;
            [FieldOffset(8)] public UInt32 FileSystemNameLength;

        }

        private _FILE_FS_ATTRIBUTE_INFORMATION nativeFsAttributeInformation;


        public FILE_SYSTEM_ATTRIBUTE_FLAGS FileSystemAttributes;
        public Int32 MaximumComponentLength { get { return nativeFsAttributeInformation.MaximumComponentLength; } }
        public string FileSystemName;

        public FILE_FS_ATTRIBUTE_INFORMATION(SafeFileHandle Handle)
        {
            NtStatusCode status = GetFsAttributeInformation(Handle);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException("Unable to get file system attribute information");
            }
        }

        public FILE_FS_ATTRIBUTE_INFORMATION(SafeFileHandle Handle, string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFsAttributeInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }

        }

        public FILE_FS_ATTRIBUTE_INFORMATION(string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFsAttributeInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }

        }


        private NtStatusCode GetFsAttributeInformation(SafeFileHandle RootHandle, string RelativePathName)
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

            status = GetFsAttributeInformation(handle);

            handle.Dispose();
            return status;

        }

        private NtStatusCode GetFsAttributeInformation(SafeFileHandle Handle)
        {
            NtStatusCode status = NtStatusCode.STATUS_UNSUCCESSFUL;
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            int bufferLength = 4096;
            IntPtr buffer = Marshal.AllocHGlobal(bufferLength);

            Debug.Assert(IntPtr.Zero != buffer, "Allocation failed");

            while (true)
            {
                status = SystemCalls.NtQueryVolumeInformationFile(Handle, ref statusBlock, buffer, (uint)bufferLength, FS_INFORMATION_CLASS.FileFsAttributeInformation);

                if (!NtStatus.NT_SUCCESS(status))
                {
                    Console.WriteLine($"NtQueryVolumeInformationFile failed for FileFsAttributeInformation {NtStatusToString.StatusToString(status)} ({status:X})");
                    break;
                }

                unsafe
                {
                    nativeFsAttributeInformation = Marshal.PtrToStructure<_FILE_FS_ATTRIBUTE_INFORMATION>(buffer);
                    FileSystemName = Marshal.PtrToStringUni(buffer + FileSystemNameOffset, (int)nativeFsAttributeInformation.FileSystemNameLength / 2);
                }
                FileSystemAttributes = new FILE_SYSTEM_ATTRIBUTE_FLAGS(nativeFsAttributeInformation.FileSystemAttributes);
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

    public class FILE_FS_LABEL_INFORMATION
    {
        /*
         * typedef struct _FILE_FS_LABEL_INFORMATION {
            ULONG VolumeLabelLength;
            WCHAR VolumeLabel[1];
          } FILE_FS_LABEL_INFORMATION, *PFILE_FS_LABEL_INFORMATION;

         */
    }

    public class FILE_FS_SIZE_INFORMATION
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_FS_SIZE_INFORMATION
        {
            [FieldOffset(0)] public Int64 TotalAllocationUnits;
            [FieldOffset(8)] public Int64 AvailableAllocationUnits;
            [FieldOffset(16)] public UInt32 SectorsPerAllocationUnit;
            [FieldOffset(20)] public UInt32 BytesPerSector;
        }


        private _FILE_FS_SIZE_INFORMATION nativeFsSizeInfo;

        public Int64 TotalAllocationUnits { get { return nativeFsSizeInfo.TotalAllocationUnits; } }
        public Int64 AvailableAllocationUnits { get { return nativeFsSizeInfo.AvailableAllocationUnits; } }
        public UInt32 SectorsPerAllocationUnit { get { return nativeFsSizeInfo.SectorsPerAllocationUnit; } }
        public UInt32 BytesPerSector { get { return nativeFsSizeInfo.BytesPerSector; } }

        public FILE_FS_SIZE_INFORMATION(SafeFileHandle Handle)
        {
            NtStatusCode status = GetFsInformation(Handle);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException("Unable to get driver in path info for handle.");
            }
        }

        public FILE_FS_SIZE_INFORMATION(SafeFileHandle Handle, string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFsInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }

        }

        public FILE_FS_SIZE_INFORMATION(string PathToFile)
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
                status = SystemCalls.NtQueryVolumeInformationFile(Handle, ref statusBlock, buffer, (uint)bufferLength, FS_INFORMATION_CLASS.FileFsSizeInformation);

                if (!NtStatus.NT_SUCCESS(status))
                {
                    Console.WriteLine($"NtQueryVolumeInformationFile failed for FileFsFullSizeInformationEx {NtStatusToString.StatusToString(status)} ({status:X})");
                    break;
                }

                unsafe
                {
                    nativeFsSizeInfo = Marshal.PtrToStructure<_FILE_FS_SIZE_INFORMATION>(buffer);
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

    public class FILE_FS_DEVICE_INFORMATION
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_FS_DEVICE_INFORMATION
        {
            [FieldOffset(0)] public UInt32 DeviceType;
            [FieldOffset(4)] public UInt32 Characteristics;
        }

        private _FILE_FS_DEVICE_INFORMATION nativeFsDeviceInfo;

        public UInt32 DeviceType { get { return nativeFsDeviceInfo.DeviceType; } }
        public UInt32 Characteristics { get { return nativeFsDeviceInfo.Characteristics; } }    


        /* these are from wdm.h */
        public const UInt32 FILE_REMOVABLE_MEDIA = 0x00000001;
        public const UInt32 FILE_READ_ONLY_DEVICE = 0x00000002;
        public const UInt32 FILE_FLOPPY_DISKETTE = 0x00000004;
        public const UInt32 FILE_WRITE_ONCE_MEDIA = 0x00000008;
        public const UInt32 FILE_REMOTE_DEVICE = 0x00000010;
        public const UInt32 FILE_DEVICE_IS_MOUNTED = 0x00000020;
        public const UInt32 FILE_VIRTUAL_VOLUME = 0x00000040;
        public const UInt32 FILE_AUTOGENERATED_DEVICE_NAME = 0x00000080;
        public const UInt32 FILE_DEVICE_SECURE_OPEN = 0x00000100;
        public const UInt32 FILE_CHARACTERISTIC_PNP_DEVICE = 0x00000800;
        public const UInt32 FILE_CHARACTERISTIC_TS_DEVICE = 0x00001000;
        public const UInt32 FILE_CHARACTERISTIC_WEBDAV_DEVICE = 0x00002000;
        public const UInt32 FILE_CHARACTERISTIC_CSV = 0x00010000;
        public const UInt32 FILE_DEVICE_ALLOW_APPCONTAINER_TRAVERSAL = 0x00020000;
        public const UInt32 FILE_PORTABLE_DEVICE = 0x00040000;
        public const UInt32 FILE_REMOTE_DEVICE_VSMB = 0x00080000;
        public const UInt32 FILE_DEVICE_REQUIRE_SECURITY_CHECK = 0x00100000;

        public FILE_FS_DEVICE_INFORMATION(SafeFileHandle Handle)
        {
            NtStatusCode status = GetFsInformation(Handle);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException("Unable to get driver in path info for handle.");
            }
        }

        public FILE_FS_DEVICE_INFORMATION(SafeFileHandle Handle, string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFsInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }

        }

        public FILE_FS_DEVICE_INFORMATION(string PathToFile)
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
                status = SystemCalls.NtQueryVolumeInformationFile(Handle, ref statusBlock, buffer, (uint)bufferLength, FS_INFORMATION_CLASS.FileFsDeviceInformation);

                if (!NtStatus.NT_SUCCESS(status))
                {
                    Console.WriteLine($"NtQueryVolumeInformationFile failed for FileFsFullSizeInformationEx {NtStatusToString.StatusToString(status)} ({status:X})");
                    break;
                }

                unsafe
                {
                    nativeFsDeviceInfo = Marshal.PtrToStructure<_FILE_FS_DEVICE_INFORMATION>(buffer);
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

    public class FILE_FS_CONTROL_INFORMATION
    {
        //
        // File system control flags
        //

        public const UInt32 FILE_VC_QUOTA_NONE = 0x00000000;
        public const UInt32 FILE_VC_QUOTA_TRACK = 0x00000001;
        public const UInt32 FILE_VC_QUOTA_ENFORCE = 0x00000002;
        public const UInt32 FILE_VC_QUOTA_MASK = 0x00000003;
        public const UInt32 FILE_VC_CONTENT_INDEX_DISABLED = 0x00000008;
        public const UInt32 FILE_VC_LOG_QUOTA_THRESHOLD = 0x00000010;
        public const UInt32 FILE_VC_LOG_QUOTA_LIMIT = 0x00000020;
        public const UInt32 FILE_VC_LOG_VOLUME_THRESHOLD = 0x00000040;
        public const UInt32 FILE_VC_LOG_VOLUME_LIMIT = 0x00000080;
        public const UInt32 FILE_VC_QUOTAS_INCOMPLETE = 0x00000100;
        public const UInt32 FILE_VC_QUOTAS_REBUILDING = 0x00000200;

        public const UInt32 FILE_VC_VALID_MASK = 0x000003ff;

        /*
        typedef struct _FILE_FS_CONTROL_INFORMATION
        {
            LARGE_INTEGER FreeSpaceStartFiltering;
            LARGE_INTEGER FreeSpaceThreshold;
            LARGE_INTEGER FreeSpaceStopFiltering;
            LARGE_INTEGER DefaultQuotaThreshold;
            LARGE_INTEGER DefaultQuotaLimit;
            ULONG FileSystemControlFlags;
        }
        FILE_FS_CONTROL_INFORMATION, *PFILE_FS_CONTROL_INFORMATION;
        */

    }

    public class FILE_FS_FULL_SIZE_INFORMATION
    {
        /*
        typedef struct _FILE_FS_FULL_SIZE_INFORMATION
        {
            LARGE_INTEGER TotalAllocationUnits;
            LARGE_INTEGER CallerAvailableAllocationUnits;
            LARGE_INTEGER ActualAvailableAllocationUnits;
            ULONG SectorsPerAllocationUnit;
            ULONG BytesPerSector;
        }
        FILE_FS_FULL_SIZE_INFORMATION, *PFILE_FS_FULL_SIZE_INFORMATION;
        */
    }

    public class FILE_FS_OBJECT_ID_INFORMATION
    {
        /*
        typedef struct _FILE_FS_OBJECTID_INFORMATION
        {
            UCHAR ObjectId[16];
            UCHAR ExtendedInfo[48];
        }
        FILE_FS_OBJECTID_INFORMATION, *PFILE_FS_OBJECTID_INFORMATION;
        */

    }

    public class FILE_FS_DRIVER_PATH_INFORMATION
    {
        private const int DriverNameOffset = 8;
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_FS_DRIVER_PATH_INFORMATION
        {
            [FieldOffset(0)] public byte DriverInPath;
            [FieldOffset(4)] public UInt32 DriverNameLength;
        }

        private _FILE_FS_DRIVER_PATH_INFORMATION nativeDriverInPathInfo;
        public bool DriverInPath { get { return (0 == nativeDriverInPathInfo.DriverInPath) ? false : true; } }
        public string? DriverName;

        public FILE_FS_DRIVER_PATH_INFORMATION(SafeFileHandle Handle)
        {
            NtStatusCode status = GetFsInformation(Handle);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException("Unable to get driver in path info for handle.");
            }
        }

        public FILE_FS_DRIVER_PATH_INFORMATION(SafeFileHandle Handle, string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFsInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }

        }

        public FILE_FS_DRIVER_PATH_INFORMATION(string PathToFile)
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
                status = SystemCalls.NtQueryVolumeInformationFile(Handle, ref statusBlock, buffer, (uint)bufferLength, FS_INFORMATION_CLASS.FileFsDriverPathInformation);

                if (!NtStatus.NT_SUCCESS(status))
                {
                    Console.WriteLine($"NtQueryVolumeInformationFile failed for FileFsFullSizeInformationEx {NtStatusToString.StatusToString(status)} ({status:X})");
                    break;
                }

                unsafe
                {
                    nativeDriverInPathInfo = Marshal.PtrToStructure<_FILE_FS_DRIVER_PATH_INFORMATION>(buffer);
                    DriverName = Marshal.PtrToStringUni(buffer + DriverNameOffset, (int) nativeDriverInPathInfo.DriverNameLength / 2);
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

    public class FILE_FS_VOLUME_FLAGS_INFORMATION
    {
        /*
        typedef struct _FILE_FS_VOLUME_FLAGS_INFORMATION
        {
            ULONG Flags;
        }
        FILE_FS_VOLUME_FLAGS_INFORMATION, *PFILE_FS_VOLUME_FLAGS_INFORMATION;

        // Appears to be a set operation, don't worry about it for now.
        */
    }

    public class FILE_FS_SECTOR_SIZE_INFORMATION
    {
        public const UInt32 SSINFO_FLAGS_ALIGNED_DEVICE = 0x1;
        public const UInt32 SSINFO_FLAGS_PARTITION_ALIGNED_ON_DEVICE = 0x00000002;
        public const UInt32 SSINFO_FLAGS_NO_SEEK_PENALTY = 0x00000004;
        public const UInt32 SSINFO_FLAGS_TRIM_ENABLED = 0x00000008;
        public const UInt32 SSINFO_FLAGS_BYTE_ADDRESSABLE = 0x00000010;
        public const UInt32 SSINFO_OFFSET_UNKNOWN = 0xffffffff;

        public class SECTOR_SIZE_FLAGS
        {
            private UInt32 Flags;

            override public string ToString()
            {
                return GetStringForSectorSizeFlags(Flags);
            }

            public SECTOR_SIZE_FLAGS(uint flags)
            {
                Flags = flags;
            }

            static public string GetStringForSectorSizeFlags(uint Flags)
            {
                string result = "";
                bool first = true;

                if (SSINFO_OFFSET_UNKNOWN == Flags) 
                {
                    return "SSINFO_OFFSET_UNKNOWN";
                }

                if (0 != (SSINFO_FLAGS_ALIGNED_DEVICE & Flags))
                {
                    if (!first)
                    {
                        result += "|";
                    }
                    result += "SSINFO_FLAGS_ALIGNED_DEVICE";
                    first = false;
                }

                if (0 != (SSINFO_FLAGS_PARTITION_ALIGNED_ON_DEVICE & Flags))
                {
                    if (!first)
                    {
                        result += "|";
                    }
                    result += "SSINFO_FLAGS_PARTITION_ALIGNED_ON_DEVICE";
                    first = false;
                }

                if (0 != (SSINFO_FLAGS_NO_SEEK_PENALTY & Flags))
                {
                    if (!first)
                    {
                        result += "|";
                    }
                    result += "SSINFO_FLAGS_NO_SEEK_PENALTY";
                    first = false;
                }

                if (0 != (SSINFO_FLAGS_TRIM_ENABLED & Flags))
                {
                    if (!first)
                    {
                        result += "|";
                    }
                    result += "SSINFO_FLAGS_TRIM_ENABLED";
                    first = false;
                }

                if (0 != (SSINFO_FLAGS_BYTE_ADDRESSABLE & Flags))
                {
                    if (!first)
                    {
                        result += "|";
                    }
                    first = false;
                    result += "SSINFO_FLAGS_BYTE_ADDRESSABLE";
                }

                return result;
            }

        }

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_FS_SECTOR_SIZE_INFORMATION
        {
            [FieldOffset(0)] public UInt32 LogicalBytesPerSector;
            [FieldOffset(4)] public UInt32 PhysicalBytesPerSectorForAtomicity;
            [FieldOffset(8)] public UInt32 PhysicalBytesPerSectorForPerformance;
            [FieldOffset(12)] public UInt32 FileSystemEffectivePhysicalBytesPerSectorForAtomicity;
            [FieldOffset(16)] public UInt32 Flags;
            [FieldOffset(20)] public UInt32 SectorsPerAllocationUnit;
            [FieldOffset(24)] public UInt32 BytesPerSector;
        }

        private _FILE_FS_SECTOR_SIZE_INFORMATION nativeSizeInformation;

        public UInt64 LogicalBytesPerSector { get { return nativeSizeInformation.LogicalBytesPerSector; } }
        public UInt64 PhysicalBytesPerSectorForAtomicity { get { return nativeSizeInformation.PhysicalBytesPerSectorForAtomicity; } }
        public UInt64 PhysicalBytesPerSectorForPerformance { get { return nativeSizeInformation.PhysicalBytesPerSectorForPerformance; } }
        public UInt64 FileSystemEffectivePhysicalBytesPerSectorForAtomicity { get { return nativeSizeInformation.FileSystemEffectivePhysicalBytesPerSectorForAtomicity; } }
        public SECTOR_SIZE_FLAGS Flags;
        public UInt32 SectorsPerAllocationUnit { get { return nativeSizeInformation.SectorsPerAllocationUnit; } }
        public UInt32 BytesPerSector { get { return nativeSizeInformation.BytesPerSector; } }


        public FILE_FS_SECTOR_SIZE_INFORMATION(SafeFileHandle Handle)
        {
            NtStatusCode status = GetFsInformation(Handle);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException("Unable to get names information for handle.");
            }
        }

        public FILE_FS_SECTOR_SIZE_INFORMATION(SafeFileHandle Handle, string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFsInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }

        }

        public FILE_FS_SECTOR_SIZE_INFORMATION(string PathToFile)
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
                status = SystemCalls.NtQueryVolumeInformationFile(Handle, ref statusBlock, buffer, (uint)bufferLength, FS_INFORMATION_CLASS.FileFsSectorSizeInformation);

                if (!NtStatus.NT_SUCCESS(status))
                {
                    Console.WriteLine($"NtQueryVolumeInformationFile failed for FileFsFullSizeInformationEx {NtStatusToString.StatusToString(status)} ({status:X})");
                    break;
                }

                unsafe
                {
                    nativeSizeInformation = Marshal.PtrToStructure<_FILE_FS_SECTOR_SIZE_INFORMATION>(buffer);
                    Flags = new SECTOR_SIZE_FLAGS(nativeSizeInformation.Flags);
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

    public class FILE_FS_DATA_COPY_INFORMATION
    {
        /*
        typedef struct _FILE_FS_DATA_COPY_INFORMATION
        {
            ULONG NumberOfCopies;
        }
        FILE_FS_DATA_COPY_INFORMATION, *PFILE_FS_DATA_COPY_INFORMATION;
        */

    }

    public class FILE_FS_METADATA_SIZE_INFORMATION
    {
        /*
        typedef struct _FILE_FS_METADATA_SIZE_INFORMATION
        {
            LARGE_INTEGER TotalMetadataAllocationUnits;
            ULONG SectorsPerAllocationUnit;
            ULONG BytesPerSector;
        }
        FILE_FS_METADATA_SIZE_INFORMATION, *PFILE_FS_METADATA_SIZE_INFORMATION;

        */

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_FS_METADATA_SIZE_INFORMATION
        {
            [FieldOffset(0)] public Int64 TotalMetadataAllocationUnits;
            [FieldOffset(8)] public UInt32 SectorsPerAllocationUnit;
            [FieldOffset(12)] public UInt32 BytesPerSector;
        }

        private _FILE_FS_METADATA_SIZE_INFORMATION nativeSizeInformation;

        public Int64 TotalMetadataAllocationUnits { get { return nativeSizeInformation.TotalMetadataAllocationUnits; } }
        public UInt32 SectorsPerAllocationUnit { get { return nativeSizeInformation.SectorsPerAllocationUnit; } }
        public UInt32 BytesPerSector { get { return nativeSizeInformation.BytesPerSector; } }


        public FILE_FS_METADATA_SIZE_INFORMATION(SafeFileHandle Handle)
        {
            NtStatusCode status = GetFsInformation(Handle);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException("Unable to get names information for handle.");
            }
        }

        public FILE_FS_METADATA_SIZE_INFORMATION(SafeFileHandle Handle, string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFsInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }

        }

        public FILE_FS_METADATA_SIZE_INFORMATION(string PathToFile)
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
                status = SystemCalls.NtQueryVolumeInformationFile(Handle, ref statusBlock, buffer, (uint)bufferLength, FS_INFORMATION_CLASS.FileFsMetadataSizeInformation);

                if (!NtStatus.NT_SUCCESS(status))
                {
                    Console.WriteLine($"NtQueryVolumeInformationFile failed for FileFsFullSizeInformationEx {NtStatusToString.StatusToString(status)} ({status:X})");
                    break;
                }

                unsafe
                {
                    nativeSizeInformation = Marshal.PtrToStructure<_FILE_FS_METADATA_SIZE_INFORMATION>(buffer);
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


    public class FILE_FS_FULL_SIZE_INFORMATION_EX
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_FS_FULL_SIZE_INFORMATION_EX
        {
            [FieldOffset(0)] public UInt64 ActualTotalAllocationUnits;
            [FieldOffset(8)] public UInt64 ActualAvailableAllocationUnits;
            [FieldOffset(16)] public UInt64 ActualPoolUnavailableAllocationUnits;
            [FieldOffset(24)] public UInt64 CallerTotalAllocationUnits;
            [FieldOffset(32)] public UInt64 CallerAvailableAllocationUnits;
            [FieldOffset(40)] public UInt64 CallerPoolUnavailableAllocationUnits;
            [FieldOffset(48)] public UInt64 UsedAllocationUnits;
            [FieldOffset(56)] public UInt64 TotalReservedAllocationUnits;
            [FieldOffset(64)] public UInt64 VolumeStorageReserveAllocationUnits;
            [FieldOffset(72)] public UInt64 AvailableCommittedAllocationUnits;
            [FieldOffset(80)] public UInt64 PoolAvailableAllocationUnits;
            [FieldOffset(84)] public UInt32 SectorsPerAllocationUnit;
            [FieldOffset(88)] public UInt32 BytesPerSector;
        }

        private _FILE_FS_FULL_SIZE_INFORMATION_EX nativeSizeInformation;

        public UInt64 ActualTotalAllocationUnits { get { return nativeSizeInformation.ActualTotalAllocationUnits; } }
        public UInt64 ActualAvailableAllocationUnits { get { return nativeSizeInformation.ActualAvailableAllocationUnits; } }
        public UInt64 ActualPoolUnavailableAllocationUnits { get { return nativeSizeInformation.ActualPoolUnavailableAllocationUnits; } }
        public UInt64 CallerTotalAllocationUnits { get { return nativeSizeInformation.CallerTotalAllocationUnits; } }
        public UInt64 CallerAvailableAllocationUnits { get { return nativeSizeInformation.CallerAvailableAllocationUnits; } }
        public UInt64 CallerPoolUnavailableAllocationUnits { get { return nativeSizeInformation.CallerPoolUnavailableAllocationUnits; } }
        public UInt64 UsedAllocationUnits { get { return nativeSizeInformation.UsedAllocationUnits; } }
        public UInt64 TotalReservedAllocationUnits { get { return nativeSizeInformation.TotalReservedAllocationUnits; } }
        public UInt64 VolumeStorageReserveAllocationUnits { get { return nativeSizeInformation.VolumeStorageReserveAllocationUnits; } }
        public UInt64 AvailableCommittedAllocationUnits { get { return nativeSizeInformation.AvailableCommittedAllocationUnits; } }
        public UInt64 PoolAvailableAllocationUnits { get { return nativeSizeInformation.PoolAvailableAllocationUnits; } }
        public UInt32 SectorsPerAllocationUnit { get { return nativeSizeInformation.SectorsPerAllocationUnit; } }
        public UInt32 BytesPerSector { get { return nativeSizeInformation.BytesPerSector; } }


        public FILE_FS_FULL_SIZE_INFORMATION_EX(SafeFileHandle Handle)
        {
            NtStatusCode status = GetFsInformation(Handle);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException("Unable to get names information for handle.");
            }
        }

        public FILE_FS_FULL_SIZE_INFORMATION_EX(SafeFileHandle Handle, string PathToFile)
        {
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            NtStatusCode status = GetFsInformation(handle, PathToFile);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException(PathToFile, (int)status);
            }

        }

        public FILE_FS_FULL_SIZE_INFORMATION_EX(string PathToFile)
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
                status = SystemCalls.NtQueryVolumeInformationFile(Handle, ref statusBlock, buffer, (uint)bufferLength, FS_INFORMATION_CLASS.FileFsFullSizeInformationEx);

                if (!NtStatus.NT_SUCCESS(status))
                {
                    Console.WriteLine($"NtQueryVolumeInformationFile failed for FileFsFullSizeInformationEx {NtStatusToString.StatusToString(status)} ({status:X})");
                    break;
                }

                unsafe
                {
                    nativeSizeInformation = Marshal.PtrToStructure<_FILE_FS_FULL_SIZE_INFORMATION_EX>(buffer);
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

}
