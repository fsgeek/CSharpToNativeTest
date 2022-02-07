using NativeCalls;
using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;
using USNJournal;

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

            List<USN_JOURNAL.USN_JOURNAL_DRIVE_DATA>UsnDrives = USN_JOURNAL.GetUsnJournalDrives();

            foreach (USN_JOURNAL.USN_JOURNAL_DRIVE_DATA data in UsnDrives) 
            {
                Console.WriteLine($"Drive data.Drive has a USN journal");
            }


            /*
             * This is what fsutil shows for the USN journal information
             * 
             *  PS C:\Users\TonyMason\source\repos\CSharpToNativeTest\MountManagerTest\bin\Debug\net6.0> fsutil usn queryJournal c:
                Usn Journal ID   : 0x01d6a0c52c1b9016
                First Usn        : 0x0000000c02800000
                Next Usn         : 0x0000000c04d18550
                Lowest Valid Usn : 0x0000000000000000
                Max Usn          : 0x00000fffffff0000
                Maximum Size     : 0x0000000002000000 (32.0 MB)
                Allocation Delta : 0x0000000000800000 ( 8.0 MB)
                Minimum record version supported : 2
                Maximum record version supported : 4
                Write range tracking: Disabled
            */

            // Prior work has been focused on static data sets.  To make this a useful system service we need to support dynamic data collection, which
            // gives rise to the systems problem that are at the heart of my research.
        }
    }
}
