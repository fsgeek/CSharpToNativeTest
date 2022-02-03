using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace NativeSupportLibrary
{
    public class NativeLibrary
    {
        // These first routines are here for testing
        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern void print_line(string line);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public unsafe static extern void NativeTestUnicodeString(IntPtr UnicodeString);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public unsafe static extern void NativeTestIoStatusBlock(ref IO_STATUS_BLOCK iosb);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public unsafe static extern void NativeTestLargeInteger(IntPtr LargeInteger);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public unsafe static extern void NativeTestObjectAttributes(IntPtr ObjectAttributes);

        // These are native APIs that are supported by the library.
        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtCreateFile(
                ref IntPtr handle,
                UInt32 access,
                IntPtr objectAttributes,
                IntPtr ioStatus,
                IntPtr allocSize,
                UInt32 fileAttributes,
                UInt32 share,
                UInt32 createDisposition,
                UInt32 createOptions,
                IntPtr eaBuffer,
                UInt32 eaLength);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtFsControlFile(
            IntPtr Handle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            IntPtr IoStatusBlock,
            UInt32 FsControlCode,
            IntPtr InputBuffer,
            UInt32 InputBufferLength,
            IntPtr OutputBuffer,
            UInt32 OutputBufferLength);

        [DllImport("NativeLibrary.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int NtDeviceIoControlFile(
            IntPtr Handle,
            IntPtr Event,
            IntPtr ApcRoutine,
            IntPtr ApcContext,
            IntPtr IoStatusBlock,
            UInt32 FsControlCode,
            IntPtr InputBuffer,
            UInt32 InputBufferLength,
            IntPtr OutputBuffer,
            UInt32 OutputBufferLength);

    }
}
