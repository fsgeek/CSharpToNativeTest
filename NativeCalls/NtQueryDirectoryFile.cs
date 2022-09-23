using Microsoft.Win32.SafeHandles;
using NativeSupportLibrary;
using System.Runtime.InteropServices;

namespace NativeCalls
{

    public partial class SystemCalls
    {

        public static NtStatusCode NtQueryDirectoryFile(
            SafeFileHandle Handle,
            EVENT ev,
            APC apc,
            ref IO_STATUS_BLOCK IoStatusBlock,
            ref byte[] FileInformation,
            FILE_INFORMATION_CLASS FileInformationClass,
            bool ReturnSingleEntry,
            UNICODE_STRING? FileName,
            bool RestartScan
            )
        {
            NtStatusCode status;
            IntPtr infoBuffer = IntPtr.Zero;
            UInt32 infoBufferLength = 0;

            if (FileInformation != null && FileInformation.Length > 0)
            {
                infoBufferLength = (UInt32) FileInformation.Length;
                infoBuffer = Marshal.AllocHGlobal((int)infoBufferLength);
            }

            status = (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtQueryDirectoryFile(
                Handle.DangerousGetHandle(),
                IntPtr.Zero, // No event support at present
                IntPtr.Zero, // No APC support at present
                IntPtr.Zero, // No APC support (context) at present
                IoStatusBlock,
                infoBuffer,
                infoBufferLength,
                (UInt32) FileInformationClass,
                (UInt32) (ReturnSingleEntry ? 1 : 0),
                FileName,
                (UInt32) (RestartScan ? 1 : 0)
                );
            return NtStatusCode.STATUS_NOT_IMPLEMENTED;
        }

    }
}
