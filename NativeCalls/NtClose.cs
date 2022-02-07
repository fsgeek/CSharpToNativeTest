using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace NativeCalls
{
    public partial class SystemCalls
    {
        public static NtStatusCode NtClose(ref SafeFileHandle Handle)
        {
            Handle.Close();

            return NtStatusCode.STATUS_SUCCESS;
        }

    }
}