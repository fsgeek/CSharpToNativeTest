using Microsoft.VisualStudio.TestTools.UnitTesting;
using NativeSupportLibrary;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace NativeSupporLibraryTest
{

    public class TestSupport
    {
        private string _TestDirectory;

        public string TestDirectory
        {
            get { return _TestDirectory; }
        }


        TestSupport()
        {
            _TestDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        }
    }

    [TestClass]
    public class DataTypeTests
    {
        [TestMethod]
        public void TestUNICODE_STRING()
        {
            string test_string = "\\??\\C:";
            NativeSupportLibrary.NativeLibrary.print_line(test_string);

            UNICODE_STRING unicodeString = new UNICODE_STRING();
            System.IntPtr buffer = Marshal.StringToHGlobalUni(test_string);
            // IntPtr refPtr = Marshal.AllocHGlobal(8);

            // Marshal.WriteInt64(refPtr, (long)buffer);
            unicodeString.Length = (ushort)(test_string.Length * sizeof(char));
            unicodeString.MaximumLength = unicodeString.Length;
            unicodeString.Buffer = buffer;
            IntPtr ustr = Marshal.AllocHGlobal(Marshal.SizeOf(unicodeString));
            Marshal.StructureToPtr(unicodeString, ustr, true);

            unsafe
            {
                NativeSupportLibrary.NativeLibrary.NativeTestUnicodeString(&unicodeString);
            }

        }

        [TestMethod]
        public void TestLARGE_INTEGER()
        {
        }

        [TestMethod]
        public void TestIO_STATUS_BLOCK()
        {
        }

        [TestMethod]
        public void TestOBJECT_ATTRIBUTES()
        {
        }

    }

    [TestClass]
    public class SystemCallTests
    {

        [TestMethod]
        public void TestNtCreateFile()
        {

        }
    }
}