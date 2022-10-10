using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;


namespace NativeCalls
{
    public partial class SystemCalls
    {
#if false
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

#endif // false

        public static NtStatusCode NtQueryVolumeInformationFile(
            SafeFileHandle Handle,
            ref IO_STATUS_BLOCK IoStatusBlock,
            IntPtr Buffer,
            UInt32 BufferLength,
            FS_INFORMATION_CLASS FileFsVolumeInformationClass
        )
        {
            return (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtQueryVolumeInformationFile(
                Handle.DangerousGetHandle(),
                IoStatusBlock,
                Buffer,
                BufferLength,
                (UInt32)FileFsVolumeInformationClass
                );
        }

    }
}

