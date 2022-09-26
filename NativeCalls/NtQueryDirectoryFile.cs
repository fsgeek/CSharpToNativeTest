using Microsoft.Win32.SafeHandles;
using NativeSupportLibrary;
using System.Diagnostics;
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
            IntPtr fileName = IntPtr.Zero;

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
                fileName,
                (UInt32) (RestartScan ? 1 : 0)
                );

            if (NtStatusCode.STATUS_SUCCESS == status)
            {
                Marshal.Copy(infoBuffer, FileInformation, 0, (int)IoStatusBlock.Information);
            }

            return status;
        }

        public static NtStatusCode NtQueryDirectoryFile(
            SafeFileHandle Handle,
            EVENT ev,
            APC apc,
            ref IO_STATUS_BLOCK IoStatusBlock,
            ref IntPtr FileInformation,
            ref UInt32 FileInformationLength,
            FILE_INFORMATION_CLASS FileInformationClass,
            bool ReturnSingleEntry,
            UNICODE_STRING? FileName,
            bool RestartScan
        )
        {
            NtStatusCode status;
            IntPtr fileName = IntPtr.Zero;

            if (0 == FileInformationLength)
            {
                Debug.Assert(IntPtr.Zero == FileInformation, "Can't specify a buffer without a length");
                FileInformationLength = 1024 * 1024;
                FileInformation = Marshal.AllocHGlobal((int) FileInformationLength);
            }

            if (null != FileName)
            {
                Debug.Assert(false, "Not implemented yet");
            }

            return (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtQueryDirectoryFile(
                Handle.DangerousGetHandle(),
                IntPtr.Zero, // No event support at present
                IntPtr.Zero, // No APC support at present
                IntPtr.Zero, // No APC support (context) at present
                IoStatusBlock,
                FileInformation,
                FileInformationLength,
                (UInt32)FileInformationClass,
                (UInt32)(ReturnSingleEntry ? 1 : 0),
                fileName,
                (UInt32)(RestartScan ? 1 : 0)
                );
        }

    }
}
