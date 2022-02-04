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
                inbufferLength = (UInt32)InputBuffer.Length;
                inbuffer = Marshal.AllocHGlobal((int)inbufferLength);
                Marshal.Copy(InputBuffer, 0, inbuffer, (int)inbufferLength);
            }

            if (OutputBuffer != null && OutputBuffer.Length > 0)
            {
                outbufferLength = (UInt32)OutputBuffer.Length;
                outbuffer = Marshal.AllocHGlobal((int)outbufferLength);
            }

            status = (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtFsControlFile(
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


        //
        // This version buffers the in/out buffer.
        //
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

            if (null != OutputBuffer)
            {
                if (NtStatus.NT_SUCCESS(status) && IoStatusBlock.Information > outbufferLength)
                {
                    throw new InvalidProgramException($"How can the OS return more data than we told it we could handle? {IoStatusBlock.Information} versus {outbufferLength}");
                }
                Marshal.Copy(outbuffer, OutputBuffer, 0, (int)IoStatusBlock.Information);
            }

            return status;
        }

        //
        // This version works with explicit unmarshalled buffers
        //
        public static NtStatusCode NtDeviceIoControlFile(
            SafeFileHandle Handle,
            EVENT ev,
            APC apc,
            ref IO_STATUS_BLOCK IoStatusBlock,
            UInt32 FsControlCode,
            IntPtr InputBuffer,
            UInt32 InputBufferLength,
            IntPtr OutputBuffer,
            UInt32 OutputBufferLength)
        {
            NtStatusCode status;

            return (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtDeviceIoControlFile(
                Handle.DangerousGetHandle(),
                IntPtr.Zero,  // No Event support at present
                IntPtr.Zero,  // No APC support at present
                IntPtr.Zero,  // No APC support (context)
                IoStatusBlock,
                FsControlCode,
                InputBuffer,
                InputBufferLength,
                OutputBuffer,
                OutputBufferLength);

        }


    }
}