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

            status = (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtQueryFullAttributesFile(ObjectAttributes, Buffer);

            return status;
        }
    }
}