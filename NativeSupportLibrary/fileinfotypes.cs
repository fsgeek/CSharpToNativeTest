using System.Runtime.InteropServices;

namespace NativeSupportLibrary
{
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

        //
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

    public class FILE_BASIC_INFORMATION
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_BASIC_INFORMATION
        {
            [FieldOffset(0)] public Int64 CreationTime = 0;
            [FieldOffset(8)] public Int64 LastAccessTime = 0;
            [FieldOffset(16)] public Int64 LastWriteTime = 0;
            [FieldOffset(24)] public Int64 ChangeTime = 0;
            [FieldOffset(32)] public UInt32 FileAttributes = 0;

            public _FILE_BASIC_INFORMATION()
            {
            }
        }

        private _FILE_BASIC_INFORMATION nativeBasicInformationBlock;
        private IntPtr buffer = IntPtr.Zero;

        public Int64 CreationTime
        {
            get
            {
                nativeBasicInformationBlock = Marshal.PtrToStructure<_FILE_BASIC_INFORMATION>(buffer);
                return nativeBasicInformationBlock.CreationTime;
            }

            set
            {
                nativeBasicInformationBlock.CreationTime = value;
                Marshal.StructureToPtr<_FILE_BASIC_INFORMATION>(nativeBasicInformationBlock, buffer, true);
            }
        }
        public Int64 LastAccessTime
        {
            get
            {
                nativeBasicInformationBlock = Marshal.PtrToStructure<_FILE_BASIC_INFORMATION>(buffer);
                return nativeBasicInformationBlock.LastAccessTime;
            }

            set
            {
                nativeBasicInformationBlock.LastAccessTime = value;
                Marshal.StructureToPtr<_FILE_BASIC_INFORMATION>(nativeBasicInformationBlock, buffer, true);
            }
        }


        public Int64 LastWriteTime
        {
            get
            {
                nativeBasicInformationBlock = Marshal.PtrToStructure<_FILE_BASIC_INFORMATION>(buffer);
                return nativeBasicInformationBlock.LastWriteTime;
            }

            set
            {
                nativeBasicInformationBlock.LastWriteTime = value;
                Marshal.StructureToPtr<_FILE_BASIC_INFORMATION>(nativeBasicInformationBlock, buffer, true);
            }
        }


        public Int64 ChangeTime
        {
            get
            {
                nativeBasicInformationBlock = Marshal.PtrToStructure<_FILE_BASIC_INFORMATION>(buffer);
                return nativeBasicInformationBlock.ChangeTime;
            }

            set
            {
                nativeBasicInformationBlock.ChangeTime = value;
                Marshal.StructureToPtr<_FILE_BASIC_INFORMATION>(nativeBasicInformationBlock, buffer, true);
            }
        }

        public UInt32 FileAttributes
        {
            get
            {
                nativeBasicInformationBlock = Marshal.PtrToStructure<_FILE_BASIC_INFORMATION>(buffer);
                return nativeBasicInformationBlock.FileAttributes;
            }

            set
            {
                nativeBasicInformationBlock.FileAttributes = value;
                Marshal.StructureToPtr<_FILE_BASIC_INFORMATION>(nativeBasicInformationBlock, buffer, true);
            }
        }

        public FILE_BASIC_INFORMATION(Int64 CreationTime = 0, Int64 LastAccessTime = 0, Int64 LastWriteTime = 0, Int64 ChangeTime = 0, UInt32 FileAttributes = 0)
        {
            unsafe
            {
                this.buffer = Marshal.AllocHGlobal(sizeof(_FILE_BASIC_INFORMATION));
            }
            nativeBasicInformationBlock = new _FILE_BASIC_INFORMATION();
            nativeBasicInformationBlock.CreationTime = CreationTime;
            nativeBasicInformationBlock.LastAccessTime = LastAccessTime;
            nativeBasicInformationBlock.LastWriteTime = LastWriteTime;
            nativeBasicInformationBlock.ChangeTime = ChangeTime;

            Marshal.StructureToPtr(nativeBasicInformationBlock, buffer, true);
        }

        private FILE_BASIC_INFORMATION(IntPtr Buffer)
        {
            unsafe
            {
                buffer = Marshal.AllocHGlobal(sizeof(_FILE_BASIC_INFORMATION));
            }
            nativeBasicInformationBlock = new _FILE_BASIC_INFORMATION();
            Marshal.PtrToStructure<_FILE_BASIC_INFORMATION>(Buffer, nativeBasicInformationBlock);
            Marshal.StructureToPtr(nativeBasicInformationBlock, buffer, true);
        }

        public FILE_BASIC_INFORMATION()
        {
            buffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(_FILE_BASIC_INFORMATION)));
            nativeBasicInformationBlock = new _FILE_BASIC_INFORMATION();
            Marshal.StructureToPtr(nativeBasicInformationBlock, buffer, true);
        }

        ~FILE_BASIC_INFORMATION()
        {
            if (IntPtr.Zero != buffer)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }
        }

        public static implicit operator IntPtr(FILE_BASIC_INFORMATION fileBasicInformation)
        {
            return fileBasicInformation.buffer;
        }

        public static implicit operator FILE_BASIC_INFORMATION(IntPtr buffer)
        {
            return new FILE_BASIC_INFORMATION(buffer);
        }


    }

    public class FILE_STANDARD_INFORMATION
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_STANDARD_INFORMATION
        {
            [FieldOffset(0)] public Int64 AllocationSize = 0;
            [FieldOffset(8)] public Int64 EndOfFile = 0;
            [FieldOffset(16)] public UInt32 NumberOfLinks = 0;
            [FieldOffset(24)] public bool DeletePending = false;
            [FieldOffset(25)] public bool Directory = false;

            public _FILE_STANDARD_INFORMATION()
            {
            }
        }

        private _FILE_STANDARD_INFORMATION nativeStandardInformation;
        private IntPtr buffer = IntPtr.Zero;

        public Int64 AllocationSize
        {
            get
            {
                nativeStandardInformation = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION>(buffer);
                return nativeStandardInformation.AllocationSize;
            }

            set
            {
                nativeStandardInformation.AllocationSize = value;
                Marshal.StructureToPtr<_FILE_STANDARD_INFORMATION>(nativeStandardInformation, buffer, true);
            }
        }
        public Int64 EndOfFile
        {
            get
            {
                nativeStandardInformation = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION>(buffer);
                return nativeStandardInformation.EndOfFile;
            }

            set
            {
                nativeStandardInformation.EndOfFile = value;
                Marshal.StructureToPtr<_FILE_STANDARD_INFORMATION>(nativeStandardInformation, buffer, true);
            }
        }

        public UInt32 NumberOfLinks
        {
            get
            {
                nativeStandardInformation = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION>(buffer);
                return nativeStandardInformation.NumberOfLinks;
            }

            set
            {
                nativeStandardInformation.NumberOfLinks = value;
                Marshal.StructureToPtr<_FILE_STANDARD_INFORMATION>(nativeStandardInformation, buffer, true);
            }
        }

        public bool DeletePending
        {
            get
            {
                nativeStandardInformation = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION>(buffer);
                return nativeStandardInformation.DeletePending;
            }

            set
            {
                nativeStandardInformation.DeletePending = value;
                Marshal.StructureToPtr<_FILE_STANDARD_INFORMATION>(nativeStandardInformation, buffer, true);
            }
        }


        public bool Directory
        {
            get
            {
                nativeStandardInformation = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION>(buffer);
                return nativeStandardInformation.Directory;
            }

            set
            {
                nativeStandardInformation.Directory = value;
                Marshal.StructureToPtr<_FILE_STANDARD_INFORMATION>(nativeStandardInformation, buffer, true);
            }
        }

    }

    public class FILE_STANDARD_INFORMATION_EX
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_STANDARD_INFORMATION_EX
        {
            [FieldOffset(0)] public Int64 AllocationSize = 0;
            [FieldOffset(8)] public Int64 EndOfFile = 0;
            [FieldOffset(16)] public UInt32 NumberOfLinks = 0;
            [FieldOffset(24)] public bool DeletePending = false;
            [FieldOffset(25)] public bool Directory = false;
            [FieldOffset(26)] public bool AlternateStream = false;
            [FieldOffset(27)] public bool MetadataAttribute = false;

            public _FILE_STANDARD_INFORMATION_EX()
            {
            }
        }

        private _FILE_STANDARD_INFORMATION_EX nativeStandardInformation;
        private IntPtr buffer = IntPtr.Zero;

        public Int64 AllocationSize
        {
            get
            {
                nativeStandardInformation = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION_EX>(buffer);
                return nativeStandardInformation.AllocationSize;
            }

            set
            {
                nativeStandardInformation.AllocationSize = value;
                Marshal.StructureToPtr<_FILE_STANDARD_INFORMATION_EX>(nativeStandardInformation, buffer, true);
            }
        }
        public Int64 EndOfFile
        {
            get
            {
                nativeStandardInformation = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION_EX>(buffer);
                return nativeStandardInformation.EndOfFile;
            }

            set
            {
                nativeStandardInformation.EndOfFile = value;
                Marshal.StructureToPtr<_FILE_STANDARD_INFORMATION_EX>(nativeStandardInformation, buffer, true);
            }
        }

        public UInt32 NumberOfLinks
        {
            get
            {
                nativeStandardInformation = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION_EX>(buffer);
                return nativeStandardInformation.NumberOfLinks;
            }

            set
            {
                nativeStandardInformation.NumberOfLinks = value;
                Marshal.StructureToPtr<_FILE_STANDARD_INFORMATION_EX>(nativeStandardInformation, buffer, true);
            }
        }

        public bool DeletePending
        {
            get
            {
                nativeStandardInformation = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION_EX>(buffer);
                return nativeStandardInformation.DeletePending;
            }

            set
            {
                nativeStandardInformation.DeletePending = value;
                Marshal.StructureToPtr<_FILE_STANDARD_INFORMATION_EX>(nativeStandardInformation, buffer, true);
            }
        }


        public bool Directory
        {
            get
            {
                nativeStandardInformation = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION_EX>(buffer);
                return nativeStandardInformation.Directory;
            }

            set
            {
                nativeStandardInformation.Directory = value;
                Marshal.StructureToPtr<_FILE_STANDARD_INFORMATION_EX>(nativeStandardInformation, buffer, true);
            }
        }

        public bool AlternateStream
        {
            get
            {
                nativeStandardInformation = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION_EX>(buffer);
                return nativeStandardInformation.AlternateStream;
            }

            set
            {
                nativeStandardInformation.AlternateStream = value;
                Marshal.StructureToPtr<_FILE_STANDARD_INFORMATION_EX>(nativeStandardInformation, buffer, true);
            }
        }

        public bool MetadataAttribute
        {
            get
            {
                nativeStandardInformation = Marshal.PtrToStructure<_FILE_STANDARD_INFORMATION_EX>(buffer);
                return nativeStandardInformation.MetadataAttribute;
            }

            set
            {
                nativeStandardInformation.MetadataAttribute = value;
                Marshal.StructureToPtr<_FILE_STANDARD_INFORMATION_EX>(nativeStandardInformation, buffer, true);
            }
        }

    }

    public class FILE_INTERNAL_INFORMATION
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_INTERNAL_INFORMATION
        {
            [FieldOffset(0)] public Int64 IndexNumber;
        }

        private _FILE_INTERNAL_INFORMATION nativeInternalInformation;
        public const int MinimumBufferSize = 8;
        public Int64 IndexNumber => nativeInternalInformation.IndexNumber;

        public FILE_INTERNAL_INFORMATION(IntPtr Buffer)
        {
            nativeInternalInformation = Marshal.PtrToStructure<_FILE_INTERNAL_INFORMATION>(Buffer);
        }
    }

    public class FILE_ID_INFORMATION
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_ID_INFORMATION
        {
            [FieldOffset(0)] UInt64 VolumeSerialNumber;
            [FieldOffset(8)] fixed byte FileId[16];
        }

        private _FILE_ID_INFORMATION nativeIdInformation;
        public const int MinimumBufferSize = 24;
        public UInt64 VolumeSerialNumber => VolumeSerialNumber;
        public FILE_ID_128 FileId;

        FILE_ID_INFORMATION(IntPtr Buffer)
        {
            nativeIdInformation = Marshal.PtrToStructure<_FILE_ID_INFORMATION>(Buffer);
            FileId = new FILE_ID_128(Buffer + 8);
        }
    }


    public class FILE_NETWORK_OPEN_INFORMATION
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        private unsafe struct _FILE_NETWORK_OPEN_INFORMATION
        {
            [FieldOffset(0)] public Int64 CreationTime;
            [FieldOffset(8)] public Int64 LastAccessTime;
            [FieldOffset(16)] public Int64 LastWriteTime;
            [FieldOffset(24)] public Int64 ChangeTime;
            [FieldOffset(32)] public Int64 AllocationSize;
            [FieldOffset(40)] public Int64 EndOfFile;
            [FieldOffset(48)] public UInt32 FileAttributes;

            public _FILE_NETWORK_OPEN_INFORMATION()
            {
                CreationTime = 0;
                LastAccessTime = 0;
                LastWriteTime = 0;
                ChangeTime = 0;
                AllocationSize = 0;
                EndOfFile = 0;
                FileAttributes = 0;
            }
        }

        private _FILE_NETWORK_OPEN_INFORMATION nativeOpenInfo;
        public const int MinimumBufferSize = 52; // sizeof (nativeOpenInfo)
        public Int64 CreationTime => nativeOpenInfo.CreationTime;
        public Int64 LastAccessTime => nativeOpenInfo.LastAccessTime;
        public Int64 LastWriteTime => nativeOpenInfo.LastWriteTime;
        public Int64 ChangeTime => nativeOpenInfo.ChangeTime;
        public Int64 AllocationSize => nativeOpenInfo.AllocationSize;
        public Int64 EndOfFile => nativeOpenInfo.EndOfFile;
        public FILE_ATTRIBUTES FileAttributes;

        public FILE_NETWORK_OPEN_INFORMATION(IntPtr Buffer)
        {
            nativeOpenInfo = Marshal.PtrToStructure<_FILE_NETWORK_OPEN_INFORMATION>(Buffer);

            FileAttributes = new FILE_ATTRIBUTES(nativeOpenInfo.FileAttributes);
        }

        public FILE_NETWORK_OPEN_INFORMATION()
        {
            nativeOpenInfo = new _FILE_NETWORK_OPEN_INFORMATION();
        }

    }

    public class FILE_STREAM_INFORMATION
    {
        public class FILE_STREAM_INFO
        {
            [StructLayout(LayoutKind.Explicit, Pack = 1)]
            private unsafe struct _FILE_STREAM_INFORMATION
            {
                [FieldOffset(0)] public UInt32 NextEntryOffset;
                [FieldOffset(4)] public UInt32 StreamNameLength;
                [FieldOffset(8)] public Int64 StreamSize;
                [FieldOffset(16)] public Int64 StreamAllocationSize;
            }

            private const int StreamNameOffset = 24;
            private _FILE_STREAM_INFORMATION nativeStreamInformation;
            public Int64 StreamSize => nativeStreamInformation.StreamSize;
            public Int64 StreamAllocationSize => nativeStreamInformation.StreamAllocationSize;
            public string StreamName;

            public FILE_STREAM_INFO(IntPtr Buffer, ref int NextEntryOffset)
            {
                nativeStreamInformation = Marshal.PtrToStructure<_FILE_STREAM_INFORMATION>(Buffer);
                StreamName = Marshal.PtrToStringUni(Buffer + StreamNameOffset, (int)(nativeStreamInformation.StreamNameLength / 2));
                NextEntryOffset = (int) nativeStreamInformation.NextEntryOffset;
            }

        }

        public List<FILE_STREAM_INFO> Entries = new List<FILE_STREAM_INFO>(16);

        public uint AddEntries(IntPtr Buffer, UInt32 BufferLength)
        {
            uint count = 0;

            if (IntPtr.Zero != Buffer)
            {
                IntPtr current = Buffer;

                while (current.ToInt64() < (Buffer.ToInt64() + BufferLength))
                {
                    int nextOffset = 0;
                    Entries.Add(new FILE_STREAM_INFO(current, ref nextOffset));
                    count++;
                    current = current + nextOffset;
                }
            }

            return count;
        }

        FILE_STREAM_INFORMATION()
        {

        }
    }

}