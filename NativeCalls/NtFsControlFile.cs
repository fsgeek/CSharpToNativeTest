using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace NativeCalls
{
    public partial class SystemCalls
    {

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

            try
            {

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

                if (((NtStatusCode.STATUS_BUFFER_OVERFLOW == IoStatusBlock.Status) || NtStatus.NT_SUCCESS(IoStatusBlock.Status)) && (OutputBuffer != null))
                {
                    if (((UInt32)IoStatusBlock.Information) < outbufferLength)
                    {
                        outbufferLength = (UInt32)IoStatusBlock.Information;
                    }

                    Marshal.Copy(outbuffer, OutputBuffer, 0, (int)outbufferLength);
                }
                else
            if (NtStatusCode.STATUS_BUFFER_OVERFLOW == IoStatusBlock.Status)
                {
                    if (null != OutputBuffer)
                    {
                        Marshal.Copy(outbuffer, OutputBuffer, 0, (int)outbufferLength);
                    }
                }

            }
            finally
            {
                if (IntPtr.Zero != inbuffer)
                {
                    Marshal.FreeHGlobal(inbuffer);
                    inbuffer = IntPtr.Zero;
                }

                if (IntPtr.Zero != outbuffer)
                {
                    Marshal.FreeHGlobal(outbuffer);
                    outbuffer = IntPtr.Zero;
                }
            }

            return status;
        }
        public static NtStatusCode NtFsControlFile(
            SafeFileHandle Handle,
            ref IO_STATUS_BLOCK IoStatusBlock,
            UInt32 FsControlCode,
            ref byte[] InputBuffer,
            ref byte[] OutputBuffer)
        {
            return NtFsControlFile(Handle, new EVENT(), new APC(), ref IoStatusBlock, FsControlCode, ref InputBuffer, ref OutputBuffer);
        }

        public static NtStatusCode NtFsControlFile(
            SafeFileHandle Handle,
            ref IO_STATUS_BLOCK IoStatusBlock,
            UInt32 FsControlCode,
            ref byte[] Buffer)
        {
            return NtFsControlFile(Handle, new EVENT(), new APC(), ref IoStatusBlock, FsControlCode, ref Buffer, ref Buffer);
        }

        public static NtStatusCode NtFsControlFile(
            SafeFileHandle Handle,
            ref IO_STATUS_BLOCK IoStatusBlock,
            UInt32 FsControlCode,
            IntPtr InputBuffer,
            UInt32 InputBufferLength,
            IntPtr OutputBuffer,
            UInt32 OutputBufferLength)
        {
            return (NtStatusCode)NativeSupportLibrary.NativeLibrary.NtFsControlFile(
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