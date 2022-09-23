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

namespace NativeSupportLibrary
{
    //
    // NtQueryDirectoryFile return types:
    //
    //      FILE_DIRECTORY_INFORMATION
    //      FILE_BOTH_DIR_INFORMATION
    //      FILE_ID_FULL_DIR_INFORMATION
    //      FILE_BOTH_DIR_INFORMATION
    //      FILE_ID_BOTH_DIR_INFORMATION
    //      FILE_NAMES_INFORMATION
    //      FILE_ID_GLOBAL_TX_DIR_INFORMATION
    //      FILE_ID_EXTD_DIR_INFORMATION
    //      FILE_ID_EXTD_BOTH_DIR_INFORMATION
    //      FILE_OBJECTID_INFORMATION
    //

    /*
     *  FILE_DIRECTORY_INFORMATION Offset:
                 FileName: 64
        FILE_FULL_DIR_INFORMATION Offset:
                 FileName: 68
        FILE_ID_FULL_DIR_INFORMATION Offset:
                 FileName: 80
        FILE_BOTH_DIR_INFORMATION Offset:
                ShortName: 70
                 FileName: 94
        FILE_ID_BOTH_DIR_INFORMATION Offset:
                ShortName: 70
                 FileName: 104
        FILE_ID_GLOBAL_TX_DIR_INFORMATION Offset:
                 FileName: 92
        FILE_ID_EXTD_DIR_INFORMATION Offset:
                 FileName: 88
        FILE_ID_EXTD_BOTH_DIR_INFORMATION Offset:
                ShortName: 90
                 FileName: 114
     */

    public class FILE_DIRECTORY_INFORMATION
    {
        public struct FILE_DIRECTORY_INFO
        {
            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_DIRECTORY_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public UInt32 FileIndex;
                [FieldOffset(8)] public Int64 CreationTime;
                [FieldOffset(16)] public Int64 LastAccessTime;
                [FieldOffset(24)] public Int64 LastWriteTime;
                [FieldOffset(32)] public Int64 ChangeTime;
                [FieldOffset(40)] public Int64 EndOfFile;
                [FieldOffset(48)] public Int64 AllocationSize;
                [FieldOffset(56)] public UInt32 FileAttributes;
                [FieldOffset(60)] public UInt32 FileNameLength;
                // [FieldOffset(64)] public fixed char FileName[1];
            }

            public readonly UInt32 FileIndex;
            public readonly Int64 CreationTime;
            public readonly Int64 LastAccessTime;
            public readonly Int64 LastWriteTime;
            public readonly Int64 ChangeTime;
            public readonly Int64 EndOfFile;
            public readonly Int64 AllocationSize;
            public readonly UInt32 FileAttributes;
            public readonly string FileName;

            const UInt16 FileNameOffset = 64;

            public FILE_DIRECTORY_INFO(IntPtr Buffer, ref int NextEntryOffset)
            {
                _FILE_DIRECTORY_INFORMATION dirInfo = Marshal.PtrToStructure<_FILE_DIRECTORY_INFORMATION>(Buffer);

                FileIndex = dirInfo.FileIndex;
                CreationTime = dirInfo.CreationTime;
                LastAccessTime = dirInfo.LastAccessTime;
                LastWriteTime = dirInfo.LastWriteTime;
                ChangeTime = dirInfo.ChangeTime;
                EndOfFile = dirInfo.EndOfFile;
                AllocationSize = dirInfo.AllocationSize;
                FileAttributes = dirInfo.FileAttributes;

                // Note that names are not necessarily NULL terminated from the kernel, so we explicitly state
                // a maximum length since the kernel does always set the length for us.
                FileName = Marshal.PtrToStringUni(IntPtr.Add(Buffer, FileNameOffset), (int)dirInfo.FileNameLength);

                NextEntryOffset = (int)dirInfo.NextEntryOffset;
            }
        }

        // The choice of initial length is fairly arbitrary and could be optimized if it is an issue
        public List<FILE_DIRECTORY_INFO> Entries = new List<FILE_DIRECTORY_INFO>(1024);

        public FILE_DIRECTORY_INFORMATION()
        {
        }

        // This routine is used to feed in a buffer of entries that are then added to the list
        unsafe public uint AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            uint count = 0;

            if (IntPtr.Zero == Buffer)
            {
                return count;
            }

            IntPtr current = Buffer;

            while (current.ToInt64() < (Buffer.ToInt64() + (Int64)BufferLength))
            {
                int nextOffset = 0;
                Entries.Add(new FILE_DIRECTORY_INFO(current, ref nextOffset));
                count++;

                current = IntPtr.Add(current, (int)nextOffset);
            }

            return count;
        }

    }

    public class FILE_FULL_DIR_INFORMATION
    {
        public struct FILE_FULL_DIR_INFO
        {
            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_FULL_DIR_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public UInt32 FileIndex;
                [FieldOffset(8)] public Int64 CreationTime;
                [FieldOffset(16)] public Int64 LastAccessTime;
                [FieldOffset(24)] public Int64 LastWriteTime;
                [FieldOffset(32)] public Int64 ChangeTime;
                [FieldOffset(40)] public Int64 EndOfFile;
                [FieldOffset(48)] public Int64 AllocationSize;
                [FieldOffset(56)] public UInt32 FileAttributes;
                [FieldOffset(60)] public UInt32 FileNameLength;
                [FieldOffset(64)] public UInt32 EaSize;
                // [FieldOffset(68)] public fixed char FileName[1];
            }

            public readonly UInt32 FileIndex;
            public readonly Int64 CreationTime;
            public readonly Int64 LastAccessTime;
            public readonly Int64 LastWriteTime;
            public readonly Int64 ChangeTime;
            public readonly Int64 EndOfFile;
            public readonly Int64 AllocationSize;
            public readonly UInt32 FileAttributes;
            public readonly UInt32 EaSize;
            public readonly string FileName;

            const UInt16 FileNameOffset = 68;

            public FILE_FULL_DIR_INFO(IntPtr Buffer, ref int NextEntryOffset)
            {
                _FILE_FULL_DIR_INFORMATION dirInfo = Marshal.PtrToStructure<_FILE_FULL_DIR_INFORMATION>(Buffer);

                FileIndex = dirInfo.FileIndex;
                CreationTime = dirInfo.CreationTime;
                LastAccessTime = dirInfo.LastAccessTime;
                LastWriteTime = dirInfo.LastWriteTime;
                ChangeTime = dirInfo.ChangeTime;
                EndOfFile = dirInfo.EndOfFile;
                AllocationSize = dirInfo.AllocationSize;
                FileAttributes = dirInfo.FileAttributes;
                EaSize = dirInfo.EaSize;

                // Note that names are not necessarily NULL terminated from the kernel, so we explicitly state
                // a maximum length since the kernel does always set the length for us.
                FileName = Marshal.PtrToStringUni(IntPtr.Add(Buffer, FileNameOffset), (int)dirInfo.FileNameLength);

                NextEntryOffset = (int)dirInfo.NextEntryOffset;
            }
        }

        // The choice of initial length is fairly arbitrary and could be optimized if it is an issue
        public List<FILE_FULL_DIR_INFO> Entries = new List<FILE_FULL_DIR_INFO>(1024);

        public FILE_FULL_DIR_INFORMATION()
        {
        }

        // This routine is used to feed in a buffer of entries that are then added to the list
        unsafe public uint AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            uint count = 0;

            if (IntPtr.Zero == Buffer)
            {
                return count;
            }

            IntPtr current = Buffer;

            while (current.ToInt64() < (Buffer.ToInt64() + (Int64)BufferLength))
            {
                int nextOffset = 0;
                Entries.Add(new FILE_FULL_DIR_INFO(current, ref nextOffset));
                count++;

                current = IntPtr.Add(current, (int)nextOffset);
            }

            return count;
        }

    }

    public class FILE_ID_FULL_DIR_INFORMATION
    {
        public struct FILE_ID_FULL_DIR_INFO
        {
            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_ID_FULL_DIR_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public UInt32 FileIndex;
                [FieldOffset(8)] public Int64 CreationTime;
                [FieldOffset(16)] public Int64 LastAccessTime;
                [FieldOffset(24)] public Int64 LastWriteTime;
                [FieldOffset(32)] public Int64 ChangeTime;
                [FieldOffset(40)] public Int64 EndOfFile;
                [FieldOffset(48)] public Int64 AllocationSize;
                [FieldOffset(56)] public UInt32 FileAttributes;
                [FieldOffset(60)] public UInt32 FileNameLength;
                [FieldOffset(64)] public UInt32 EaSize;
                // Note: I have not validated this offset yet; it should round to the 8 byte boundary
                // but need to verify and fix if it is wrong.
                [FieldOffset(72)] public UInt64 FileId; // TODO: change to file ID type

                // [FieldOffset(80)] public fixed char FileName[1];
            }

            public readonly UInt32 FileIndex;
            public readonly Int64 CreationTime;
            public readonly Int64 LastAccessTime;
            public readonly Int64 LastWriteTime;
            public readonly Int64 ChangeTime;
            public readonly Int64 EndOfFile;
            public readonly Int64 AllocationSize;
            public readonly UInt32 FileAttributes;
            public readonly UInt32 EaSize;
            public readonly string FileName;

            const UInt16 FileNameOffset = 80;

            public FILE_ID_FULL_DIR_INFO(IntPtr Buffer, ref int NextEntryOffset)
            {
                _FILE_ID_FULL_DIR_INFORMATION dirInfo = Marshal.PtrToStructure<_FILE_ID_FULL_DIR_INFORMATION>(Buffer);

                FileIndex = dirInfo.FileIndex;
                CreationTime = dirInfo.CreationTime;
                LastAccessTime = dirInfo.LastAccessTime;
                LastWriteTime = dirInfo.LastWriteTime;
                ChangeTime = dirInfo.ChangeTime;
                EndOfFile = dirInfo.EndOfFile;
                AllocationSize = dirInfo.AllocationSize;
                FileAttributes = dirInfo.FileAttributes;
                EaSize = dirInfo.EaSize;
                dirInfo.FileId = dirInfo.FileId;

                // Note that names are not necessarily NULL terminated from the kernel, so we explicitly state
                // a maximum length since the kernel does always set the length for us.
                FileName = Marshal.PtrToStringUni(IntPtr.Add(Buffer, FileNameOffset), (int)dirInfo.FileNameLength);

                NextEntryOffset = (int)dirInfo.NextEntryOffset;
            }
        }

        // The choice of initial length is fairly arbitrary and could be optimized if it is an issue
        public List<FILE_ID_FULL_DIR_INFO> Entries = new List<FILE_ID_FULL_DIR_INFO>(1024);

        public FILE_ID_FULL_DIR_INFORMATION()
        {
        }

        // This routine is used to feed in a buffer of entries that are then added to the list
        unsafe public uint AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            uint count = 0;

            if (IntPtr.Zero == Buffer)
            {
                return count;
            }

            IntPtr current = Buffer;

            while (current.ToInt64() < (Buffer.ToInt64() + (Int64)BufferLength))
            {
                int nextOffset = 0;
                Entries.Add(new FILE_ID_FULL_DIR_INFO(current, ref nextOffset));
                count++;

                current = IntPtr.Add(current, (int)nextOffset);
            }

            return count;
        }

    }

    public class FILE_BOTH_DIR_INFORMATION
    {
        public struct FILE_BOTH_DIR_INFO
        {
            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_BOTH_DIR_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public UInt32 FileIndex;
                [FieldOffset(8)] public Int64 CreationTime;
                [FieldOffset(16)] public Int64 LastAccessTime;
                [FieldOffset(24)] public Int64 LastWriteTime;
                [FieldOffset(32)] public Int64 ChangeTime;
                [FieldOffset(40)] public Int64 EndOfFile;
                [FieldOffset(48)] public Int64 AllocationSize;
                [FieldOffset(56)] public UInt32 FileAttributes;
                [FieldOffset(60)] public UInt32 FileNameLength;
                [FieldOffset(64)] public UInt32 EaSize;
                [FieldOffset(68)] public UInt16 ShortNameLength;
                [FieldOffset(70)] public fixed char ShortName[12];

                // [FieldOffset(94)] public fixed char FileName[1];
            }

            const UInt16 FileNameByteOffset = 94;

            public readonly UInt32 FileIndex;
            public readonly Int64 CreationTime;
            public readonly Int64 LastAccessTime;
            public readonly Int64 LastWriteTime;
            public readonly Int64 ChangeTime;
            public readonly Int64 EndOfFile;
            public readonly Int64 AllocationSize;
            public readonly UInt32 FileAttributes;
            public readonly UInt32 EaSize;
            public readonly string FileName;
            public readonly string? ShortName = null;

            const UInt16 ShortNameOffset = 70;
            const UInt16 FileNameOffset = 94;

            public FILE_BOTH_DIR_INFO(IntPtr Buffer, ref int NextEntryOffset)
            {
                _FILE_BOTH_DIR_INFORMATION dirInfo = Marshal.PtrToStructure<_FILE_BOTH_DIR_INFORMATION>(Buffer);

                FileIndex = dirInfo.FileIndex;
                CreationTime = dirInfo.CreationTime;
                LastAccessTime = dirInfo.LastAccessTime;
                LastWriteTime = dirInfo.LastWriteTime;
                ChangeTime = dirInfo.ChangeTime;
                EndOfFile = dirInfo.EndOfFile;
                AllocationSize = dirInfo.AllocationSize;
                FileAttributes = dirInfo.FileAttributes;
                EaSize = dirInfo.EaSize;

                // Note that names are not necessarily NULL terminated from the kernel, so we explicitly state
                // a maximum length since the kernel does always set the length for us.
                FileName = Marshal.PtrToStringUni(IntPtr.Add(Buffer, FileNameOffset), (int)dirInfo.FileNameLength);

                if (dirInfo.ShortNameLength > 0)
                {
                    ShortName = Marshal.PtrToStringUni(IntPtr.Add(Buffer, ShortNameOffset), (int)dirInfo.ShortNameLength);
                }

                NextEntryOffset = (int)dirInfo.NextEntryOffset;
            }
        }

        // The choice of initial length is fairly arbitrary and could be optimized if it is an issue
        public List<FILE_BOTH_DIR_INFO> Entries = new List<FILE_BOTH_DIR_INFO>(1024);

        public FILE_BOTH_DIR_INFORMATION()
        {
        }

        // This routine is used to feed in a buffer of entries that are then added to the list
        unsafe public uint AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            uint count = 0;

            if (IntPtr.Zero == Buffer)
            {
                return count;
            }

            IntPtr current = Buffer;

            while (current.ToInt64() < (Buffer.ToInt64() + (Int64)BufferLength))
            {
                int nextOffset = 0;
                Entries.Add(new FILE_BOTH_DIR_INFO(current, ref nextOffset));
                count++;

                current = IntPtr.Add(current, (int)nextOffset);
            }

            return count;
        }

    }

    public class FILE_ID_BOTH_DIR_INFORMATION
    {
        public struct FILE_ID_BOTH_DIR_INFO
        {
            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_ID_BOTH_DIR_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public UInt32 FileIndex;
                [FieldOffset(8)] public Int64 CreationTime;
                [FieldOffset(16)] public Int64 LastAccessTime;
                [FieldOffset(24)] public Int64 LastWriteTime;
                [FieldOffset(32)] public Int64 ChangeTime;
                [FieldOffset(40)] public Int64 EndOfFile;
                [FieldOffset(48)] public Int64 AllocationSize;
                [FieldOffset(56)] public UInt32 FileAttributes;
                [FieldOffset(60)] public UInt32 FileNameLength;
                [FieldOffset(64)] public UInt32 EaSize;
                [FieldOffset(68)] public UInt16 ShortNameLength;
                [FieldOffset(70)] public fixed char ShortName[12];
                [FieldOffset(96)] public Int64 FileId;

                // [FieldOffset(104)] public fixed char FileName[1];
            }

            public readonly UInt32 FileIndex;
            public readonly Int64 CreationTime;
            public readonly Int64 LastAccessTime;
            public readonly Int64 LastWriteTime;
            public readonly Int64 ChangeTime;
            public readonly Int64 EndOfFile;
            public readonly Int64 AllocationSize;
            public readonly UInt32 FileAttributes;
            public readonly UInt32 EaSize;
            public readonly string FileName;
            public readonly string? ShortName = null;
            public readonly Int64 FileId;

            const UInt16 ShortNameOffset = 70;
            const UInt16 FileNameOffset = 104;

            public FILE_ID_BOTH_DIR_INFO(IntPtr Buffer, ref int NextEntryOffset)
            {
                _FILE_ID_BOTH_DIR_INFORMATION dirInfo = Marshal.PtrToStructure<_FILE_ID_BOTH_DIR_INFORMATION>(Buffer);

                FileIndex = dirInfo.FileIndex;
                CreationTime = dirInfo.CreationTime;
                LastAccessTime = dirInfo.LastAccessTime;
                LastWriteTime = dirInfo.LastWriteTime;
                ChangeTime = dirInfo.ChangeTime;
                EndOfFile = dirInfo.EndOfFile;
                AllocationSize = dirInfo.AllocationSize;
                FileAttributes = dirInfo.FileAttributes;
                EaSize = dirInfo.EaSize;
                FileId = dirInfo.FileId;

                // Note that names are not necessarily NULL terminated from the kernel, so we explicitly state
                // a maximum length since the kernel does always set the length for us.
                FileName = Marshal.PtrToStringUni(IntPtr.Add(Buffer, FileNameOffset), (int)dirInfo.FileNameLength);

                if (dirInfo.ShortNameLength > 0)
                {
                    ShortName = Marshal.PtrToStringUni(IntPtr.Add(Buffer, ShortNameOffset), (int)dirInfo.ShortNameLength);
                }

                NextEntryOffset = (int)dirInfo.NextEntryOffset;
            }
        }

        // The choice of initial length is fairly arbitrary and could be optimized if it is an issue
        public List<FILE_ID_BOTH_DIR_INFO> Entries = new List<FILE_ID_BOTH_DIR_INFO>(1024);

        public FILE_ID_BOTH_DIR_INFORMATION()
        {
        }

        // This routine is used to feed in a buffer of entries that are then added to the list
        unsafe public uint AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            uint count = 0;

            if (IntPtr.Zero == Buffer)
            {
                return count;
            }

            IntPtr current = Buffer;

            while (current.ToInt64() < (Buffer.ToInt64() + (Int64)BufferLength))
            {
                int nextOffset = 0;
                Entries.Add(new FILE_ID_BOTH_DIR_INFO(current, ref nextOffset));
                count++;

                current = IntPtr.Add(current, (int)nextOffset);
            }

            return count;
        }

    }


    public class FILE_NAMES_INFORMATION
    {
        /*
         * typedef struct _FILE_NAMES_INFORMATION {
                ULONG NextEntryOffset;
                ULONG FileIndex;
                ULONG FileNameLength;
                _Field_size_bytes_(FileNameLength) WCHAR FileName[1];
            } FILE_NAMES_INFORMATION, *PFILE_NAMES_INFORMATION;
         */

        const UInt16 FileNameOffset = 12;

        public struct FILE_NAMES_INFO
        {
            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_NAMES_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public UInt32 FileIndex;
                [FieldOffset(8)] public UInt32 FileNameLength;
            }

            public readonly UInt32 FileIndex;
            public readonly UInt32 FileNameLength;
            public readonly string? FileName;

            public FILE_NAMES_INFO(IntPtr Buffer, ref int NextEntryOffset)
            {
                _FILE_NAMES_INFORMATION dirInfo = Marshal.PtrToStructure<_FILE_NAMES_INFORMATION>(Buffer);

                FileIndex = dirInfo.FileIndex;
                FileNameLength = dirInfo.FileNameLength;
                FileName = Marshal.PtrToStringUni(IntPtr.Add(Buffer, FileNameOffset), (int)dirInfo.FileNameLength);
                NextEntryOffset = (int) dirInfo.NextEntryOffset;
            }
        }

        // The choice of initial length is fairly arbitrary and could be optimized if it is an issue
        public List<FILE_NAMES_INFO> Entries = new List<FILE_NAMES_INFO>(1024);

        public FILE_NAMES_INFORMATION()
        {
        }

        // This routine is used to feed in a buffer of entries that are then added to the list
        unsafe public uint AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            uint count = 0;

            if (IntPtr.Zero == Buffer)
            {
                return count;
            }

            IntPtr current = Buffer;

            while (current.ToInt64() < (Buffer.ToInt64() + (Int64)BufferLength))
            {
                int nextOffset = 0;
                Entries.Add(new FILE_NAMES_INFO(current, ref nextOffset));
                count++;

                current = IntPtr.Add(current, (int)nextOffset);
            }

            return count;
        }


    }

    public class FILE_ID_GLOBAL_TX_DIR_INFORMATION
    {
        /*
         * typedef struct _FILE_ID_GLOBAL_TX_DIR_INFORMATION {
                ULONG NextEntryOffset;
                ULONG FileIndex;
                LARGE_INTEGER CreationTime;
                LARGE_INTEGER LastAccessTime;
                LARGE_INTEGER LastWriteTime;
                LARGE_INTEGER ChangeTime;
                LARGE_INTEGER EndOfFile;
                LARGE_INTEGER AllocationSize;
                ULONG FileAttributes;
                ULONG FileNameLength;
                LARGE_INTEGER FileId;
                GUID LockingTransactionId;
                ULONG TxInfoFlags;
                _Field_size_bytes_(FileNameLength) WCHAR FileName[1];
            } FILE_ID_GLOBAL_TX_DIR_INFORMATION, *PFILE_ID_GLOBAL_TX_DIR_INFORMATION;
         */

        const UInt16 FileNameOffset = 92;

        public struct FILE_ID_GLOBAL_TX_DIR_INFO
        {
            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_ID_GLOBAL_TX_DIR_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public UInt32 FileIndex;
                [FieldOffset(8)] public Int64 CreationTime;
                [FieldOffset(16)] public Int64 LastAccessTime;
                [FieldOffset(24)] public Int64 LastWriteTime;
                [FieldOffset(32)] public Int64 ChangeTime;
                [FieldOffset(40)] public Int64 EndOfFile;
                [FieldOffset(48)] public Int64 AllocationSize;
                [FieldOffset(56)] public UInt32 FileAttributes;
                [FieldOffset(60)] public UInt32 FileNameLength;
                [FieldOffset(64)] public Int64 FileId;
                [FieldOffset(72)] public unsafe fixed byte LockingTransactionId[16]; // GUID
                [FieldOffset(88)] public UInt32 TxInfoFlags;

                // [FieldOffset(104)] public fixed char FileName[1];
            }

            public readonly UInt32 FileIndex;
            public readonly Int64 CreationTime;
            public readonly Int64 LastAccessTime;
            public readonly Int64 LastWriteTime;
            public readonly Int64 ChangeTime;
            public readonly Int64 EndOfFile;
            public readonly Int64 AllocationSize;
            public readonly UInt32 FileAttributes;
            public readonly string FileName;
            public readonly Int64 FileId;
            public readonly GUID LockingTransactionId;

            const UInt16 FileNameOffset = 104;

            public FILE_ID_GLOBAL_TX_DIR_INFO(IntPtr Buffer, ref int NextEntryOffset)
            {
                _FILE_ID_GLOBAL_TX_DIR_INFORMATION dirInfo = Marshal.PtrToStructure<_FILE_ID_GLOBAL_TX_DIR_INFORMATION>(Buffer);

                FileIndex = dirInfo.FileIndex;
                CreationTime = dirInfo.CreationTime;
                LastAccessTime = dirInfo.LastAccessTime;
                LastWriteTime = dirInfo.LastWriteTime;
                ChangeTime = dirInfo.ChangeTime;
                EndOfFile = dirInfo.EndOfFile;
                AllocationSize = dirInfo.AllocationSize;
                FileAttributes = dirInfo.FileAttributes;
                FileId = dirInfo.FileId;

                byte[] buffer = new byte[16];
                for (var index = 0; index < 16; index++)
                {
                    unsafe
                    {
                        buffer[index] = dirInfo.LockingTransactionId[index];
                    }
                }
                LockingTransactionId = new GUID(new Guid(buffer));

                // Note that names are not necessarily NULL terminated from the kernel, so we explicitly state
                // a maximum length since the kernel does always set the length for us.
                FileName = Marshal.PtrToStringUni(IntPtr.Add(Buffer, FileNameOffset), (int)dirInfo.FileNameLength);
                NextEntryOffset = (int)dirInfo.NextEntryOffset;
            }
        }

        // The choice of initial length is fairly arbitrary and could be optimized if it is an issue
        public List<FILE_ID_BOTH_DIR_INFO> Entries = new List<FILE_ID_BOTH_DIR_INFO>(1024);

        public FILE_ID_GLOBAL_TX_DIR_INFORMATION()
        {
        }

        // This routine is used to feed in a buffer of entries that are then added to the list
        unsafe public uint AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            uint count = 0;

            if (IntPtr.Zero == Buffer)
            {
                return count;
            }

            IntPtr current = Buffer;

            while (current.ToInt64() < (Buffer.ToInt64() + (Int64)BufferLength))
            {
                int nextOffset = 0;
                Entries.Add(new FILE_ID_BOTH_DIR_INFO(current, ref nextOffset));
                count++;

                current = IntPtr.Add(current, (int)nextOffset);
            }

            return count;
        }



    }

    public class FILE_ID_EXTD_DIR_INFORMATION
    {
        /*
         * typedef struct _FILE_ID_EXTD_DIR_INFORMATION {
                ULONG NextEntryOffset;
                ULONG FileIndex;
                LARGE_INTEGER CreationTime;
                LARGE_INTEGER LastAccessTime;
                LARGE_INTEGER LastWriteTime;
                LARGE_INTEGER ChangeTime;
                LARGE_INTEGER EndOfFile;
                LARGE_INTEGER AllocationSize;
                ULONG FileAttributes;
                ULONG FileNameLength;
                ULONG EaSize;
                ULONG ReparsePointTag;
                FILE_ID_128 FileId;
                _Field_size_bytes_(FileNameLength) WCHAR FileName[1];
            } FILE_ID_EXTD_DIR_INFORMATION, *PFILE_ID_EXTD_DIR_INFORMATION;
         */
        public struct FILE_ID_EXTD_DIR_INFO
        {
            const UInt16 FileNameOffset = 88;

            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_ID_EXTD_DIR_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public UInt32 FileIndex;
                [FieldOffset(8)] public Int64 CreationTime;
                [FieldOffset(16)] public Int64 LastAccessTime;
                [FieldOffset(24)] public Int64 LastWriteTime;
                [FieldOffset(32)] public Int64 ChangeTime;
                [FieldOffset(40)] public Int64 EndOfFile;
                [FieldOffset(48)] public Int64 AllocationSize;
                [FieldOffset(56)] public UInt32 FileAttributes;
                [FieldOffset(60)] public UInt32 FileNameLength;
                [FieldOffset(64)] public UInt32 EaSize;
                [FieldOffset(68)] public UInt32 ReparsePointTag;
                [FieldOffset(72)] public _FILE_ID_128 FileId;
            }

            public readonly UInt32 FileIndex;
            public readonly Int64 CreationTime;
            public readonly Int64 LastAccessTime;
            public readonly Int64 LastWriteTime;
            public readonly Int64 ChangeTime;
            public readonly Int64 EndOfFile;
            public readonly Int64 AllocationSize;
            public readonly UInt32 FileAttributes;
            public readonly UInt32 EaSize;
            public readonly UInt32 ReparsePointTag;
            public readonly FILE_ID_128 FileId;
            public readonly string FileName;

            public FILE_ID_EXTD_DIR_INFO(IntPtr Buffer, ref int NextEntryOffset)
            {
                _FILE_ID_EXTD_DIR_INFORMATION dirInfo = Marshal.PtrToStructure<_FILE_ID_EXTD_DIR_INFORMATION>(Buffer);

                FileIndex = dirInfo.FileIndex;
                CreationTime = dirInfo.CreationTime;
                LastAccessTime = dirInfo.LastAccessTime;
                LastWriteTime = dirInfo.LastWriteTime;
                ChangeTime = dirInfo.ChangeTime;
                EndOfFile = dirInfo.EndOfFile;
                AllocationSize = dirInfo.AllocationSize;
                FileAttributes = dirInfo.FileAttributes;
                ReparsePointTag = dirInfo.ReparsePointTag;
                EaSize = dirInfo.EaSize;
                FileId = new FILE_ID_128(dirInfo.FileId);

                // Note that names are not necessarily NULL terminated from the kernel, so we explicitly state
                // a maximum length since the kernel does always set the length for us.
                FileName = Marshal.PtrToStringUni(IntPtr.Add(Buffer, FileNameOffset), (int)dirInfo.FileNameLength);

                NextEntryOffset = (int)dirInfo.NextEntryOffset;
            }

        }

        // The choice of initial length is fairly arbitrary and could be optimized if it is an issue
        public List<FILE_ID_BOTH_DIR_INFO> Entries = new List<FILE_ID_BOTH_DIR_INFO>(1024);

        public FILE_ID_EXTD_DIR_INFORMATION()
        {
        }

        // This routine is used to feed in a buffer of entries that are then added to the list
        unsafe public uint AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            uint count = 0;

            if (IntPtr.Zero == Buffer)
            {
                return count;
            }

            IntPtr current = Buffer;

            while (current.ToInt64() < (Buffer.ToInt64() + (Int64)BufferLength))
            {
                int nextOffset = 0;
                Entries.Add(new FILE_ID_BOTH_DIR_INFO(current, ref nextOffset));
                count++;

                current = IntPtr.Add(current, (int)nextOffset);
            }

            return count;
        }

    }


    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public unsafe struct _FILE_ID_128
    {
        [FieldOffset(0)] public fixed byte Identifier[16];
        [FieldOffset(0)] public UInt64 LowPart;
        [FieldOffset(8)] public UInt64 HighPart;
    }

    public class FILE_ID_128
    {
        private _FILE_ID_128 _FileIdentifier;
        public byte[] FileIdentifier;

        public FILE_ID_128(IntPtr Buffer)
        {
            _FileIdentifier = Marshal.PtrToStructure<_FILE_ID_128>(Buffer);
            FileIdentifier = new byte[16];

            for (var index = 0; FileIdentifier.Length < 16; index++)
            {
                unsafe
                {
                    FileIdentifier[index] = (byte)_FileIdentifier.Identifier[index];
                }
            }
        }

        public FILE_ID_128(FILE_ID_128 Original)
        {
            FileIdentifier = new byte[16];

            if (FileIdentifier.Length != Original.FileIdentifier.Length)
            {
                throw new InvalidDataException("Invalid FileID provided");
            }

            for (var index = 0; index < FileIdentifier.Length; index++)
            {
                FileIdentifier[index] = Original.FileIdentifier[index];
            }
        }

        public FILE_ID_128(_FILE_ID_128 Original)
        {
            FileIdentifier = new byte[16];

            for (var index = 0; index < FileIdentifier.Length; index++)
            {
                unsafe
                {
                    FileIdentifier[index] = (byte)Original.Identifier[index];
                }
            }
        }

        public FILE_ID_128(UInt64 LowPart, UInt64 HighPart)
        {
            _FileIdentifier = new _FILE_ID_128();

            _FileIdentifier.LowPart = LowPart;
            _FileIdentifier.HighPart = HighPart;
        }

        public override string ToString()
        {
            return $"{_FileIdentifier.HighPart:X}:{_FileIdentifier.LowPart:X}";
        }

        public static implicit operator FILE_ID_128(UInt64 SmallFid)
        {
            return new FILE_ID_128(SmallFid);
        }

    }

    public class FILE_ID_EXTD_BOTH_DIR_INFORMATION
    {
        /*
         * typedef struct _FILE_ID_EXTD_BOTH_DIR_INFORMATION {
                ULONG NextEntryOffset;
                ULONG FileIndex;
                LARGE_INTEGER CreationTime;
                LARGE_INTEGER LastAccessTime;
                LARGE_INTEGER LastWriteTime;
                LARGE_INTEGER ChangeTime;
                LARGE_INTEGER EndOfFile;
                LARGE_INTEGER AllocationSize;
                ULONG FileAttributes;
                ULONG FileNameLength;
                ULONG EaSize;
                ULONG ReparsePointTag;
                FILE_ID_128 FileId;
                CCHAR ShortNameLength;
                WCHAR ShortName[12];
                _Field_size_bytes_(FileNameLength) WCHAR FileName[1];
            } FILE_ID_EXTD_BOTH_DIR_INFORMATION, *PFILE_ID_EXTD_BOTH_DIR_INFORMATION;
         */

        public struct FILE_ID_EXTD_BOTH_DIR_INFO
        {
            const UInt16 ShortNameOffset = 90;
            const UInt16 FileNameOffset = 114;

            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_ID_EXTD_BOTH_DIR_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public UInt32 FileIndex;
                [FieldOffset(8)] public Int64 CreationTime;
                [FieldOffset(16)] public Int64 LastAccessTime;
                [FieldOffset(24)] public Int64 LastWriteTime;
                [FieldOffset(32)] public Int64 ChangeTime;
                [FieldOffset(40)] public Int64 EndOfFile;
                [FieldOffset(48)] public Int64 AllocationSize;
                [FieldOffset(56)] public UInt32 FileAttributes;
                [FieldOffset(60)] public UInt32 FileNameLength;
                [FieldOffset(64)] public UInt32 EaSize;
                [FieldOffset(68)] public UInt32 ReparsePointTag;
                [FieldOffset(72)] public _FILE_ID_128 FileId;
                [FieldOffset(88)] public UInt16 ShortNameLength;
                [FieldOffset(ShortNameOffset)] public fixed char ShortName[12];

            }

            public readonly UInt32 FileIndex;
            public readonly Int64 CreationTime;
            public readonly Int64 LastAccessTime;
            public readonly Int64 LastWriteTime;
            public readonly Int64 ChangeTime;
            public readonly Int64 EndOfFile;
            public readonly Int64 AllocationSize;
            public readonly UInt32 FileAttributes;
            public readonly UInt32 EaSize;
            public readonly UInt32 ReparsePointTag;
            public readonly FILE_ID_128 FileId;
            public readonly string FileName;
            public readonly string? ShortName = null;

            public FILE_ID_EXTD_BOTH_DIR_INFO(IntPtr Buffer, ref int NextEntryOffset)
            {
                _FILE_ID_EXTD_BOTH_DIR_INFORMATION dirInfo = Marshal.PtrToStructure<_FILE_ID_EXTD_BOTH_DIR_INFORMATION>(Buffer);

                FileIndex = dirInfo.FileIndex;
                CreationTime = dirInfo.CreationTime;
                LastAccessTime = dirInfo.LastAccessTime;
                LastWriteTime = dirInfo.LastWriteTime;
                ChangeTime = dirInfo.ChangeTime;
                EndOfFile = dirInfo.EndOfFile;
                AllocationSize = dirInfo.AllocationSize;
                FileAttributes = dirInfo.FileAttributes;
                ReparsePointTag = dirInfo.ReparsePointTag;
                EaSize = dirInfo.EaSize;
                FileId = new FILE_ID_128(dirInfo.FileId);

                // Note that names are not necessarily NULL terminated from the kernel, so we explicitly state
                // a maximum length since the kernel does always set the length for us.
                FileName = Marshal.PtrToStringUni(IntPtr.Add(Buffer, FileNameOffset), (int)dirInfo.FileNameLength);

                if (dirInfo.ShortNameLength > 0)
                {
                    ShortName = Marshal.PtrToStringUni(IntPtr.Add(Buffer, ShortNameOffset), (int)dirInfo.ShortNameLength);
                }

                NextEntryOffset = (int)dirInfo.NextEntryOffset;
            }

        }

        // The choice of initial length is fairly arbitrary and could be optimized if it is an issue
        public List<FILE_ID_EXTD_BOTH_DIR_INFO> Entries = new List<FILE_ID_EXTD_BOTH_DIR_INFO>(1024);

        public FILE_ID_EXTD_BOTH_DIR_INFORMATION()
        {
        }

        // This routine is used to feed in a buffer of entries that are then added to the list
        unsafe public uint AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            uint count = 0;

            if (IntPtr.Zero == Buffer)
            {
                return count;
            }

            IntPtr current = Buffer;

            while (current.ToInt64() < (Buffer.ToInt64() + (Int64)BufferLength))
            {
                int nextOffset = 0;
                Entries.Add(new FILE_ID_EXTD_BOTH_DIR_INFO(current, ref nextOffset));
                count++;

                current = IntPtr.Add(current, (int)nextOffset);
            }

            return count;
        }

    }

    public class FILE_OBJECTID_INFORMATION
    {
        public struct FILE_OBJECTID_INFO
        {
            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_OBJECTID_INFORMATION
            {
                [FieldOffset(0)] public Int64 FileReference;
                [FieldOffset(8)] public fixed byte ObjectId[16];
                [FieldOffset(16)] public fixed byte BirthVolumeId[16];
                [FieldOffset(16)] public fixed byte BirthObjectId[16];
                [FieldOffset(16)] public fixed byte DomainId[16];
                [FieldOffset(32)] public fixed byte ExtendedInfo[48];
            }

            public readonly Int64 FileReference;
            public readonly byte[] ObjectId;
            public readonly byte[] SecondaryId;
            public readonly byte[] ExtendedInfo;

            public unsafe FILE_OBJECTID_INFO(IntPtr Buffer, ref int NextEntryOffset)
            {
                _FILE_OBJECTID_INFORMATION dirInfo = Marshal.PtrToStructure<_FILE_OBJECTID_INFORMATION>(Buffer);

                FileReference = dirInfo.FileReference;
                ObjectId = new byte[16];

                for (var index = 0; index < ObjectId.Length; index++)
                {
                    ObjectId[index] = (byte)dirInfo.ObjectId[index];
                }

                SecondaryId = new byte[16];
                for (var index = 0; index < SecondaryId.Length; index++)
                {
                    SecondaryId[index] = (byte)dirInfo.BirthVolumeId[index];
                }

                ExtendedInfo = new byte[48];
                for (var index = 0; index < ExtendedInfo.Length; index++)
                {
                    ExtendedInfo[index] = (byte)dirInfo.ExtendedInfo[index];
                }

                // Hard coded size of the 
                NextEntryOffset = 72;
            }
        }

        // The choice of initial length is fairly arbitrary and could be optimized if it is an issue
        public List<FILE_OBJECTID_INFO> Entries = new List<FILE_OBJECTID_INFO>(1024);

        public FILE_OBJECTID_INFORMATION()
        {
        }

        // This routine is used to feed in a buffer of entries that are then added to the list
        unsafe public uint AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            uint count = 0;

            if (IntPtr.Zero == Buffer)
            {
                return count;
            }

            IntPtr current = Buffer;

            while (current.ToInt64() < (Buffer.ToInt64() + (Int64)BufferLength))
            {
                int nextOffset = 0;
                Entries.Add(new FILE_OBJECTID_INFO(current, ref nextOffset));
                count++;

                current = IntPtr.Add(current, (int)nextOffset);
            }

            return count;
        }


    }

}
