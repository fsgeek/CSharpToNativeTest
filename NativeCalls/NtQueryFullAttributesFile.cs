using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace NativeCalls
{
    public partial class SystemCalls
    {
        public static NtStatusCode NtQueryFullAttributesFile(OBJECT_ATTRIBUTES ObjectAttributes, IntPtr Buffer, UInt32 BufferSize)
        {
            NtStatusCode status = NtStatusCode.STATUS_BUFFER_TOO_SMALL;

            if (BufferSize >= FILE_NETWORK_OPEN_INFORMATION.MinimumBufferSize)
            {
                status = (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtQueryFullAttributesFile(ObjectAttributes, Buffer);
            }

            return status;
        }
        public static NtStatusCode NtQueryFullAttributesFile(OBJECT_ATTRIBUTES ObjectAttributes, ref FILE_NETWORK_OPEN_INFORMATION FileInformation)
        {
            IntPtr buffer = Marshal.AllocHGlobal(FILE_NETWORK_OPEN_INFORMATION.MinimumBufferSize);
            NtStatusCode status;

            status = (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtQueryFullAttributesFile(ObjectAttributes, buffer);

            if (NtStatusCode.STATUS_SUCCESS == status)
            {
                // only return information if the call worked.
                FileInformation = new FILE_NETWORK_OPEN_INFORMATION(buffer);
            }
            Marshal.FreeHGlobal(buffer);

            return status;
        }

    }
}