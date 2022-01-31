using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

using NativeSupportLibrary;

namespace CSharpToNativeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //string test_string = "\\??\\C:";
            //NativeSupportLibrary.NativeLibrary.print_line(test_string);

            //UNICODE_STRING unicodeString = new UNICODE_STRING();
            //IntPtr buffer = Marshal.StringToHGlobalUni(test_string);
            // IntPtr refPtr = Marshal.AllocHGlobal(8);

            // Marshal.WriteInt64(refPtr, (long)buffer);
            //unicodeString.Length = (ushort)(test_string.Length * sizeof(char));
            //unicodeString.MaximumLength = unicodeString.Length;
            //unicodeString.Buffer = buffer;
            //IntPtr ustr = Marshal.AllocHGlobal(Marshal.SizeOf(unicodeString));
            //Marshal.StructureToPtr(unicodeString, ustr, true);

            //unsafe
            //{
            //    NativeSupportLibrary.NativeLibrary.NativeTestUnicodeString(&unicodeString);
            //}

            //IO_STATUS_BLOCK iosb;

            //iosb.Status = 0;
            // iosb.Information = 0;

            //unsafe
            //{
            //    NativeSupportLibrary.NativeLibrary.NativeTestIoStatusBlock(ref iosb);
            //}

            //Console.WriteLine($"Iosb.Status = {iosb.Status} ({iosb.Status:X})");
            //Console.WriteLine($"Iosb.Information = {iosb.Information} ({iosb.Information:X})");

            //OBJECT_ATTRIBUTES objattr;
            //unsafe
            //{
            //    objattr.Length = sizeof(OBJECT_ATTRIBUTES);
            //    objattr.RootDirectory = IntPtr.Zero;
            //    objattr.ObjectName = &unicodeString;
            //   objattr.Attributes = 0;
            //    objattr.SecurityDescriptor = IntPtr.Zero;
            //    objattr.SecurityQualityOfService = IntPtr.Zero;

            //    NativeSupportLibrary.NativeLibrary.NativeTestObjectAttributes(ref objattr);
            //}

            LARGE_INTEGER testli = new LARGE_INTEGER();
            Console.WriteLine($"Before calling large integer native test: {testli.QuadPart}");
            NativeSupportLibrary.NativeLibrary.NativeTestLargeInteger(testli);
            Console.WriteLine($"After calling large integer native test: {testli.QuadPart}, {testli.HighPart}, {testli.LowPart}");

            Console.WriteLine("Program complete");
        }
    }
}
