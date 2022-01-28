using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;

namespace PInvokeTest
{
    class Program
    {


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct OBJECT_ATTRIBUTES
        {
            public Int32 Length;
            public IntPtr RootDirectory;
            public IntPtr ObjectName;
            public Int32 Attributes;
            public Int32 SecurityDescriptor;
            public Int32 SecurityQualityOfService;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public unsafe partial struct UNICODE_STRING_OLD
        {
            public ushort Length;
            public ushort MaximumLength;
            public IntPtr Buffer;
        }

        class UNICODE_STRING
        {
            [StructLayout(LayoutKind.Sequential,Pack = 1)]
            private struct NATIVE_UNICODE_STRING
            {
                public ushort Length;
                public ushort MaximumLength;
                public IntPtr Buffer;
            }

            private NATIVE_UNICODE_STRING nativeString;
            private IntPtr nativeStringForExport;

            public IntPtr GetNativeString()
            {
                return nativeStringForExport;
            }

            public IntPtr GetNativeStringBuffer()
            {
                return nativeString.Buffer;
            }

            public ushort Length { get;  }
            public ushort MaximumLength { get;  }
            public string Buffer
            {
                get
                {
                    return Buffer;
                }

                set
                {
                    if (IntPtr.Zero != nativeString.Buffer)
                    {
                        Marshal.FreeHGlobal(nativeString.Buffer);
                    }
                    nativeString.Length = (ushort)(sizeof(Char) * value.Length);
                    nativeString.MaximumLength = (ushort)(nativeString.Length + sizeof(Char));
                    Marshal.WriteInt64(nativeString.Buffer, (long) Marshal.StringToHGlobalUni(value));
                    
                    if (IntPtr.Zero != nativeStringForExport)
                    {
                        Marshal.FreeHGlobal(nativeStringForExport);
                    }
                    unsafe
                    {
                        nativeStringForExport = Marshal.AllocHGlobal(sizeof(NATIVE_UNICODE_STRING));
                    }
                    Marshal.StructureToPtr(nativeString, nativeStringForExport, true);
                }
            }

            public UNICODE_STRING(string str)
            {
                if (null != str)
                {
                    nativeString.Length = (ushort)(sizeof(Char) * str.Length);
                    nativeString.MaximumLength = (ushort)(sizeof(Char) * (1 + str.Length));
                    Marshal.WriteInt64(nativeString.Buffer, (long)Marshal.StringToHGlobalUni(str));
                    unsafe
                    {
                        nativeStringForExport = Marshal.AllocHGlobal(sizeof(NATIVE_UNICODE_STRING));
                    }
                    Marshal.StructureToPtr(nativeString, nativeStringForExport, true);
                    Console.WriteLine($"unmanaged buffer at {nativeString.Buffer:X}");
                    Console.WriteLine($"External structure at {nativeStringForExport:X}");
                }
            }

            ~UNICODE_STRING()
            {
                if (IntPtr.Zero != nativeStringForExport)
                {
                    Marshal.FreeHGlobal((IntPtr)nativeStringForExport);
                    nativeStringForExport = IntPtr.Zero;
                }

                if (IntPtr.Zero != nativeString.Buffer)
                {
                    Marshal.FreeHGlobal(nativeString.Buffer);
                    nativeString.Buffer = IntPtr.Zero;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IO_STATUS_BLOCK
        {
            public UInt32 Status;
            public UInt64 Information;
        }

        static void Main(string[] args)
        {
            print_line("Hello, PInvoke!");
            string test_string = "\\??\\C:";

            int status = 0;

            [DllImport("NativeLibrary.dll")]
            static extern int NtCreateFile(
                out Microsoft.Win32.SafeHandles.SafeFileHandle handle,
                FileAccess access,
                ref OBJECT_ATTRIBUTES objectAttributes,
                ref IO_STATUS_BLOCK ioStatus,
                ref long allocSize,
                uint fileAttributes,
                FileShare share,
                uint createDisposition,
                uint createOptions,
                IntPtr eaBuffer,
                uint eaLength);

            UNICODE_STRING ustr = new UNICODE_STRING(test_string);

            unsafe
            {
                    [DllImport("NativeLibrary.dll")]
                    static extern int NativeTestUnicodeString(IntPtr str);

                Console.WriteLine($"C# sending native string at {ustr.GetNativeString():X}");
               
                    status = NativeTestUnicodeString(ustr.GetNativeString());
            }

            Console.WriteLine($"Status is {status}");
        }

        [DllImport("NativeLibrary.dll")]
        private static extern void print_line(string str);

        [DllImport("NativeLibrary.dll")]
        private static extern int NtCreateFile(
                        out Microsoft.Win32.SafeHandles.SafeFileHandle handle,
            FileAccess access,
            ref OBJECT_ATTRIBUTES objectAttributes,
            ref IO_STATUS_BLOCK ioStatus,
            ref long allocSize,
            uint fileAttributes,
            FileShare share,
            uint createDisposition,
            uint createOptions,
            IntPtr eaBuffer,
            uint eaLength);


    }
}