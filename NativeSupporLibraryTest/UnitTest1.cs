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
        public void TestUNICODE_STRING_CREATE()
        {
            UNICODE_STRING test_string = new UNICODE_STRING("foo");
            UNICODE_STRING test_string2;
            UNICODE_STRING cDrive = "\\??\\C:";

            test_string2 = ""; // check for zero length string case

            // Should not be zero
            Assert.AreNotEqual((IntPtr)test_string, IntPtr.Zero);
            // Assert.AreEqual((IntPtr)test_string2, IntPtr.Zero);

            NativeSupportLibrary.NativeLibrary.NativeTestUnicodeString(cDrive);

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