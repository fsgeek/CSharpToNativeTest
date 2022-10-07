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
using Serilog.Debugging;

namespace NativeSupportLibrary
{
    #region enum
    public enum DIRECTORY_NOTIFY_INFORMATION_CLASS
    {
        DirectoryNotifyInformation = 1,
        DirectoryNotifyExtendedInformation, // 2
        DirectoryNotifyFullInformation,     // 3
    }

    #endregion

    #region enum
    // {Query/SetInformationFile} types (structures correspond to these types usually)
    public enum FILE_INFORMATION_CLASS
    {
        FileDirectoryInformation = 1,     // 1
        FileFullDirectoryInformation = 2,     // 2
        FileBothDirectoryInformation = 3,     // 3
        FileBasicInformation = 4,         // 4
        FileStandardInformation = 5,      // 5
        FileInternalInformation = 6,      // 6
        FileEaInformation = 7,        // 7
        FileAccessInformation = 8,        // 8
        FileNameInformation = 9,          // 9
        FileRenameInformation = 10,        // 10
        FileLinkInformation = 11,          // 11
        FileNamesInformation = 12,         // 12
        FileDispositionInformation = 13,       // 13
        FilePositionInformation = 14,      // 14
        FileFullEaInformation = 15,        // 15
        FileModeInformation = 16,     // 16
        FileAlignmentInformation = 17,     // 17
        FileAllInformation = 18,           // 18
        FileAllocationInformation = 19,    // 19
        FileEndOfFileInformation = 20,     // 20
        FileAlternateNameInformation = 21,     // 21
        FileStreamInformation = 22,        // 22
        FilePipeInformation = 23,          // 23
        FilePipeLocalInformation = 24,     // 24
        FilePipeRemoteInformation = 25,    // 25
        FileMailslotQueryInformation = 26,     // 26
        FileMailslotSetInformation = 27,       // 27
        FileCompressionInformation = 28,       // 28
        FileObjectIdInformation = 29,      // 29
        FileCompletionInformation = 30,    // 30
        FileMoveClusterInformation = 31,       // 31
        FileQuotaInformation = 32,         // 32
        FileReparsePointInformation = 33,      // 33
        FileNetworkOpenInformation = 34,       // 34
        FileAttributeTagInformation = 35,      // 35
        FileTrackingInformation = 36,      // 36
        FileIdBothDirectoryInformation = 37,   // 37
        FileIdFullDirectoryInformation = 38,   // 38
        FileValidDataLengthInformation = 39,   // 39
        FileShortNameInformation = 40,     // 40
        FileIoCompletionNotificationInformation = 41,        // 41
        FileIoStatusBlockRangeInformation = 42,              // 42
        FileIoPriorityHintInformation = 43,                  // 43
        FileSfioReserveInformation = 44,                     // 44
        FileSfioVolumeInformation = 45,                      // 45
        FileHardLinkInformation = 46,    // 46
        FileProcessIdsUsingFileInformation = 47,             // 47
        FileNormalizedNameInformation = 48,                  // 48
        FileNetworkPhysicalNameInformation = 49,             // 49
        FileIdGlobalTxDirectoryInformation = 50,             // 50
        FileIsRemoteDeviceInformation = 51,                  // 51
        FileUnusedInformation = 52,                          // 52
        FileNumaNodeInformation = 53,                        // 53
        FileStandardLinkInformation = 54,                    // 54
        FileRemoteProtocolInformation = 55,                  // 55

        //FILE_NAME
        //  These are special versions of these operations (defined earlier)
        //  which can be used by kernel mode drivers only to bypass security
        //  access checks for Rename and HardLink operations.  These operations
        //  are only recognized by the IOManager, a file system should never
        //  receive these.
        //

        FileRenameInformationBypassAccessCheck = 56,         // 56
        FileLinkInformationBypassAccessCheck = 57,           // 57

        //
        // End of special information classes reserved for IOManager.
        //

        FileVolumeNameInformation = 58,                      // 58
        FileIdInformation = 59,                              // 59
        FileIdExtdDirectoryInformation = 60,                 // 60
        FileReplaceCompletionInformation = 61,               // 61
        FileHardLinkFullIdInformation = 62,                  // 62
        FileIdExtdBothDirectoryInformation = 63,             // 63
        FileDispositionInformationEx = 64,                   // 64
        FileRenameInformationEx = 65,                        // 65
        FileRenameInformationExBypassAccessCheck = 66,       // 66
        FileDesiredStorageClassInformation = 67,             // 67
        FileStatInformation = 68,                            // 68
        FileMemoryPartitionInformation = 69,                 // 69
        FileStatLxInformation = 70,                          // 70
        FileCaseSensitiveInformation = 71,                   // 71
        FileLinkInformationEx = 72,                          // 72
        FileLinkInformationExBypassAccessCheck = 73,         // 73
        FileStorageReserveIdInformation = 74,                // 74
        FileCaseSensitiveInformationForceAccessCheck = 75,   // 75
        FileKnownFolderInformation = 76,                     // 76
    }
    #endregion



    public class FILE_ATTRIBUTES
    {
        public const UInt32 READONLY = 0x00000001;
        public const UInt32 HIDDEN = 0x00000002;
        public const UInt32 SYSTEM = 0x00000004;
        public const UInt32 DIRECTORY = 0x00000010;
        public const UInt32 ARCHIVE = 0x00000020;
        public const UInt32 DEVICE = 0x00000040;
        public const UInt32 NORMAL = 0x00000080;
        public const UInt32 TEMPORARY = 0x00000100;
        public const UInt32 SPARSE_FILE = 0x00000200;
        public const UInt32 REPARSE_POINT = 0x00000400;
        public const UInt32 COMPRESSED = 0x00000800;
        public const UInt32 OFFLINE = 0x00001000;
        public const UInt32 NOT_CONTENT_INDEXED = 0x00002000;
        public const UInt32 ENCRYPTED = 0x00004000;
        public const UInt32 INTEGRITY_STREAM = 0x00008000;
        public const UInt32 VIRTUAL = 0x00010000;
        public const UInt32 NO_SCRUB_DATA = 0x00020000;
        public const UInt32 EA = 0x00040000;
        public const UInt32 PINNED = 0x00080000;
        public const UInt32 UNPINNED = 0x00100000;
        public const UInt32 RECALL_ON_OPEN = 0x00040000;
        public const UInt32 RECALL_ON_DATA_ACCESS = 0x00400000;
        public const UInt32 STRICTLY_SEQUENTIAL = 0x20000000;
        public const UInt32 VALID_SET_FLAGS = 0x001a31a7;

        UInt32 _FileAttribute;

        public static implicit operator UInt32(FILE_ATTRIBUTES attributes)
        {
            return attributes._FileAttribute;
        }

        public static implicit operator FILE_ATTRIBUTES(UInt32 value)
        {
            return new FILE_ATTRIBUTES(value);
        }

        public FILE_ATTRIBUTES(UInt32 value = 0)
        {
            _FileAttribute = value;
        }

        public static string ToString(FILE_ATTRIBUTES attributes)
        {
            string attrs = "";
            bool initial = true;

            if (0 != (attributes & READONLY))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "READONLY";
            }

            if (0 != (attributes & HIDDEN))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "HIDDEN";
            }

            if (0 != (attributes & SYSTEM))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "SYSTEM";
            }

            if (0 != (attributes & DIRECTORY))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "DIRECTORY";
            }

            if (0 != (attributes & ARCHIVE))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "ARCHIVE";
            }

            if (0 != (attributes & DEVICE))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "DEVICE";
            }

            if (0 != (attributes & NORMAL))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "NORMAL";
            }

            if (0 != (attributes & TEMPORARY))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "TEMPORARY";
            }

            if (0 != (attributes & SPARSE_FILE))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "SPARSE_FILE";
            }

            if (0 != (attributes & REPARSE_POINT))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "REPARSE_POINT";
            }

            if (0 != (attributes & COMPRESSED))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "COMPRESSED";
            }

            if (0 != (attributes & OFFLINE))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "OFFLINE";
            }

            if (0 != (attributes & NOT_CONTENT_INDEXED))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "NOT_CONTENT_INDEXED";
            }

            if (0 != (attributes & ENCRYPTED))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "ENCRYPTED";
            }

            if (0 != (attributes & INTEGRITY_STREAM))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "INTEGRITY_STREAM";
            }

            if (0 != (attributes & VIRTUAL))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "VIRTUAL";
            }

            if (0 != (attributes & NO_SCRUB_DATA))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "NO_SCRUB_DATA";
            }

            if (0 != (attributes & EA))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "EA";
            }

            if (0 != (attributes & PINNED))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "PINNED";
            }

            if (0 != (attributes & UNPINNED))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "UNPINNED";
            }

            if (0 != (attributes & RECALL_ON_OPEN))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "RECALL_ON_OPEN";
            }

            if (0 != (attributes & RECALL_ON_DATA_ACCESS))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "RECALL_ON_DATA_ACCESS";
            }

            if (0 != (attributes & STRICTLY_SEQUENTIAL))
            {
                if (!initial)
                {
                    attrs += "|";
                }
                initial = false;
                attrs += "STRICTLY_SEQUENTIAL";
            }

            return attrs;

        }

    }

    // SHARE_ACCESS ShareAccess, CREATE_DISPOSITION Disposition, EXTENDED_ATTRIBUTE EA);

    public class SHARE_ACCESS
    {
        public const UInt32 FILE_SHARE_READ = 0x00000001;
        public const UInt32 FILE_SHARE_WRITE = 0x00000002;
        public const UInt32 FILE_SHARE_DELETE = 0x00000004;

        private UInt32 _ShareAccess = 0;

        public static implicit operator UInt32(SHARE_ACCESS access)
        {
            return access._ShareAccess;
        }

        public static implicit operator SHARE_ACCESS(UInt32 Sharing)
        {
            return new SHARE_ACCESS(Sharing);
        }

        public SHARE_ACCESS(UInt32 Sharing = 0)
        {
            _ShareAccess = Sharing;
        }
    }

    public class CREATE_DISPOSITION
    {

        public const UInt32 FILE_SUPERSEDE = (UInt32)0x00000000;
        public const UInt32 FILE_OPEN = (UInt32)0x00000001;
        public const UInt32 FILE_CREATE = (UInt32)0x00000002;
        public const UInt32 FILE_OPEN_IF = (UInt32)0x00000003;
        public const UInt32 FILE_OVERWRITE = (UInt32)0x00000004;
        public const UInt32 FILE_OVERWRITE_IF = (UInt32)0x00000005;

        private UInt32 _CreateDisposition;

        public static implicit operator UInt32(CREATE_DISPOSITION disposition)
        {
            return disposition._CreateDisposition;
        }

        public static implicit operator CREATE_DISPOSITION(UInt32 Disposition)
        {
            return new CREATE_DISPOSITION(Disposition);
        }

        public CREATE_DISPOSITION(UInt32 Disposition = 0)
        {
            _CreateDisposition = Disposition;
        }
    }

    public class CREATE_OPTIONS
    {
        public const UInt32 FILE_DIRECTORY_FILE = 0x00000001;
        public const UInt32 FILE_WRITE_THROUGH = 0x00000002;
        public const UInt32 FILE_SEQUENTIAL_ONLY = 0x00000004;
        public const UInt32 FILE_NO_INTERMEDIATE_BUFFERING = 0x00000008;
        public const UInt32 FILE_SYNCHRONOUS_IO_ALERT = 0x00000010;
        public const UInt32 FILE_SYNCHRONOUS_IO_NONALERT = 0x00000020;
        public const UInt32 FILE_NON_DIRECTORY_FILE = 0x00000040;
        public const UInt32 FILE_CREATE_TREE_CONNECTION = 0x00000080;
        public const UInt32 FILE_COMPLETE_IF_OPLOCKED = 0x00000100;
        public const UInt32 FILE_NO_EA_KNOWLEDGE = 0x00000200;
        public const UInt32 FILE_OPEN_REMOTE_INSTANCE = 0x00000400;
        public const UInt32 FILE_RANDOM_ACCESS = 0x00000800;
        public const UInt32 FILE_DELETE_ON_CLOSE = 0x00001000;
        public const UInt32 FILE_OPEN_BY_FILE_ID = 0x00002000;
        public const UInt32 FILE_OPEN_FOR_BACKUP_INTENT = 0x00004000;
        public const UInt32 FILE_NO_COMPRESSION = 0x00008000;
        public const UInt32 FILE_OPEN_REQUIRING_OPLOCK = 0x00010000;
        public const UInt32 FILE_DISALLOW_EXCLUSIVE = 0x00020000;
        public const UInt32 FILE_SESSION_AWARE = 0x00040000;
        public const UInt32 FILE_RESERVE_OPFILTER = 0x00100000;
        public const UInt32 FILE_OPEN_REPARSE_POINT = 0x00200000;
        public const UInt32 FILE_OPEN_NO_RECALL = 0x00400000;
        public const UInt32 FILE_OPEN_FOR_FREE_SPACE_QUERY = 0x00800000;

        private UInt32 _CreateOptions;

        public static implicit operator UInt32(CREATE_OPTIONS options)
        {
            return options._CreateOptions;
        }

        public static implicit operator CREATE_OPTIONS(UInt32 options)
        {
            return new CREATE_OPTIONS(options);
        }

        public CREATE_OPTIONS(UInt32 Options = 0)
        {
            _CreateOptions = Options;
        }

    }

    public class IO_STATUS_BLOCK_CREATE_DISPOSITION
    {
        public const UInt32 FILE_SUPERSEDED = 0x00000000;
        public const UInt32 FILE_OPENED = 0x00000001;
        public const UInt32 FILE_CREATED = 0x00000002;
        public const UInt32 FILE_OVERWRITTEN = 0x00000003;
        public const UInt32 FILE_EXISTS = 0x00000004;
        public const UInt32 FILE_DOES_NOT_EXIST = 0x00000005;

    }

    public class EXTENDED_ATTRIBUTE
    {
        private Dictionary<string, byte[]> EaEntries = new Dictionary<string, byte[]>();

        // TODO: implement this for real

        public static implicit operator IntPtr(EXTENDED_ATTRIBUTE ea)
        {
            // TODO: need to marshal the EAs
            return IntPtr.Zero;
        }

        // TODO implement this.
        public UInt32 Length = 0;
    }

    public class LARGE_INTEGER
    {
        [StructLayout(LayoutKind.Explicit)]
        private struct _LARGE_INTEGER
        {
            [FieldOffset(0)] public Int64 QuadPart = 0;
            [FieldOffset(0)] public UInt32 LowPart = 0;
            [FieldOffset(4)] public Int32 HighPart = 0;

            public _LARGE_INTEGER()
            {
            }
        }

        private _LARGE_INTEGER large_integer;
        IntPtr buffer = IntPtr.Zero;

        public Int64 QuadPart
        {
            get
            {
                large_integer = Marshal.PtrToStructure<_LARGE_INTEGER>(buffer);
                return large_integer.QuadPart;
            }
            set
            {
                large_integer.QuadPart = value;
                Marshal.StructureToPtr(large_integer, buffer, true);
            }
        }

        public Int32 HighPart
        {
            get
            {
                large_integer = Marshal.PtrToStructure<_LARGE_INTEGER>(buffer);
                return large_integer.HighPart;
            }

            set
            {
                large_integer.HighPart = value;
                Marshal.StructureToPtr(large_integer, buffer, true);
            }
        }

        public UInt32 LowPart
        {
            get
            {
                large_integer = Marshal.PtrToStructure<_LARGE_INTEGER>(buffer);
                return large_integer.LowPart;
            }


            set
            {
                large_integer.LowPart = value; ;
                Marshal.StructureToPtr(large_integer, buffer, true);
            }
        }


        public LARGE_INTEGER(Int64 value)
        {
            large_integer = new _LARGE_INTEGER();
            large_integer.QuadPart = value;
            unsafe
            {
                buffer = Marshal.AllocHGlobal(sizeof(_LARGE_INTEGER));
            }
            Marshal.StructureToPtr(large_integer, buffer, true);
        }

        public LARGE_INTEGER(UInt32 value)
        {
            large_integer = new _LARGE_INTEGER();
            large_integer.HighPart = 0;
            large_integer.LowPart = value;
            unsafe
            {
                buffer = Marshal.AllocHGlobal(sizeof(_LARGE_INTEGER));
            }
            Marshal.StructureToPtr(large_integer, buffer, true);
        }

        public LARGE_INTEGER(Int32 HighPart, UInt32 LowPart)
        {
            large_integer = new _LARGE_INTEGER();
            large_integer.HighPart = HighPart;
            large_integer.LowPart = LowPart;
            unsafe
            {
                buffer = Marshal.AllocHGlobal(sizeof(_LARGE_INTEGER));
            }
            Marshal.StructureToPtr(large_integer, buffer, true);
        }

        public LARGE_INTEGER()
        {
            large_integer = new _LARGE_INTEGER();
            unsafe
            {
                buffer = Marshal.AllocHGlobal(sizeof(_LARGE_INTEGER));
            }
            Marshal.StructureToPtr(large_integer, buffer, true);
        }

        ~LARGE_INTEGER()
        {
            if (IntPtr.Zero != buffer)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }
        }

        public static implicit operator Int64(LARGE_INTEGER value)
        {
            return value.QuadPart;
        }

        public static implicit operator UInt32(LARGE_INTEGER value)
        {
            return value.LowPart;
        }

        public static implicit operator LARGE_INTEGER(Int64 value)
        {
            return new LARGE_INTEGER(value);
        }

        public static implicit operator LARGE_INTEGER(UInt32 value)
        {
            return new LARGE_INTEGER(value);
        }

        public static implicit operator IntPtr(LARGE_INTEGER value)
        {
            return value.buffer;
        }
    }

    public class FILE_ACCESS_MASK : ACCESS_MASK
    {
        // Files
        public const UInt32 FILE_READ_DATA = (UInt32)0x0001;
        public const UInt32 FILE_WRITE_DATA = (UInt32)0x0002;
        public const UInt32 FILE_APPEND_DATA = (UInt32)0x0004;
        public const UInt32 FILE_EXECUTE = (UInt32)0x0020;

        // Directories
        public const UInt32 FILE_LIST_DIRECTORY = (UInt32)0x0001;
        public const UInt32 FILE_ADD_FILE = (UInt32)0x0002;
        public const UInt32 FILE_ADD_SUBDIRECTORY = (UInt32)0x0004;
        public const UInt32 FILE_CREATE_PIPE_INSTANCE = (UInt32)0x0004;
        public const UInt32 FILE_TRAVERSE = (UInt32)0x0020;
        public const UInt32 FILE_DELETE_CHILD = (UInt32)0x0040;

        // Both files & directories
        public const UInt32 FILE_READ_EA = (UInt32)0x0008;
        public const UInt32 FILE_WRITE_EA = (UInt32)0x0010;
        public const UInt32 FILE_READ_ATTRIBUTES = (UInt32)0x0080;
        public const UInt32 FILE_WRITE_ATTRIBUTES = (UInt32)0x0100;

        public const ulong FILE_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | FILE_READ_ATTRIBUTES | FILE_READ_EA | SYNCHRONIZE;
        public const ulong FILE_GENERIC_READ = STANDARD_RIGHTS_ALL | FILE_READ_DATA | FILE_READ_ATTRIBUTES | FILE_READ_EA | SYNCHRONIZE;
        public const ulong FILE_GENERIC_WRITE = STANDARD_RIGHTS_WRITE | FILE_WRITE_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_EA | FILE_APPEND_DATA | SYNCHRONIZE;
        public const ulong FILE_GENERIC_EXECUTE = STANDARD_RIGHTS_EXECUTE | FILE_READ_ATTRIBUTES | FILE_EXECUTE | SYNCHRONIZE;

        public static implicit operator UInt32(FILE_ACCESS_MASK mask)
        {
            return mask._AccessMask;
        }

        public static implicit operator FILE_ACCESS_MASK(UInt32 mask)
        {
            return new FILE_ACCESS_MASK(mask);
        }


        public FILE_ACCESS_MASK()
        {
            _AccessMask = 0;
        }

        public FILE_ACCESS_MASK(UInt32 Mask)
        {
            _AccessMask = Mask;
        }
    }

    public class UNICODE_STRING
    {
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct _UNICODE_STRING
        {
            public ushort Length = 0;
            public ushort MaximumLength = 0;
            public IntPtr Buffer = IntPtr.Zero;

            public _UNICODE_STRING()
            {
            }
        }

        private _UNICODE_STRING unicode_string;
        private IntPtr native_str = IntPtr.Zero;

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
                unicode_string.MaximumLength = 0;
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
        public const UInt32 OBJ_INHERIT = 0x00000002;
        public const UInt32 OBJ_PERMANENT = 0x00000010;
        public const UInt32 OBJ_EXCLUSIVE = 0x00000020;
        public const UInt32 OBJ_CASE_INSENSITIVE = 0x00000040;
        public const UInt32 OBJ_OPENIF = 0x00000080;
        public const UInt32 OBJ_OPENLINK = 0x00000100;
        public const UInt32 OBJ_KERNEL_HANDLE = 0x00000200;
        public const UInt32 OBJ_FORCE_ACCESS_CHECK = 0x00000400;
        public const UInt32 OBJ_IGNORE_IMPERSONATED_DEVICEMAP = 0x00000800;
        public const UInt32 OBJ_DONT_REPARSE = 0x00001000;
        public const UInt32 OBJ_VALID_ATTRIBUTES = 0x00001FF2;
    }

    public class ACE
    {
        public const byte ACCESS_MIN_MS_ACE_TYPE = (byte)0x0;
        public const byte ACCESS_ALLOWED_ACE_TYPE = (byte)0x0;
        public const byte ACCESS_DENIED_ACE_TYPE = (byte)0x1;
        public const byte SYSTEM_AUDIT_ACE_TYPE = (byte)0x2;
        public const byte SYSTEM_ALARM_ACE_TYPE = (byte)0x3;
        public const byte ACCESS_ALLOWED_COMPOUND_ACE_TYPE = (byte)0x4;
        public const byte ACCESS_MIN_MS_OBJECT_ACE_TYPE = (byte)0x5;
        public const byte ACCESS_ALLOWED_OBJECT_ACE_TYPE = (byte)0x5;
        public const byte ACCESS_DENIED_OBJECT_ACE_TYPE = (byte)0x6;
        public const byte SYSTEM_AUDIT_OBJECT_ACE_TYPE = (byte)0x7;
        public const byte SYSTEM_ALARM_OBJECT_ACE_TYPE = (byte)0x8;
        public const byte ACCESS_MAX_MS_OBJECT_ACE_TYPE = (byte)0x8;
        public const byte ACCESS_MAX_MS_ACE_TYPE = (byte)0x8;
        public const byte ACCESS_ALLOWED_CALLBACK_ACE_TYPE = (byte)0x9;
        public const byte ACCESS_DENIED_CALLBACK_ACE_TYPE = (byte)0xA;
        public const byte ACCESS_ALLOWED_CALLBACK_OBJECT_ACE_TYPE = (byte)0xB;
        public const byte ACCESS_DENIED_CALLBACK_OBJECT_ACE_TYPE = (byte)0xC;
        public const byte SYSTEM_AUDIT_CALLBACK_ACE_TYPE = (byte)0xD;
        public const byte SYSTEM_ALARM_CALLBACK_ACE_TYPE = (byte)0xE;
        public const byte SYSTEM_AUDIT_CALLBACK_OBJECT_ACE_TYPE = (byte)0xF;
        public const byte SYSTEM_ALARM_CALLBACK_OBJECT_ACE_TYPE = (byte)0x10;
        public const byte SYSTEM_MANDATORY_LABEL_ACE_TYPE = (byte)0x11;
        public const byte SYSTEM_RESOURCE_ATTRIBUTE_ACE_TYPE = (byte)0x12;
        public const byte SYSTEM_SCOPED_POLICY_ID_ACE_TYPE = (byte)0x13;
        public const byte SYSTEM_PROCESS_TRUST_LABEL_ACE_TYPE = (byte)0x14;
        public const byte SYSTEM_ACCESS_FILTER_ACE_TYPE = (byte)0x15;

        public const byte OBJECT_INHERIT_ACE = (byte)0x1;
        public const byte CONTAINER_INHERIT_ACE = (byte)0x2;
        public const byte NO_PROPAGATE_INHERIT_ACE = (byte)0x4;
        public const byte INHERIT_ONLY_ACE = (byte)0x8;
        public const byte INHERITED_ACE = (byte)0x10;
        public const byte VALID_INHERIT_FLAGS = (byte)0x1F;


        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private unsafe struct _ACE_HEADER
        {
            [FieldOffset(0)] public byte AceType;
            [FieldOffset(1)] public byte AceFlags;
            [FieldOffset(2)] public UInt16 AceSize;
        }

        private _ACE_HEADER aceHeader;
        IntPtr buffer = IntPtr.Zero;

        public byte AceType => aceHeader.AceType;
        public byte AceFlags => aceHeader.AceFlags;
        public Nullable<byte>[] AceData = new Nullable<byte>[16];

        public UInt16 Length
        {
            get
            {
                return (ushort)(4 + AceData.Length);
            }
        }

        private void MarshalAce()
        {
            if (IntPtr.Zero != buffer)
            {
                Marshal.FreeHGlobal(buffer);
            }
            buffer = Marshal.AllocHGlobal(Length);
            Marshal.StructureToPtr(AceData, buffer, true);
            // TODO: need to figure out how to get this all into a single buffer
        }

        public static implicit operator IntPtr(ACE ace)
        {
            ace.MarshalAce();
            return ace.buffer;
        }


    }


    public class ACL
    {
        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _ACL
        {
            [FieldOffset(0)] public byte AclRevision; // field size is 1
            [FieldOffset(2)] public UInt16 AclSize; // field size is 2
            [FieldOffset(4)] public UInt16 AceCount; // field size is 2
        }

        private _ACL nativeAcl;
        private IntPtr buffer = IntPtr.Zero;
        private List<ACE> aCEs = new List<ACE>();

        public List<ACE> GetACEs()
        {
            return aCEs;
        }

        public void AddAce(ACE ace)
        {
            if (ace != null)
            {
                aCEs.Add(ace);
            }
        }

        private void MarshalAcl()
        {
            if (IntPtr.Zero == buffer)
            {
                int aclSize = Marshal.SizeOf(typeof(ACL)); // ACL header
                foreach (ACE ace in aCEs)
                {
                    aclSize += ace.Length;
                }
                buffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ACL)));
            }
            Marshal.StructureToPtr(nativeAcl, buffer, true);
        }

        public static implicit operator IntPtr(ACL acl)
        {
            acl.MarshalAcl();
            return acl.buffer;
        }

    }

    public class SID
    {
        public const UInt16 SECURITY_MAX_SID_SIZE = 60;

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private unsafe struct _SID
        {
            [FieldOffset(0)] public byte Revision; // field size is 1
            [FieldOffset(1)] public byte SubAuthorityCount; // field size is 1
            [FieldOffset(2)] public fixed byte IdentifierAuthority[6]; // field size is 6
            [FieldOffset(8)] public fixed byte SubAuthority[SECURITY_MAX_SID_SIZE];
        }

        private IntPtr buffer = IntPtr.Zero;
        _SID nativeSid;

        private void MarshalSid()
        {
            if (IntPtr.Zero == buffer)
            {
                buffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SID)));
            }
            Marshal.StructureToPtr(nativeSid, buffer, false);
        }

        public static implicit operator IntPtr(SID sid)
        {
            sid.MarshalSid();
            return sid.buffer;
        }

        ~SID()
        {
            if (IntPtr.Zero != buffer)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }
        }

    }
    public class SECURITY_DESCRIPTOR
    {
        public enum SECURITY_DESCRIPTOR_CONTROL
        {
            SE_OWNER_DEFAULTED = (UInt16)0x0001,
            SE_GROUP_DEFAULTED = (UInt16)0x0002,
            SE_DACL_PRESENT = (UInt16)0x0004,
            SE_DACL_DEFAULTED = (UInt16)0x0008,
            SE_SACL_PRESENT = (UInt16)0x0010,
            SE_SACL_DEFAULTED = (UInt16)0x0020,
            SE_DACL_UNTRUSTED = (UInt16)0x0040,
            SE_SERVER_SECURITY = (UInt16)0x0080,
            SE_DACL_AUTO_INHERIT_REQ = (UInt16)0x0100,
            SE_SACL_AUTO_INHERIT_REQ = (UInt16)0x0200,
            SE_DACL_AUTO_INHERITED = (UInt16)0x0400,
            SE_SACL_AUTO_INHERITED = (UInt16)0x0800,
            SE_DACL_PROTECTED = (UInt16)0x1000,
            SE_SACL_PROTECTED = (UInt16)0x2000,
            SE_RM_CONTROL_VALID = (UInt16)0x4000,
            SE_SELF_RELATIVE = (UInt16)0x8000,
        }

        private const UInt32 Revision = 1;
        /*
         * Note: this is described in ntifs.h; in other headers it
         * is opaque (PVOID)
         */
        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _SECURITY_DESCRIPTOR
        {
            [FieldOffset(0)] public byte Revision; // field size is 1
            [FieldOffset(2)] public UInt16 Control; // field size is 2
            [FieldOffset(8)] public IntPtr Owner; // field size is 8
            [FieldOffset(16)] public IntPtr Group; // field size is 8
            [FieldOffset(24)] public IntPtr Sacl; // field size is 8
            [FieldOffset(32)] public IntPtr Dacl; // field size is 8
        }

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _SECURITY_DESCRIPTOR_RELATIVE
        {
            [FieldOffset(0)] public byte Revision; // field size is 1
            [FieldOffset(2)] public UInt16 Control; // field size is 2
            [FieldOffset(8)] public UInt32 Owner; // field size is 4
            [FieldOffset(16)] public UInt32 Group; // field size is 4
            [FieldOffset(24)] public UInt32 Sacl; // field size is 4
            [FieldOffset(32)] public UInt32 Dacl; // field size is 4
        }

        private IntPtr sidBuffer = IntPtr.Zero;
        private IntPtr ownerBuffer = IntPtr.Zero;
        private IntPtr groupBuffer = IntPtr.Zero;
        private IntPtr saclBuffer = IntPtr.Zero;
        private IntPtr daclBuffer = IntPtr.Zero;

        private _SECURITY_DESCRIPTOR native_security_descriptor;

        UInt16 Control => native_security_descriptor.Control;
        SID? Owner;
        SID? Group;
        ACL? Sacl;
        ACL? Dacl;

        private void MarshalSid()
        {
            if (IntPtr.Zero == sidBuffer)
            {
                unsafe
                {
                    sidBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(native_security_descriptor));
                }
            }
            native_security_descriptor.Revision = (byte)Revision;
            if (null != Owner)
            {
                native_security_descriptor.Owner = Owner;
            }
            if (null != Group)
            {
                native_security_descriptor.Group = Group;
            }
            if (null != Sacl)
            {
                native_security_descriptor.Sacl = Sacl;
            }
            if (null != Dacl)
            {
                native_security_descriptor.Dacl = Dacl;
            }


        }

        public static implicit operator IntPtr(SECURITY_DESCRIPTOR securityDescriptor)
        {
            securityDescriptor.MarshalSid();
            return securityDescriptor.sidBuffer;
        }
    }

    public class SECURITY_QUALITY_OF_SERVICE
    {
        public enum SECURITY_IMPERSONATION_LEVEL
        {
            SecurityAnonymous = 0,
            SecurityIdentification = 1,
            SecurityImpersonation = 2,
            SecurityDelegation = 3,
        }

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private unsafe struct _SECURITY_QUALITY_OF_SERVICE
        {
            [FieldOffset(0)] public UInt32 Length; // field size is 4
            [FieldOffset(4)] public UInt32 ImpersonationLevel; // field size is 4
            [FieldOffset(8)] public bool ContextTrackingMode; // field size is 1
            [FieldOffset(9)] public bool EffectiveOnly; // field size is 1
        }

        private _SECURITY_QUALITY_OF_SERVICE native_security_qos;

        public UInt32 Length => native_security_qos.Length;
        public SECURITY_IMPERSONATION_LEVEL ImpersonationLevel
        {
            get { return (SECURITY_IMPERSONATION_LEVEL)native_security_qos.ImpersonationLevel; }
            set { native_security_qos.ImpersonationLevel = (UInt32)value; }
        }

        public bool ContextTrackingMode => native_security_qos.ContextTrackingMode;
        public bool EffectiveOnly => native_security_qos.EffectiveOnly;

        public SECURITY_QUALITY_OF_SERVICE(SECURITY_IMPERSONATION_LEVEL ImpersionationLevel = SECURITY_IMPERSONATION_LEVEL.SecurityAnonymous, bool DynamicTracking = false, bool EffectiveOnly = false)
        {
            native_security_qos = new _SECURITY_QUALITY_OF_SERVICE();
            unsafe
            {
                native_security_qos.Length = (UInt32)sizeof(_SECURITY_QUALITY_OF_SERVICE);
            }
            native_security_qos.ImpersonationLevel = (UInt32)ImpersonationLevel;
            native_security_qos.ContextTrackingMode = DynamicTracking;
        }
    }


    public class OBJECT_ATTRIBUTES
    {
        public const UInt32 OBJ_INHERIT = (UInt32)0x00000002;
        public const UInt32 OBJ_PERMANENT = (UInt32)0x00000010;
        public const UInt32 OBJ_EXCLUSIVE = (UInt32)0x00000020;
        public const UInt32 OBJ_CASE_INSENSITIVE = (UInt32)0x00000040;
        public const UInt32 OBJ_OPENIF = (UInt32)0x00000080;
        public const UInt32 OBJ_OPENLINK = (UInt32)0x00000100;
        public const UInt32 OBJ_KERNEL_HANDLE = (UInt32)0x00000200;
        public const UInt32 OBJ_FORCE_ACCESS_CHECK = (UInt32)0x00000400;
        public const UInt32 OBJ_IGNORE_IMPERSONATED_DEVICEMAP = (UInt32)0x00000800;
        public const UInt32 OBJ_DONT_REPARSE = (UInt32)0x00001000;
        public const UInt32 OBJ_VALID_ATTRIBUTES = (UInt32)0x00001FF2;


        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private unsafe struct _OBJECT_ATTRIBUTES
        {
            [FieldOffset(0)] public UInt32 Length; // field size is 4
            [FieldOffset(8)] public IntPtr RootDirectory; // field size is 8
            [FieldOffset(16)] public IntPtr ObjectName; // PUNICODE_STRING, field size is 8
            [FieldOffset(24)] public UInt32 Attributes; // fields size is 4
            [FieldOffset(32)] public IntPtr SecurityDescriptor; // field size is 8
            [FieldOffset(40)] public IntPtr SecurityQualityOfService; // field size is 8
        }

        private _OBJECT_ATTRIBUTES nativeObjectAttributes;
        private IntPtr buffer = IntPtr.Zero;

        private SafeHandle _RootDirectory = new SafeFileHandle(IntPtr.Zero, true);
        public SafeHandle RootDirectory
        {
            get { return _RootDirectory; }
            set { _RootDirectory = value; version++; }
        }

        private UNICODE_STRING? _ObjectName;
        public UNICODE_STRING? ObjectName
        {
            get { return _ObjectName; }
            set { _ObjectName = value; version++; }
        }

        private UInt32 _Attributes;
        public UInt32 Attributes
        {
            get { return _Attributes; }
            set { _Attributes = value; version++; }
        }

        private SECURITY_DESCRIPTOR? _SecurityDescriptor;
        public SECURITY_DESCRIPTOR? SecurityDescriptor
        {
            get { return _SecurityDescriptor; }
            set { _SecurityDescriptor = value; version++; }
        }

        private SECURITY_QUALITY_OF_SERVICE? _SecurityQualityOfService;
        public SECURITY_QUALITY_OF_SERVICE? SecurityQualityOfService
        {
            get { return _SecurityQualityOfService; }
            set { _SecurityQualityOfService = value; version++; }
        }

        private UInt32 version = 1;
        private UInt32 MarshaledVersion = 0;

        private void MarshalObjectAttributes()
        {
            if (IntPtr.Zero == buffer)
            {
                buffer = Marshal.AllocHGlobal(Marshal.SizeOf(nativeObjectAttributes));
                if (MarshaledVersion == version)
                {
                    version++; // we know that if we allocated, it has to be marshaled.
                }
            }

            // Only marshal again if there is a version mismatch
            if (MarshaledVersion != version)
            {
                unsafe
                {
                    nativeObjectAttributes.Length = (UInt32)sizeof(_OBJECT_ATTRIBUTES);
                }
                nativeObjectAttributes.RootDirectory = RootDirectory.DangerousGetHandle();
                if (null != ObjectName)
                {
                    nativeObjectAttributes.ObjectName = ObjectName;
                }
                if (null != SecurityDescriptor)
                {
                    throw new NotImplementedException("Have not implemented security descriptor support");
                }
                if (null != SecurityQualityOfService)
                {
                    throw new NotImplementedException("Have not implemented SecurityQoS support");
                }
                Marshal.StructureToPtr(nativeObjectAttributes, buffer, true);
                MarshaledVersion = version;
            }
        }

        public OBJECT_ATTRIBUTES(SafeHandle RootDirectory, UNICODE_STRING ObjectName, UInt32 Attributes = OBJ_CASE_INSENSITIVE)
        {
            nativeObjectAttributes = new _OBJECT_ATTRIBUTES();

            this.RootDirectory = RootDirectory;
            this.ObjectName = ObjectName;
            this.Attributes = Attributes;
            MarshalObjectAttributes();
        }

        ~OBJECT_ATTRIBUTES()
        {
            if (IntPtr.Zero != buffer)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }
        }

        public static implicit operator IntPtr(OBJECT_ATTRIBUTES objectAttributes)
        {
            objectAttributes.MarshalObjectAttributes();
            return objectAttributes.buffer;
        }
    }

    public class IO_STATUS_BLOCK
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _IO_STATUS_BLOCK
        {
            [FieldOffset(0)] public Int32 Status = 0;
            [FieldOffset(0)] public UIntPtr Pointer = UIntPtr.Zero;
            [FieldOffset(8)] public UInt64 Information = 0;

            public _IO_STATUS_BLOCK()
            {
            }
        }

        private _IO_STATUS_BLOCK nativeStatusBlock;
        private IntPtr buffer = IntPtr.Zero;

        public NativeSupportLibrary.NtStatusCode Status
        {
            get
            {
                nativeStatusBlock = Marshal.PtrToStructure<_IO_STATUS_BLOCK>(buffer);
                return (NtStatusCode)nativeStatusBlock.Status;
            }

            set
            {
                nativeStatusBlock.Status = (Int32)value;
                Marshal.StructureToPtr<_IO_STATUS_BLOCK>(nativeStatusBlock, buffer, true);
            }
        }

        public UInt64 Information
        {
            get
            {
                nativeStatusBlock = Marshal.PtrToStructure<_IO_STATUS_BLOCK>(buffer);
                return nativeStatusBlock.Information;
            }

            set
            {
                nativeStatusBlock.Information = value;
                Marshal.StructureToPtr<_IO_STATUS_BLOCK>(nativeStatusBlock, buffer, true);
            }
        }

        public IO_STATUS_BLOCK(NativeSupportLibrary.NtStatusCode Status, UInt32 Information)
        {
            unsafe
            {
                this.buffer = Marshal.AllocHGlobal(sizeof(_IO_STATUS_BLOCK));
            }
            nativeStatusBlock = new _IO_STATUS_BLOCK();
            nativeStatusBlock.Status = (Int32)Status;
            nativeStatusBlock.Information = Information;
            Marshal.StructureToPtr(nativeStatusBlock, buffer, true);
        }

        public IO_STATUS_BLOCK(NativeSupportLibrary.NtStatusCode Status, UInt64 InformationPtr)
        {
            unsafe
            {
                this.buffer = Marshal.AllocHGlobal(sizeof(_IO_STATUS_BLOCK));
            }
            nativeStatusBlock = new _IO_STATUS_BLOCK();
            nativeStatusBlock.Status = (Int32)Status;
            nativeStatusBlock.Information = Information;
            Marshal.StructureToPtr(nativeStatusBlock, buffer, true);
        }

        private IO_STATUS_BLOCK(IntPtr Buffer)
        {
            unsafe
            {
                buffer = Marshal.AllocHGlobal(sizeof(_IO_STATUS_BLOCK));
            }
            nativeStatusBlock = new _IO_STATUS_BLOCK();
            Marshal.PtrToStructure(Buffer, buffer);
            nativeStatusBlock.Status = (Int32)Status;
            nativeStatusBlock.Information = Information;
            Marshal.StructureToPtr(nativeStatusBlock, buffer, true);
        }

        public IO_STATUS_BLOCK()
        {
            buffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(_IO_STATUS_BLOCK)));
            nativeStatusBlock = new _IO_STATUS_BLOCK();
            nativeStatusBlock.Status = 0;
            nativeStatusBlock.Information = 0;
            Marshal.StructureToPtr(nativeStatusBlock, buffer, true);
        }

        ~IO_STATUS_BLOCK()
        {
            if (IntPtr.Zero != buffer)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }
        }

        public static implicit operator IntPtr(IO_STATUS_BLOCK iosb)
        {
            return iosb.buffer;
        }

        public static implicit operator IO_STATUS_BLOCK(IntPtr buffer)
        {
            return new IO_STATUS_BLOCK(buffer);
        }

    }

    public class APC
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate void ApcRoutine(IntPtr ApcContext);

        public static implicit operator IntPtr(APC apcObject)
        {
            return IntPtr.Zero;
        }

        public IntPtr ApcContext
        {
            get { return IntPtr.Zero; }
            set { throw new NotImplementedException("APC_OBJECT isn't implemented yet."); }
        }

    }

    public class EVENT
    {
        public static implicit operator IntPtr(EVENT ev)
        {
            return IntPtr.Zero;
        }
    }

    public enum FS_INFORMATION_CLASS
    {
        FileFsVolumeInformation = 1,
        FileFsLabelInformation,         // 2
        FileFsSizeInformation,          // 3
        FileFsDeviceInformation,        // 4
        FileFsAttributeInformation,     // 5
        FileFsControlInformation,       // 6
        FileFsFullSizeInformation,      // 7
        FileFsObjectIdInformation,      // 8
        FileFsDriverPathInformation,    // 9
        FileFsVolumeFlagsInformation,   // 10
        FileFsSectorSizeInformation,    // 11
        FileFsDataCopyInformation,      // 12
        FileFsMetadataSizeInformation,  // 13
        FileFsFullSizeInformationEx,    // 14
    }

}
