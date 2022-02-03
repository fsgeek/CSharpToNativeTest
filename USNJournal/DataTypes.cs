﻿using NativeSupportLibrary;
using System.Runtime.InteropServices;

namespace USNJournal
{
    public class ControlCodes
    {
        public UInt32 FSCTL_ENUM_USN_DATA { get { return Ioctl.CTL_CODE(Ioctl.FILE_DEVICE_FILE_SYSTEM, 44, Ioctl.METHOD_NEITHER, Ioctl.FILE_ANY_ACCESS); } }
        public UInt32 FSCTL_READ_USN_JOURNAL { get { return Ioctl.CTL_CODE(Ioctl.FILE_DEVICE_FILE_SYSTEM, 46, Ioctl.METHOD_NEITHER, Ioctl.FILE_ANY_ACCESS); } } // READ_USN_JOURNAL_DATA, USN
        public UInt32 FSCTL_CREATE_USN_JOURNAL { get { return Ioctl.CTL_CODE(Ioctl.FILE_DEVICE_FILE_SYSTEM, 57, Ioctl.METHOD_NEITHER, Ioctl.FILE_ANY_ACCESS); } } // CREATE_USN_JOURNAL_DATA,
        public UInt32 FSCTL_READ_FILE_USN_DATA { get { return Ioctl.CTL_CODE(Ioctl.FILE_DEVICE_FILE_SYSTEM, 58, Ioctl.METHOD_NEITHER, Ioctl.FILE_ANY_ACCESS); } } // Read the Usn Record for a file
        public UInt32 FSCTL_WRITE_USN_CLOSE_RECORD { get { return Ioctl.CTL_CODE(Ioctl.FILE_DEVICE_FILE_SYSTEM, 59, Ioctl.METHOD_NEITHER, Ioctl.FILE_ANY_ACCESS); } } // Generate Close Usn Record
        public UInt32 FSCTL_QUERY_USN_JOURNAL { get { return Ioctl.CTL_CODE(Ioctl.FILE_DEVICE_FILE_SYSTEM, 61, Ioctl.METHOD_BUFFERED, Ioctl.FILE_ANY_ACCESS); } }
        public UInt32 FSCTL_DELETE_USN_JOURNAL { get { return Ioctl.CTL_CODE(Ioctl.FILE_DEVICE_FILE_SYSTEM, 62, Ioctl.METHOD_BUFFERED, Ioctl.FILE_ANY_ACCESS); } }
        public UInt32 FSCTL_USN_TRACK_MODIFIED_RANGES { get { return Ioctl.CTL_CODE(Ioctl.FILE_DEVICE_FILE_SYSTEM, 189, Ioctl.METHOD_BUFFERED, Ioctl.FILE_ANY_ACCESS); } } // USN_TRACK_MODIFIED_RANGES
        public UInt32 FSCTL_READ_UNPRIVILEGED_USN_JOURNAL { get { return Ioctl.CTL_CODE(Ioctl.FILE_DEVICE_FILE_SYSTEM, 234, Ioctl.METHOD_NEITHER, Ioctl.FILE_ANY_ACCESS); } } // READ_USN_JOURNAL_DATA, USN

    }

    public class MFT_ENUM_DATA
    {
        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _MFT_ENUM_DATA
        {
            [FieldOffset(0)] public UInt32 StartFileReferenceNumber; // field size is 8
            [FieldOffset(8)] public UInt32 LowUsn; // field size is 8
            [FieldOffset(16)] public UInt32 HighUsn; // field size is 8
            [FieldOffset(24)] public UInt16 MinMajorVersion; // field size is 2
            [FieldOffset(26)] public UInt16 MaxMajorVersion; // field size is 2
        }

        _MFT_ENUM_DATA mftEnumData;
        IntPtr buffer = IntPtr.Zero;

        UInt32 dataVersion = 0;
        UInt32 bufferVersion = 0;

        private void UpdateData()
        {
            if (dataVersion > bufferVersion)
            {
                throw new InvalidDataException("DataVersion cannot be greater than Buffer version for a read-only class!");
            }

            if (0 == bufferVersion)
            {
                throw new InvalidDataException("Invalid buffer - nothing has been loaded yet!");
            }

            if (dataVersion < bufferVersion)
            {
                Marshal.PtrToStructure(buffer, mftEnumData);
                dataVersion = bufferVersion;
            }
        }

        public UInt32 StartFileReferenceNumber { get { UpdateData(); return mftEnumData.StartFileReferenceNumber; } }
        public UInt32 LowUsn { get { UpdateData(); return mftEnumData.LowUsn; } }
        public UInt32 HighUsn { get { UpdateData(); return mftEnumData.HighUsn; } }
        public UInt16 MinMajorVersion { get { UpdateData(); return mftEnumData.MinMajorVersion; } }
        public UInt16 MaxMajorVersion { get { UpdateData(); return mftEnumData.MaxMajorVersion; } }

        public MFT_ENUM_DATA()
        {
            buffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(MFT_ENUM_DATA)));
        }

        ~MFT_ENUM_DATA()
        {
            if (IntPtr.Zero != buffer)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }
        }

        public static implicit operator IntPtr(MFT_ENUM_DATA enumData)
        {
            enumData.bufferVersion++; // assume this updated the buffer contents
            return enumData.buffer;
        }
    }

    public class CREATE_USN_JOURNAL_DATA
    {
        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _CREATE_USN_JOURNAL_DATA
        {
            [FieldOffset(0)] public UInt64 MaximumSize;
            [FieldOffset(8)] public UInt64 AllocationData;
        }

        private _CREATE_USN_JOURNAL_DATA createUsnJournalData;
        private IntPtr buffer = IntPtr.Zero;

        public UInt64 MaximumSize
        {
            get { return createUsnJournalData.MaximumSize; }
            set { dataVersion++; createUsnJournalData.MaximumSize = value; }
        }
        public UInt64 AllocationData
        {
            get { return createUsnJournalData.AllocationData; }
            set { dataVersion++; createUsnJournalData.AllocationData = value; }
        }


        UInt32 dataVersion = 0;
        UInt32 bufferVersion = 0;

        public CREATE_USN_JOURNAL_DATA(UInt64 MaximumSize = (UInt64)1024 * 1024 * 1024 * 1024, UInt64 AllocationData = 1024 * 1024 * 1024)
        {
            createUsnJournalData.MaximumSize = MaximumSize;
            createUsnJournalData.AllocationData = AllocationData;
            dataVersion = 1;
        }

        ~CREATE_USN_JOURNAL_DATA()
        {
            if (IntPtr.Zero != buffer)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }
        }

        public static implicit operator IntPtr(CREATE_USN_JOURNAL_DATA cujd)
        {
            if (cujd.bufferVersion != cujd.dataVersion)
            {
                if (0 == cujd.dataVersion)
                {
                    throw new InvalidDataException("Data version is 0, not valid!");
                }

                if (IntPtr.Zero == cujd.buffer)
                {
                    cujd.buffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(_CREATE_USN_JOURNAL_DATA)));
                }
                Marshal.StructureToPtr(cujd.createUsnJournalData, cujd.buffer, true);
                cujd.bufferVersion = cujd.dataVersion;
            }
            return cujd.buffer;
        }
    }

    public class READ_USN_JOURNAL_DATA
    {
        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _READ_USN_JOURNAL_DATA
        {
            [FieldOffset(0)] public UInt32 StartUsn; // field size is 8
            [FieldOffset(8)] public UInt32 ReasonMask; // field size is 4
            [FieldOffset(12)] public UInt32 ReturnOnlyOnClose; // field size is 4
            [FieldOffset(16)] public UInt32 Timeout; // field size is 8
            [FieldOffset(24)] public UInt32 BytesToWaitFor; // field size is 8
            [FieldOffset(32)] public UInt32 UsnJournalID; // field size is 8
            [FieldOffset(40)] public UInt16 MinMajorVersion; // field size is 2
            [FieldOffset(42)] public UInt16 MaxMajorVersion; // field size is 2
        }

        private _READ_USN_JOURNAL_DATA usnJournalData;
        private IntPtr buffer = IntPtr.Zero;

        private UInt32 dataVersion = 0;
        private UInt32 bufferVersion = 0;

        public UInt32 StartUsn { get { UpdateData(); return usnJournalData.StartUsn; } }
        public UInt32 ReasonMask { get { UpdateData(); return usnJournalData.ReasonMask; } }
        public UInt32 ReturnOnlyOnClose { get { UpdateData(); return usnJournalData.ReturnOnlyOnClose; } }
        public UInt32 Timeout { get { UpdateData(); return usnJournalData.Timeout; } }
        public UInt32 BytesToWaitFor { get { UpdateData(); return usnJournalData.BytesToWaitFor; } }
        public UInt32 UsnJournalID { get { UpdateData(); return usnJournalData.UsnJournalID; } }
        public UInt16 MinMajorVersion { get { UpdateData(); return usnJournalData.MinMajorVersion; } }
        public UInt16 MaxMajorVersion { get { UpdateData(); return usnJournalData.MaxMajorVersion; } }


        private void UpdateData()
        {
            if (dataVersion > bufferVersion)
            {
                throw new InvalidDataException("DataVersion cannot be greater than Buffer version for a read-only class!");
            }

            if (0 == bufferVersion)
            {
                throw new InvalidDataException("Invalid buffer - nothing has been loaded yet!");
            }

            if (dataVersion < bufferVersion)
            {
                Marshal.PtrToStructure(buffer, usnJournalData);
                dataVersion = bufferVersion;
            }
        }

        public READ_USN_JOURNAL_DATA()
        {
            buffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(READ_USN_JOURNAL_DATA)));
        }

        ~READ_USN_JOURNAL_DATA()
        {
            if (IntPtr.Zero != buffer)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }
        }

        public static implicit operator IntPtr(READ_USN_JOURNAL_DATA enumData)
        {
            enumData.bufferVersion++; // assume this updated the buffer contents
            return enumData.buffer;
        }
    }

    public class USN_TRACK_MODIFIED_RANGES
    {
        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _USN_TRACK_MODIFIED_RANGES
        {
            [FieldOffset(0)] UInt32 Flags;
            [FieldOffset(8)] UInt64 ChunkSize;
            [FieldOffset(16)] UInt64 FileSizeThreshold;
        }
    }

    public class USN_RANGE_TRACK_OUTPUT
    {
        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _USN_RANGE_TRACK_OUTPUT
        {
            [FieldOffset(0)] UInt64 Usn;
        }

        public const UInt32 FLAG_USN_TRACK_MODIFIED_RANGES_ENABLE = 0x00000001;

    }

    public class USN_RECORD
    {

        #region constants
        public const UInt32 USN_PAGE_SIZE = (UInt32)(0x1000);

        public const UInt32 USN_REASON_DATA_OVERWRITE = (UInt32)(0x00000001);
        public const UInt32 USN_REASON_DATA_EXTEND = (UInt32)(0x00000002);
        public const UInt32 USN_REASON_DATA_TRUNCATION = (UInt32)(0x00000004);
        public const UInt32 USN_REASON_NAMED_DATA_OVERWRITE = (UInt32)(0x00000010);
        public const UInt32 USN_REASON_NAMED_DATA_EXTEND = (UInt32)(0x00000020);
        public const UInt32 USN_REASON_NAMED_DATA_TRUNCATION = (UInt32)(0x00000040);
        public const UInt32 USN_REASON_FILE_CREATE = (UInt32)(0x00000100);
        public const UInt32 USN_REASON_FILE_DELETE = (UInt32)(0x00000200);
        public const UInt32 USN_REASON_EA_CHANGE = (UInt32)(0x00000400);
        public const UInt32 USN_REASON_SECURITY_CHANGE = (UInt32)(0x00000800);
        public const UInt32 USN_REASON_RENAME_OLD_NAME = (UInt32)(0x00001000);
        public const UInt32 USN_REASON_RENAME_NEW_NAME = (UInt32)(0x00002000);
        public const UInt32 USN_REASON_INDEXABLE_CHANGE = (UInt32)(0x00004000);
        public const UInt32 USN_REASON_BASIC_INFO_CHANGE = (UInt32)(0x00008000);
        public const UInt32 USN_REASON_HARD_LINK_CHANGE = (UInt32)(0x00010000);
        public const UInt32 USN_REASON_COMPRESSION_CHANGE = (UInt32)(0x00020000);
        public const UInt32 USN_REASON_ENCRYPTION_CHANGE = (UInt32)(0x00040000);
        public const UInt32 USN_REASON_OBJECT_ID_CHANGE = (UInt32)(0x00080000);
        public const UInt32 USN_REASON_REPARSE_POINT_CHANGE = (UInt32)(0x00100000);
        public const UInt32 USN_REASON_STREAM_CHANGE = (UInt32)(0x00200000);
        public const UInt32 USN_REASON_TRANSACTED_CHANGE = (UInt32)(0x00400000);
        public const UInt32 USN_REASON_INTEGRITY_CHANGE = (UInt32)(0x00800000);
        public const UInt32 USN_REASON_DESIRED_STORAGE_CLASS_CHANGE = (UInt32)(0x01000000);
        public const UInt32 USN_REASON_CLOSE = (UInt32)(0x80000000);

        public const UInt32 USN_SOURCE_DATA_MANAGEMENT = (UInt32)(0x00000001);
        public const UInt32 USN_SOURCE_AUXILIARY_DATA = (UInt32)(0x00000002);
        public const UInt32 USN_SOURCE_REPLICATION_MANAGEMENT = (UInt32)(0x00000004);
        public const UInt32 USN_SOURCE_CLIENT_REPLICATION_MANAGEMENT = (UInt32)(0x00000008);

        #endregion constants

        public static string? Reason(UInt32 Reason)
        {
            string reason = "Unknown";
            switch (Reason)
            {
                case USN_REASON_DATA_OVERWRITE:
                    reason = "USN_REASON_DATA_OVERWRITE";
                    break;
                case USN_REASON_DATA_EXTEND:
                    reason = "USN_REASON_DATA_EXTEND";
                    break;
                case USN_REASON_DATA_TRUNCATION:
                    reason = "USN_REASON_DATA_TRUNCATION";
                    break;
                case USN_REASON_NAMED_DATA_OVERWRITE:
                    reason = "USN_REASON_NAMED_DATA_OVERWRITE";
                    break;
                case USN_REASON_NAMED_DATA_EXTEND:
                    reason = "USN_REASON_NAMED_DATA_EXTEND";
                    break;
                case USN_REASON_NAMED_DATA_TRUNCATION:
                    reason = "USN_REASON_NAMED_DATA_TRUNCATION";
                    break;
                case USN_REASON_FILE_CREATE:
                    reason = "USN_REASON_FILE_CREATE";
                    break;
                case USN_REASON_FILE_DELETE:
                    reason = "USN_REASON_FILE_DELETE";
                    break;
                case USN_REASON_EA_CHANGE:
                    reason = "USN_REASON_EA_CHANGE";
                    break;
                case USN_REASON_SECURITY_CHANGE:
                    reason = "USN_REASON_SECURITY_CHANGE";
                    break;
                case USN_REASON_RENAME_OLD_NAME:
                    reason = "USN_REASON_RENAME_OLD_NAME";
                    break;
                case USN_REASON_RENAME_NEW_NAME:
                    reason = "USN_REASON_RENAME_NEW_NAME";
                    break;
                case USN_REASON_INDEXABLE_CHANGE:
                    reason = "USN_REASON_INDEXABLE_CHANGE";
                    break;
                case USN_REASON_BASIC_INFO_CHANGE:
                    reason = "USN_REASON_BASIC_INFO_CHANGE";
                    break;
                case USN_REASON_HARD_LINK_CHANGE:
                    reason = "USN_REASON_HARD_LINK_CHANGE";
                    break;
                case USN_REASON_COMPRESSION_CHANGE:
                    reason = "USN_REASON_COMPRESSION_CHANGE";
                    break;
                case USN_REASON_ENCRYPTION_CHANGE:
                    reason = "USN_REASON_ENCRYPTION_CHANGE";
                    break;
                case USN_REASON_OBJECT_ID_CHANGE:
                    reason = "USN_REASON_OBJECT_ID_CHANGE";
                    break;
                case USN_REASON_REPARSE_POINT_CHANGE:
                    reason = "USN_REASON_REPARSE_POINT_CHANGE";
                    break;
                case USN_REASON_STREAM_CHANGE:
                    reason = "USN_REASON_STREAM_CHANGE";
                    break;
                case USN_REASON_TRANSACTED_CHANGE:
                    reason = "USN_REASON_TRANSACTED_CHANGE";
                    break;
                case USN_REASON_INTEGRITY_CHANGE:
                    reason = "USN_REASON_INTEGRITY_CHANGE";
                    break;
                case USN_REASON_DESIRED_STORAGE_CLASS_CHANGE:
                    reason = "USN_REASON_DESIRED_STORAGE_CLASS_CHANGE";
                    break;
                case USN_REASON_CLOSE:
                    reason = "USN_REASON_CLOSE";
                    break;
            }

            return reason;
        }

        public static string? Source(UInt32 Source)
        {
            string source = "Unknown";

            switch (Source)
            {
                case USN_SOURCE_DATA_MANAGEMENT: //UInt32)(0x00000001);
                    source = "USN_SOURCE_DATA_MANAGEMENT";
                    break;
                case USN_SOURCE_AUXILIARY_DATA: //UInt32)(0x00000002);
                    source = "USN_SOURCE_AUXILIARY_DATA";
                    break;
                case USN_SOURCE_REPLICATION_MANAGEMENT: //UInt32)(0x00000004);
                    source = "USN_SOURCE_REPLICATION_MANAGEMENT";
                    break;
                case USN_SOURCE_CLIENT_REPLICATION_MANAGEMENT: //UInt32)(0x00000008);
                    source = "USN_SOURCE_CLIENT_REPLICATION_MANAGEMENT";
                    break;
            }

            return source;

        }

        //
        //  The initial Major.Minor version of the Usn record will be 2.0.
        //  In general, the MinorVersion may be changed if fields are added
        //  to this structure in such a way that the previous version of the
        //  software can still correctly the fields it knows about.  The
        //  MajorVersion should only be changed if the previous version of
        //  any software using this structure would incorrectly handle new
        //  records due to structure changes.
        //
        //  The first update to this will force the structure to version 2.0.
        //  This will add the extended information about the source as
        //  well as indicate the file name offset within the structure.
        //
        //  The following structure is returned with these fsctls.
        //
        //      FSCTL_READ_USN_JOURNAL
        //      FSCTL_READ_FILE_USN_DATA
        //      FSCTL_ENUM_USN_DATA
        //
        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private unsafe struct FILE_ID_128
        {
            [FieldOffset(0)] fixed byte Identifier[16];
            [FieldOffset(0)] UInt64 LowPart;
            [FieldOffset(8)] UInt64 HighPart;
        }

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        public struct USN_RECORD_EXTENT
        {
            [FieldOffset(0)] public Int64 Offset; // field size is 8
            [FieldOffset(8)] public Int64 Length; // field size is 8
        }

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _USN_RECORD
        {
            [FieldOffset(0)] public UInt32 RecordLength;
            [FieldOffset(4)] public UInt16 MajorVersion;
            [FieldOffset(6)] public UInt16 MinorVersion;
            [FieldOffset(8)] public FILE_ID_128 FileReferenceNumber;
            [FieldOffset(24)] public FILE_ID_128 ParentFileReferenceNumber;
            [FieldOffset(40)] public UInt64 Usn;
            [FieldOffset(48)] public UInt32 Reason; // field size is 4
            [FieldOffset(56)] public UInt32 RemainingExtents; // field size is 4
            [FieldOffset(52)] public UInt32 SourceInfo; // field size is 4
            [FieldOffset(60)] public UInt16 NumberOfExtents; // field size is 2
            [FieldOffset(62)] public UInt16 ExtentSize; // field size is 2
                                                        // Variable number of extents to follow
        }

        private IntPtr buffer = IntPtr.Zero;
        private _USN_RECORD record;
        private List<USN_RECORD_EXTENT> extents;
        private UInt32 bufferVersion;
        private UInt32 dataVersion;

        public UInt32 recordLength
        {
            get { if (dataVersion != bufferVersion) UnpackBuffer();  return recordLength; }
        }
        public UInt16 MajorVersion => record.MajorVersion;
        public UInt16 MinorVersion => record.MinorVersion;
        public UInt32 ReasonType => record.Reason;

        public List<USN_RECORD_EXTENT> Extents
        {
            get
            {
                throw new NotImplementedException("Have not implemented extent unpacking yet.");
            }
        }

        private void UnpackBuffer()
        {
            if (dataVersion == bufferVersion)
            {
                return;
            }

            Marshal.PtrToStructure(buffer, record);
            if ((record.NumberOfExtents > 0) || (record.RemainingExtents > 0))
            {
                throw new NotImplementedException("Have not implemented extent unpacking yet.");
            }

            dataVersion = bufferVersion;
        }

        public USN_RECORD()
        {
            buffer = Marshal.AllocHGlobal((int) USN_PAGE_SIZE);
        }

        ~USN_RECORD()
        {
            if (IntPtr.Zero != buffer)
            {
                Marshal.FreeHGlobal(buffer);
                buffer = IntPtr.Zero;
            }
        }
    }


    //
    //==================== FSCTL_QUERY_USN_JOURNAL ======================
    //
    //  Structure for FSCTL_QUERY_USN_JOURNAL
    //
    public class USN_JOURNAL_DATA
    {
        /*
    typedef struct {

    ULONGLONG UsnJournalID;
    USN FirstUsn;
    USN NextUsn;
    USN LowestValidUsn;
    USN MaxUsn;
    ULONGLONG MaximumSize;
    ULONGLONG AllocationDelta;

    } USN_JOURNAL_DATA_V0, *PUSN_JOURNAL_DATA_V0;

    typedef struct {

    ULONGLONG UsnJournalID;
    USN FirstUsn;
    USN NextUsn;
    USN LowestValidUsn;
    USN MaxUsn;
    ULONGLONG MaximumSize;
    ULONGLONG AllocationDelta;
    USHORT MinSupportedMajorVersion;
    USHORT MaxSupportedMajorVersion;

    } USN_JOURNAL_DATA_V1, *PUSN_JOURNAL_DATA_V1;

    typedef struct {

    ULONGLONG UsnJournalID;
    USN FirstUsn;
    USN NextUsn;
    USN LowestValidUsn;
    USN MaxUsn;
    ULONGLONG MaximumSize;
    ULONGLONG AllocationDelta;
    USHORT MinSupportedMajorVersion;
    USHORT MaxSupportedMajorVersion;
    ULONG Flags;
    ULONGLONG RangeTrackChunkSize;
    LONGLONG RangeTrackFileSizeThreshold;

    } USN_JOURNAL_DATA_V2, *PUSN_JOURNAL_DATA_V2;


    #if (NTDDI_VERSION >= NTDDI_WIN8)
    typedef USN_JOURNAL_DATA_V1 USN_JOURNAL_DATA, *PUSN_JOURNAL_DATA;
    #else
    typedef USN_JOURNAL_DATA_V0 USN_JOURNAL_DATA, *PUSN_JOURNAL_DATA;
    #endif
        */
    }

    public class DELETE_USN_JOURNAL_DATA
    {
        /*
        //
        //==================== FSCTL_DELETE_USN_JOURNAL ======================
        //
        //  Structure for FSCTL_DELETE_USN_JOURNAL
        //

        typedef struct {

        ULONGLONG UsnJournalID;
        ULONG DeleteFlags;

        } DELETE_USN_JOURNAL_DATA, *PDELETE_USN_JOURNAL_DATA;

        #define USN_DELETE_FLAG_DELETE              (0x00000001)
        #define USN_DELETE_FLAG_NOTIFY              (0x00000002)

        #define USN_DELETE_VALID_FLAGS              (0x00000003)

        #endif
        */
    }
}
