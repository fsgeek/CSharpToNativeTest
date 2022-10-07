using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace NativeCalls
{
    public partial class SystemCalls
    {
        public static NtStatusCode NtQueryEaFile(
            SafeFileHandle FileHandle,
            ref IO_STATUS_BLOCK IoStatusBlock,
            IntPtr Buffer,
            UInt32 BufferLength,
            bool ReturnSingleEntry,
            IntPtr EaList,
            UInt32 EaListLength,
            ref UInt32? EaIndex,
            bool RestartScan)
        {
            NtStatusCode status = NtStatusCode.STATUS_BUFFER_TOO_SMALL;

            status = (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtQueryEaFile(
                FileHandle.DangerousGetHandle(), 
                IoStatusBlock, 
                Buffer, 
                BufferLength, 
                (uint) (ReturnSingleEntry ? 1 : 0), 
                EaList, 
                EaListLength, 
                ref EaIndex, 
                (uint) (RestartScan ? 1 : 0)
            );

            return status;
        }


    }
}