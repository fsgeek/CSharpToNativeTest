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
            LARGE_INTEGER test_large_1 = new LARGE_INTEGER(Int64.MaxValue);
            LARGE_INTEGER test_large_2 = new LARGE_INTEGER(UInt32.MaxValue);

            Assert.AreEqual(Int64.MaxValue, test_large_1); // this tests the implicit cast operator
            Assert.AreEqual((Int32)0, test_large_2.HighPart); // make sure it was properly zeroed out

            NativeSupportLibrary.NativeLibrary.NativeTestLargeInteger(test_large_2);

            //     LargeInteger->LowPart = 1;
            // LargeInteger->HighPart = 3;

            Assert.AreEqual(3, test_large_2.HighPart);
            Assert.AreEqual(1, test_large_2.LowPart);
        }

        [TestMethod]
        public void TestIO_STATUS_BLOCK()
        {
            IO_STATUS_BLOCK iosb = new IO_STATUS_BLOCK(NativeSupportLibrary.NtStatusCodes.STATUS_RETRY, (UInt64)1);
            
            NativeSupportLibrary.NativeLibrary.NativeTestIoStatusBlock(ref iosb);
            Assert.AreEqual(iosb.Status, (int)NtStatusCodes.STATUS_BUFFER_OVERFLOW);
            Assert.AreEqual(iosb.Information, (UInt32)0x10000);
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