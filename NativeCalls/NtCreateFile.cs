using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace NativeCalls
{
    public partial class SystemCalls
    {
        public static NtStatusCode NtCreateFile(ref SafeFileHandle Handle, ACCESS_MASK accessMask, OBJECT_ATTRIBUTES ObjectAttributes, ref IO_STATUS_BLOCK Iosb, LARGE_INTEGER AllocationSize, FILE_ATTRIBUTES FileAttributes, SHARE_ACCESS ShareAccess, CREATE_DISPOSITION Disposition, CREATE_OPTIONS Options, EXTENDED_ATTRIBUTE EA)
        {
            IntPtr handle = IntPtr.Zero;
            NtStatusCode status;

            status = (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtCreateFile(ref handle, accessMask, ObjectAttributes, Iosb, AllocationSize, FileAttributes, ShareAccess, Disposition, Options, EA, EA.Length);

            Handle = new SafeFileHandle(handle, true);

            return status;
        }
    }
}