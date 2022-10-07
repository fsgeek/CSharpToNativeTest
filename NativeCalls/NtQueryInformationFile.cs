using Microsoft.Win32.SafeHandles;
using NativeSupportLibrary;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NativeCalls
{

    public partial class SystemCalls
    {

        public static NtStatusCode NtQueryInformationFile(
            SafeFileHandle Handle,
            ref IO_STATUS_BLOCK IoStatusBlock,
            ref byte[] FileInformation,
            FILE_INFORMATION_CLASS FileInformationClass
            )
        {
            NtStatusCode status;
            IntPtr infoBuffer = IntPtr.Zero;
            UInt32 infoBufferLength = 0;

            if (FileInformation != null && FileInformation.Length > 0)
            {
                infoBufferLength = (UInt32)FileInformation.Length;
                infoBuffer = Marshal.AllocHGlobal((int)infoBufferLength);
            }


            status = (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtQueryInformationFile(
                Handle.DangerousGetHandle(),
                IoStatusBlock,
                infoBuffer,
                infoBufferLength,
                (UInt32)FileInformationClass
                );

            if (NtStatusCode.STATUS_SUCCESS == status)
            {
                Marshal.Copy(infoBuffer, FileInformation, 0, (int)IoStatusBlock.Information);
            }

            return status;
        }

        public static NtStatusCode NtQueryInformationFile(
            SafeFileHandle Handle,
            ref IO_STATUS_BLOCK IoStatusBlock,
            IntPtr Buffer,
            UInt32 BufferLength,
            FILE_INFORMATION_CLASS FileInformationClass
            )
        {
            return (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtQueryInformationFile(
                Handle.DangerousGetHandle(),
                IoStatusBlock,
                Buffer,
                BufferLength,
                (UInt32)FileInformationClass
                );
        }

    }
}
