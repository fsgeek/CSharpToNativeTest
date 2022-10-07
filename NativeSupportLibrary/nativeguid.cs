using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using static NativeSupportLibrary.FILE_ID_BOTH_DIR_INFORMATION;
using System.Runtime;
using System;

namespace NativeSupportLibrary
{

    public class GUID
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _GUID
        {
            [FieldOffset(0)] public fixed byte Raw[16];
            [FieldOffset(0)] public UInt32 Data1;
            [FieldOffset(4)] public UInt16 Data2;
            [FieldOffset(6)] public UInt16 Data3;
            [FieldOffset(8)] public fixed byte Data4[8];
        }

        private _GUID _guid;
        public readonly string? Name;
        private Guid guid; // This is the C# definition/structure

        //
        // Copies the native OS GUID Foramt field into the
        // C# system defined field.
        //
        private void SetGuid()
        {
            byte[] bytes = new byte[16];

            for (var index = 0; index < bytes.Length; index++)
            {
                unsafe
                {
                    bytes[index] = _guid.Raw[index];
                }
            }
            guid = new Guid(bytes);
        }

        //
        // Copies the system defined guid field into the 
        // native OS GUID format field.
        //
        private void SetGUID()
        {
            byte[] bytes = guid.ToByteArray();
            _guid = new _GUID();
            for (var index = 0; index < bytes.Length; index++)
            {
                unsafe
                {
                    _guid.Raw[index] = bytes[index];
                }
            }
        }

        public byte[] ToArray()
        {
            byte[] buffer = new byte[16];

            for (var index = 0; index < 16; index++)
            {
                unsafe
                {
                    buffer[index] = (byte) _guid.Raw[index];
                }
            }

            return buffer;
        }

        public GUID(UInt32 l, UInt16 w1, UInt16 w2, byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7, byte b8, string? Name = null)
        {
            _guid = new _GUID();
            _guid.Data1 = l;
            _guid.Data2 = w1;
            _guid.Data3 = w2;
            unsafe
            {
                _guid.Data4[0] = b1;
                _guid.Data4[1] = b2;
                _guid.Data4[2] = b3;
                _guid.Data4[3] = b4;
                _guid.Data4[4] = b5;
                _guid.Data4[5] = b6;
                _guid.Data4[6] = b7;
                _guid.Data4[7] = b8;
            }
            SetGuid();
            this.Name = Name;
        }

        //
        // This form generates a new GUID from an existing GUID
        //
        public GUID(GUID Original, string? Name = null)
        {
            _guid = new _GUID();
            for (var index = 0; index < 16; index++)
            {
                unsafe
                {
                    _guid.Raw[index] = Original._guid.Raw[index];
                }
            }
            SetGuid();
            this.Name = Name;
        }

        //
        // This form generates a new random guid
        // It converts the system generated GUID into the native system format
        // struture.
        //
        public GUID(string? Name = null)
        {
            guid = new Guid();
            SetGUID();
            this.Name = Name;
        }

        //
        // This form takes an existing C# system Guid and sets up the native version
        // as well.
        //
        public GUID(Guid guid, string? Name = null)
        {
            this.guid = guid;
            SetGUID();
            this.Name = Name;
        }

        public GUID(IntPtr Buffer, string? Name = null)
        {
            _guid = Marshal.PtrToStructure<_GUID>(Buffer);
            SetGuid();
            this.Name = Name;
        }

        public override string ToString()
        {
            return guid.ToString();
        }

    }
}
