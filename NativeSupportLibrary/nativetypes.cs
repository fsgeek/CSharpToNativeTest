using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace NativeSupportLibrary
{
    [StructLayout(LayoutKind.Explicit)]
    struct LARGE_INTEGER
    {
        [FieldOffset(0)] UInt64 QuadPart;
        [FieldOffset(0)] UInt32 LowPart;
        [FieldOffset(4)] UInt32 HighPart;
    }

    public class ACCESS_MASK
    {
        public const ulong DELETE = 0x00010000L;
        public const ulong READ_CONTROL = 0x00020000L;
        public const ulong WRITE_DAC = 0x00040000L;
        public const ulong WRITE_OWNER = 0x00080000L;
        public const ulong SYNCHRONIZE = 0x00100000L;

        public const ulong STANDARD_RIGHTS_REQUIRED = 0x000F0000L;
        public const ulong STANDARD_RIGHTS_READ = READ_CONTROL;
        public const ulong STANDARD_RIGHTS_WRITE = READ_CONTROL;
        public const ulong STANDARD_RIGHTS_EXECUTE = READ_CONTROL;
        public const ulong STANDARD_RIGHTS_ALL = 0x001F0000L;

        public const ulong SPECIFIC_RIGHTS_ALL = 0x0000FFFFL;

        public const ulong ACCESS_SYSTEM_SECURITY = 0x01000000L;

        public const ulong MAXIMUM_ALLOWED = 0x02000000L;

        public const ulong GENERIC_READ = 0x80000000L;
        public const ulong GENERIC_WRITE = 0x40000000L;
        public const ulong GENERIC_EXECUTE = 0x20000000L;
        public const ulong GENERIC_ALL = 0x10000000L;
    }

    public class FILE_ACCESS_MASK : ACCESS_MASK
    {
        // Files
        public const ulong FILE_READ_DATA = 0x0001;
        public const ulong FILE_WRITE_DATA = 0x0002;
        public const ulong FILE_APPEND_DATA = 0x0004;
        public const ulong FILE_EXECUTE = 0x0020;

        // Directories
        public const ulong FILE_LIST_DIRECTORY = 0x0001;
        public const ulong FILE_ADD_FILE = 0x0002;
        public const ulong FILE_ADD_SUBDIRECTORY = 0x0004;
        public const ulong FILE_CREATE_PIPE_INSTANCE = 0x0004;
        public const ulong FILE_TRAVERSE = 0x0020;
        public const ulong FILE_DELETE_CHILD = 0x0040;

        // Both files & directories
        public const ulong FILE_READ_EA = 0x0008;
        public const ulong FILE_WRITE_EA = 0x0010;
        public const ulong FILE_READ_ATTRIBUTES = 0x0080;
        public const ulong FILE_WRITE_ATTRIBUTES = 0x0100;

        public const ulong FILE_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | FILE_READ_ATTRIBUTES | FILE_READ_EA | SYNCHRONIZE;
        public const ulong FILE_GENERIC_READ = STANDARD_RIGHTS_ALL | FILE_READ_DATA | FILE_READ_ATTRIBUTES | FILE_READ_EA | SYNCHRONIZE;
        public const ulong FILE_GENERIC_WRITE = STANDARD_RIGHTS_WRITE | FILE_WRITE_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_EA | FILE_APPEND_DATA | SYNCHRONIZE;
        public const ulong FILE_GENERIC_EXECUTE = STANDARD_RIGHTS_EXECUTE | FILE_READ_ATTRIBUTES | FILE_EXECUTE | SYNCHRONIZE;
    }

    public class UNICODE_STRING
    {
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct _UNICODE_STRING
        {
            public ushort Length = 0;
            public ushort MaximumLength = 0;
            public IntPtr Buffer = IntPtr.Zero;
        }

        private _UNICODE_STRING unicode_string;
        private IntPtr native_str = IntPtr.Zero;

        // private IntPtr _Buffer;
        // private IntPtr _

        /* 
         *             UNICODE_STRING unicodeString = new UNICODE_STRING();
        IntPtr buffer = Marshal.StringToHGlobalUni(test_string);
        // IntPtr refPtr = Marshal.AllocHGlobal(8);

        // Marshal.WriteInt64(refPtr, (long)buffer);
        unicodeString.Length = (ushort)(test_string.Length * sizeof(char));
        unicodeString.MaximumLength = unicodeString.Length;
        unicodeString.Buffer = buffer;
        IntPtr ustr = Marshal.AllocHGlobal(Marshal.SizeOf(unicodeString));
        Marshal.StructureToPtr(unicodeString, ustr, true);

         */

        public static implicit operator IntPtr(UNICODE_STRING ustr)
        {
            return ustr.native_str;
        }

        public static implicit operator UNICODE_STRING(string str)
        {
            return new UNICODE_STRING(str);
        }

        public UNICODE_STRING(string str)
        {
            if ((str != null) && (str.Length > 0))
            {
                // This is a non-zero length string
                unicode_string.Length = (ushort)(str.Length * sizeof(char));
                unicode_string.MaximumLength = unicode_string.Length;
                unicode_string.Buffer = Marshal.StringToHGlobalUni(str);
            }
            else
            {
                // The string is zero length, so no need to allocate space
                // for the string.
                unicode_string.Length = 0;
                unicode_string.MaximumLength= 0;
                unicode_string.Buffer = IntPtr.Zero;
            }

            // in either case, we allocate space for the string structure.
            native_str = Marshal.AllocHGlobal(Marshal.SizeOf(unicode_string));
            Marshal.StructureToPtr(unicode_string, native_str, true);

        }

        ~UNICODE_STRING()
        {
            if (native_str != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(native_str);
                native_str = IntPtr.Zero;
            }

            if (unicode_string.Buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(unicode_string.Buffer);
                unicode_string.Length = 0;
                unicode_string.MaximumLength = 0;
                unicode_string.Buffer = IntPtr.Zero;
            }
        }
    }

    public class OBJECT_PROPERTIES
    {
        const UInt32 OBJ_INHERIT = 0x00000002;
        const UInt32 OBJ_PERMANENT = 0x00000010;
        const UInt32 OBJ_EXCLUSIVE = 0x00000020;
        const UInt32 OBJ_CASE_INSENSITIVE = 0x00000040;
        const UInt32 OBJ_OPENIF = 0x00000080;
        const UInt32 OBJ_OPENLINK = 0x00000100;
        const UInt32 OBJ_KERNEL_HANDLE = 0x00000200;
        const UInt32 OBJ_FORCE_ACCESS_CHECK = 0x00000400;
        const UInt32 OBJ_IGNORE_IMPERSONATED_DEVICEMAP = 0x00000800;
        const UInt32 OBJ_DONT_REPARSE = 0x00001000;
        const UInt32 OBJ_VALID_ATTRIBUTES = 0x00001FF2;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public unsafe struct OBJECT_ATTRIBUTES
    {
        public Int32 Length = 0;
        public IntPtr RootDirectory = IntPtr.Zero;
        public IntPtr ObjectName;
        public UInt32 Attributes; // see OBJECT_PROPERTIES
        public IntPtr SecurityDescriptor;
        public IntPtr SecurityQualityOfService;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IO_STATUS_BLOCK
    {
        public uint Status;
        public ulong Information;
    }

}
