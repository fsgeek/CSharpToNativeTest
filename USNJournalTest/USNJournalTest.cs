using NativeCalls;
using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;

namespace CSharpToNativeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            UNICODE_STRING c_drive = new UNICODE_STRING("\\??\\C:");
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero,true);
            OBJECT_ATTRIBUTES objattr = new OBJECT_ATTRIBUTES(handle, c_drive);
            ACCESS_MASK mask = (UInt32)ACCESS_MASK.SYNCHRONIZE;
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            FILE_ATTRIBUTES fileAttr = 0;
            SHARE_ACCESS shareAccess = SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_WRITE;
            CREATE_DISPOSITION disposition = CREATE_DISPOSITION.FILE_OPEN;
            CREATE_OPTIONS options = CREATE_OPTIONS.FILE_NON_DIRECTORY_FILE;
            EXTENDED_ATTRIBUTE ea = new EXTENDED_ATTRIBUTE();
            NtStatusCode status = SystemCalls.NtCreateFile(ref handle, mask, objattr, ref statusBlock, (LARGE_INTEGER)0, fileAttr, shareAccess, disposition, options, ea);

            if (!NtStatus.NT_SUCCESS(status))
            {
                Console.WriteLine("NtCreateFile failed, status {0} ({0:X}) = {1}", status, NtStatusToString.StatusToString(status));
            }

            // Console.WriteLine("Hello, World!");

            IntPtr p = IntPtr.Zero + 1;

            Console.WriteLine($"IntPtr p is now {p:X}");

            // Prior work has been focused on static data sets.  To make this a useful system service we need to support dynamic data collection, which
            // gives rise to the systems problem that are at the heart of my research.
        }
    }
}
