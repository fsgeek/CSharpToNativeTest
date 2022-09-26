using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using static NativeSupportLibrary.FILE_ID_BOTH_DIR_INFORMATION;
using static NativeSupportLibrary.FILE_ID_EXTD_BOTH_DIR_INFORMATION;
using Serilog.Debugging;

namespace NativeSupportLibrary
{
    public class ACCESS_MASK
    {
        public const UInt32 DELETE = (UInt32)0x00010000;
        public const UInt32 READ_CONTROL = (UInt32)0x00020000;
        public const UInt32 WRITE_DAC = (UInt32)0x00040000;
        public const UInt32 WRITE_OWNER = (UInt32)0x00080000;
        public const UInt32 SYNCHRONIZE = (UInt32)0x00100000;

        public const UInt32 STANDARD_RIGHTS_REQUIRED = (UInt32)0x000F0000;
        public const UInt32 STANDARD_RIGHTS_READ = READ_CONTROL;
        public const UInt32 STANDARD_RIGHTS_WRITE = READ_CONTROL;
        public const UInt32 STANDARD_RIGHTS_EXECUTE = READ_CONTROL;
        public const UInt32 STANDARD_RIGHTS_ALL = (UInt32)0x001F0000;

        public const UInt32 SPECIFIC_RIGHTS_ALL = (UInt32)0x0000FFFF;

        public const UInt32 ACCESS_SYSTEM_SECURITY = (UInt32)0x01000000;

        public const UInt32 MAXIMUM_ALLOWED = (UInt32)0x02000000;

        public const UInt32 GENERIC_READ = (UInt32)0x80000000;
        public const UInt32 GENERIC_WRITE = (UInt32)0x40000000;
        public const UInt32 GENERIC_EXECUTE = (UInt32)0x20000000;
        public const UInt32 GENERIC_ALL = (UInt32)0x10000000;

        protected UInt32 _AccessMask = 0;

        public static implicit operator UInt32(ACCESS_MASK mask)
        {
            return mask._AccessMask;
        }

        public static implicit operator ACCESS_MASK(UInt32 mask)
        {
            return new ACCESS_MASK(mask);
        }

        public ACCESS_MASK(UInt32 Mask)
        {
            _AccessMask = Mask;
        }

        public ACCESS_MASK()
        {
            _AccessMask = 0;
        }

    }
}