using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace NativeCalls
{
    public class SystemCalls
    {
        public static NtStatusCode NtCreateFile(ref SafeFileHandle Handle, ACCESS_MASK accessMask, OBJECT_ATTRIBUTES ObjectAttributes, ref IO_STATUS_BLOCK Iosb, LARGE_INTEGER AllocationSize, FILE_ATTRIBUTES FileAttributes, SHARE_ACCESS ShareAccess, CREATE_DISPOSITION Disposition, CREATE_OPTIONS Options, EXTENDED_ATTRIBUTE EA)
        {
            IntPtr handle = IntPtr.Zero;
            NtStatusCode status;

            status = (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtCreateFile(ref handle, accessMask, ObjectAttributes, Iosb, AllocationSize, FileAttributes, ShareAccess, Disposition, Options, EA, EA.Length);

            Handle = new SafeFileHandle(handle, true);

            return status;
        }

        public static NtStatusCode NtClose(ref SafeFileHandle Handle)
        {
            Handle.Close();

            return NtStatusCode.STATUS_SUCCESS;
        }

        public static NtStatusCode NtFsControlFile(
            SafeFileHandle Handle,
            EVENT ev,
            APC apc,
            ref IO_STATUS_BLOCK IoStatusBlock,
            UInt32 FsControlCode,
            ref byte[] InputBuffer,
            ref byte[] OutputBuffer)
        {
            NtStatusCode status;
            IntPtr inbuffer = IntPtr.Zero;
            UInt32 inbufferLength = 0;
            IntPtr outbuffer = Marshal.AllocHGlobal(OutputBuffer.Length);
            UInt32 outbufferLength = 0;

            if (InputBuffer != null && InputBuffer.Length > 0)
            {
                inbufferLength = (UInt32) InputBuffer.Length;
                inbuffer = Marshal.AllocHGlobal((int)inbufferLength);
                Marshal.Copy(InputBuffer, 0, inbuffer, (int)inbufferLength);
            }

            if (OutputBuffer != null && OutputBuffer.Length > 0)
            {
                outbufferLength = (UInt32) OutputBuffer.Length;
                outbuffer = Marshal.AllocHGlobal((int)outbufferLength);
            }

            status = (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtFsControlFile(
                Handle.DangerousGetHandle() , 
                IntPtr.Zero,  // No Event support at present
                IntPtr.Zero,  // No APC support at present
                IntPtr.Zero,  // No APC support (context)
                IoStatusBlock,
                FsControlCode,
                inbuffer,
                inbufferLength,
                outbuffer,
                outbufferLength);

            return status;
        }

        public static NtStatusCode NtDeviceIoControlFile(
            SafeFileHandle Handle,
            EVENT ev,
            APC apc,
            ref IO_STATUS_BLOCK IoStatusBlock,
            UInt32 FsControlCode,
            ref byte[] InputBuffer,
            ref byte[] OutputBuffer)
        {
            NtStatusCode status;
            IntPtr inbuffer = IntPtr.Zero;
            UInt32 inbufferLength = 0;
            IntPtr outbuffer = Marshal.AllocHGlobal(OutputBuffer.Length);
            UInt32 outbufferLength = 0;

            if (InputBuffer != null && InputBuffer.Length > 0)
            {
                inbufferLength = (UInt32)InputBuffer.Length;
                inbuffer = Marshal.AllocHGlobal((int)inbufferLength);
                Marshal.Copy(InputBuffer, 0, inbuffer, (int)inbufferLength);
            }

            if (OutputBuffer != null && OutputBuffer.Length > 0)
            {
                outbufferLength = (UInt32)OutputBuffer.Length;
                outbuffer = Marshal.AllocHGlobal((int)outbufferLength);
            }

            status = (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtDeviceIoControlFile(
                Handle.DangerousGetHandle(),
                IntPtr.Zero,  // No Event support at present
                IntPtr.Zero,  // No APC support at present
                IntPtr.Zero,  // No APC support (context)
                IoStatusBlock,
                FsControlCode,
                inbuffer,
                inbufferLength,
                outbuffer,
                outbufferLength);

            return status;
        }

    }
}