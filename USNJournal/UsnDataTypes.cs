using NativeSupportLibrary;
using static NativeCalls.SystemCalls;
using System.Runtime.InteropServices;
using MountManagerLibrary;
using Microsoft.Win32.SafeHandles;
using System.Text.Json;
using System.Text.Json.Serialization;
using Serilog;
using System.Diagnostics;
using USNJournal;


//
// See: https://www.genericgamedev.com/general/converting-between-structs-and-byte-arrays/
//
// This argues for building a generic model of serialization that is based upon a template class.
// While the binary reader/writer model is slightly faster as the author points out, it means
// writing a lot more code.
//
// I'm not going back to re-do this.  I do think it is wise to consider using the serializable type model
// moving forward
//
namespace USNJournal
{
    // This is a singleton
    public sealed class ControlCodes
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

        private static readonly Lazy<ControlCodes> _ControlCodes = new Lazy<ControlCodes>((() => new ControlCodes()));

        public static ControlCodes Instance { get { return _ControlCodes.Value; } }

        private ControlCodes()
        {
        }

    }

    public class MFT_ENUM_DATA
    {
        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _MFT_ENUM_DATA
        {
            [FieldOffset(0)] public UInt64 StartFileReferenceNumber; // field size is 8
            [FieldOffset(8)] public UInt64 LowUsn; // field size is 8
            [FieldOffset(16)] public UInt64 HighUsn; // field size is 8
            [FieldOffset(24)] public UInt16 MinMajorVersion; // field size is 2
            [FieldOffset(26)] public UInt16 MaxMajorVersion; // field size is 2
        }

        private _MFT_ENUM_DATA mftEnumData;

        private IntPtr buffer = IntPtr.Zero;

        UInt32 dataVersion = 0;
        UInt32 bufferVersion = 0;

        public UInt64 StartFileReferenceNumber
        {
            get { UpdateData(); return mftEnumData.StartFileReferenceNumber; }
            set { mftEnumData.StartFileReferenceNumber = value; }
        }
        public UInt64 LowUsn { get { UpdateData(); return mftEnumData.LowUsn; } }
        public UInt64 HighUsn { get { UpdateData(); return mftEnumData.HighUsn; } }
        public UInt16 MinMajorVersion { get { UpdateData(); return mftEnumData.MinMajorVersion; } }
        public UInt16 MaxMajorVersion { get { UpdateData(); return mftEnumData.MaxMajorVersion; } }

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
                mftEnumData = Marshal.PtrToStructure<_MFT_ENUM_DATA>(buffer);
                dataVersion = bufferVersion;
            }
        }

        public MFT_ENUM_DATA()
        {
            buffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(MFT_ENUM_DATA)));
            mftEnumData = Marshal.PtrToStructure<_MFT_ENUM_DATA>(buffer);
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
            [FieldOffset(0)] public Int64 StartUsn; // field size is 8
            [FieldOffset(8)] public UInt32 ReasonMask; // field size is 4
            [FieldOffset(12)] public UInt32 ReturnOnlyOnClose; // field size is 4
            [FieldOffset(16)] public UInt64 Timeout; // field size is 8
            [FieldOffset(24)] public UInt64 BytesToWaitFor; // field size is 8
            [FieldOffset(32)] public UInt64 UsnJournalID; // field size is 8
            [FieldOffset(40)] public UInt16 MinMajorVersion; // field size is 2
            [FieldOffset(42)] public UInt16 MaxMajorVersion; // field size is 2

            public void DebugLog()
            {
                Log.Debug($"\t           StartUsn: {StartUsn}");
                Log.Debug($"\t         ReasonMask: {ReasonMask}");
                Log.Debug($"\t  ReturnOnlyOnClose: {ReturnOnlyOnClose}");
                Log.Debug($"\t            Timeout: {Timeout}");
                Log.Debug($"\t     BytesToWaitFor: {BytesToWaitFor}");
                Log.Debug($"\t       UsnJournalID: {UsnJournalID}");
                Log.Debug($"\t    MinMajorVersion: {MinMajorVersion}");
                Log.Debug($"\t    MaxMajorVersion: {MaxMajorVersion}");
            }

        }

        private _READ_USN_JOURNAL_DATA usnJournalData;
        private IntPtr buffer = IntPtr.Zero;

        private UInt32 dataVersion = 0;
        private UInt32 bufferVersion = 0;

        public Int64 StartUsn
        {
            get
            {
                UpdateData(); return usnJournalData.StartUsn;
            }

            set
            {
                Debug.Assert(dataVersion >= bufferVersion);
                usnJournalData.StartUsn = value;
                dataVersion++;
            }
        }
        public UInt32 ReasonMask { get { UpdateData(); return usnJournalData.ReasonMask; } }
        public UInt32 ReturnOnlyOnClose { get { UpdateData(); return usnJournalData.ReturnOnlyOnClose; } }
        public UInt64 Timeout { get { UpdateData(); return usnJournalData.Timeout; } }
        public UInt64 BytesToWaitFor { get { UpdateData(); return usnJournalData.BytesToWaitFor; } }
        public UInt64 UsnJournalID { get { UpdateData(); return usnJournalData.UsnJournalID; } }
        public UInt16 MinMajorVersion { get { UpdateData(); return usnJournalData.MinMajorVersion; } }
        public UInt16 MaxMajorVersion { get { UpdateData(); return usnJournalData.MaxMajorVersion; } }

        private void UpdateData()
        {
            if (dataVersion < bufferVersion)
            {
                usnJournalData = Marshal.PtrToStructure<_READ_USN_JOURNAL_DATA>(buffer);
                dataVersion = bufferVersion;
            }
        }

        public READ_USN_JOURNAL_DATA(USN_JOURNAL_DATA JournalData, uint Reason = 0xFFFFFFFF, ulong Timeout = 0, ulong BytesToWaitFor = 0)
        {
            buffer = Marshal.AllocHGlobal(Marshal.SizeOf(usnJournalData));

            usnJournalData.StartUsn = JournalData.FirstUsn;
            usnJournalData.ReasonMask = Reason;
            usnJournalData.Timeout = Timeout;
            usnJournalData.BytesToWaitFor = BytesToWaitFor;
            usnJournalData.UsnJournalID = JournalData.UsnJournalID;
            usnJournalData.MinMajorVersion = JournalData.MinSupportedMajorVersion;
            usnJournalData.MaxMajorVersion = JournalData.MaxSupportedMajorVersion;
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
            Debug.Assert(enumData.dataVersion >= enumData.bufferVersion);
            if (enumData.dataVersion != enumData.bufferVersion)
            {
                Marshal.StructureToPtr(enumData.dataVersion, enumData.buffer, true);
                enumData.bufferVersion = enumData.dataVersion;
            }
            enumData.bufferVersion++; // assume the caller will change it
            return enumData.buffer;
        }

        public string GetJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public NtStatusCode ReadUsnJournal(SafeFileHandle DriveHandle, Int64 FirstUsn, IntPtr Buffer, UInt64 BufferLength, ref IO_STATUS_BLOCK StatusBlock)
        {
            _READ_USN_JOURNAL_DATA data = usnJournalData;

            Marshal.StructureToPtr(data, Buffer, true);

            Log.Debug($"ReadUsnJournal: buffer is at 0x{Buffer:X}, Length is {BufferLength}");

            NtStatusCode status = NtFsControlFile(DriveHandle, ref StatusBlock, ControlCodes.Instance.FSCTL_READ_USN_JOURNAL, Buffer, (UInt32)Marshal.SizeOf(data), Buffer, (UInt32)BufferLength);

            Log.Debug($"ReadUsnJournal: NtFsControlFile returned status {status:x} ({status}) with iosb.status = {StatusBlock.Status:x} ({StatusBlock.Status}) and Information = {StatusBlock.Information}");

            Debug.Assert(NtStatus.NT_SUCCESS(status));

            return status;
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

    public sealed class USN_RECORD
    {
        private static readonly Lazy<USN_RECORD> usn_record = new Lazy<USN_RECORD>(() => new USN_RECORD());

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

        public static string? ReasonToString(UInt32 Reason)
        {
            bool first = true;
            string reason = "";

            if (0!= (Reason & USN_REASON_DATA_OVERWRITE))
            {
                if (!first) { reason += "|"; }
                reason+= "USN_REASON_DATA_OVERWRITE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_DATA_EXTEND))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_DATA_EXTEND";
                first = false;
            }

            if (0 != (Reason & USN_REASON_DATA_TRUNCATION))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_DATA_TRUNCATION";
                first = false;
            }

            if (0 != (Reason & USN_REASON_NAMED_DATA_OVERWRITE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_NAMED_DATA_OVERWRITE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_NAMED_DATA_EXTEND))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_NAMED_DATA_EXTEND";
                first = false;
            }


            if (0 != (Reason & USN_REASON_NAMED_DATA_TRUNCATION))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_NAMED_DATA_TRUNCATION";
                first = false;
            }

            if (0 != (Reason & USN_REASON_FILE_CREATE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_FILE_CREATE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_FILE_DELETE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_FILE_DELETE";
                first = false;
            }


            if (0 != (Reason & USN_REASON_EA_CHANGE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_EA_CHANGE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_SECURITY_CHANGE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_SECURITY_CHANGE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_RENAME_OLD_NAME))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_RENAME_OLD_NAME";
                first = false;
            }

            if (0 != (Reason & USN_REASON_RENAME_NEW_NAME))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_RENAME_NEW_NAME";
                first = false;
            }

            if (0 != (Reason & USN_REASON_INDEXABLE_CHANGE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_INDEXABLE_CHANGE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_BASIC_INFO_CHANGE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_BASIC_INFO_CHANGE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_HARD_LINK_CHANGE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_HARD_LINK_CHANGE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_COMPRESSION_CHANGE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_COMPRESSION_CHANGE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_ENCRYPTION_CHANGE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_ENCRYPTION_CHANGE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_OBJECT_ID_CHANGE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_OBJECT_ID_CHANGE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_REPARSE_POINT_CHANGE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_REPARSE_POINT_CHANGE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_STREAM_CHANGE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_STREAM_CHANGE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_TRANSACTED_CHANGE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_TRANSACTED_CHANGE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_INTEGRITY_CHANGE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_INTEGRITY_CHANGE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_DESIRED_STORAGE_CLASS_CHANGE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_DESIRED_STORAGE_CLASS_CHANGE";
                first = false;
            }

            if (0 != (Reason & USN_REASON_CLOSE))
            {
                if (!first) { reason += "|"; }
                reason += "USN_REASON_CLOSE";
                first = false;
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
        public struct FILE_ID_128
        {
            [StructLayout(LayoutKind.Explicit, Pack = 0)]
            private unsafe struct _FILE_ID_128
            {
                [FieldOffset(0)] public fixed byte Data[16];
                [FieldOffset(0)] public UInt64 LowPart;  // little endian
                [FieldOffset(8)] public UInt64 HighPart;
            }

            private _FILE_ID_128 _fileId = new _FILE_ID_128();

            public UInt64 LowPart { get { return _fileId.LowPart; } }
            public UInt64 HighPart { get { return _fileId.HighPart; } }
            [JsonIgnore]
            public byte[] Data
            {
                get
                {
                    byte[] d = new byte[16];
                    for (int i = 0; i < 16; i++)
                    {
                        unsafe
                        {
                            d[i] = _fileId.Data[i];
                        }
                    }
                    return d;
                }
            }

            public override string? ToString()
            {
                string? str = null;

                str = $"{HighPart:X}:{LowPart:X}";
                return str;
            }

            public static implicit operator FILE_ID_128(UInt64 SmallFid)
            {
                FILE_ID_128 fid = new FILE_ID_128();

                fid._fileId = new _FILE_ID_128();
                fid._fileId.LowPart = SmallFid;
                fid._fileId.HighPart = 0;

                return fid;
            }

        }

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _USN_RECORD_EXTENT
        {
            [FieldOffset(0)] public Int64 Offset; // field size is 8
            [FieldOffset(8)] public Int64 Length; // field size is 8
        }

        public struct USN_RECORD_EXTENT
        {
            private _USN_RECORD_EXTENT _usnExtant;

            public Int64 Offset { get { return _usnExtant.Offset; } }
            public Int64 Length { get { return _usnExtant.Length; } }
        }

        public class USN_RECORD_DATA
        {
            // This is a hideous versioned structure

            [StructLayout(LayoutKind.Explicit, Pack = 0)]

            private struct USN_RECORD_COMMON_HEADER
            {
                [FieldOffset(0)] public UInt32 RecordLength;
                [FieldOffset(4)] public UInt16 MajorVersion;
                [FieldOffset(6)] public UInt16 MinorVersion;
            }

            [StructLayout(LayoutKind.Explicit, Pack = 0)]
            private struct USN_RECORD_V2
            {
                [FieldOffset(0)] public UInt64 FileReferenceNumber;
                [FieldOffset(8)] public UInt64 ParentFileReferenceNumber;
                [FieldOffset(16)] public Int64 Usn;
                [FieldOffset(24)] public Int64 TimeStamp;
                [FieldOffset(32)] public UInt32 Reason;
                [FieldOffset(36)] public UInt32 SourceInfo;
                [FieldOffset(40)] public UInt32 SecurityId;
                [FieldOffset(44)] public UInt32 FileAttributes;
                [FieldOffset(48)] public UInt16 FileNameLength;
                [FieldOffset(50)] public UInt16 FileNameOffset;
                // offset 52 is the wide character name
            }

            private string? _FileName;

            // Technically, I am not using GUIDs here, they
            // just happen to be the right size - 128 bits
            // I might want to see if there is a 128 bit
            // file identifier somewhere in C#.
            [StructLayout(LayoutKind.Explicit, Pack = 0)]
            private struct USN_RECORD_V3
            {
                [FieldOffset(0)] public FILE_ID_128 FileReferenceNumber;
                [FieldOffset(16)] public FILE_ID_128 ParentFileReferenceNumber;
                [FieldOffset(32)] public Int64 Usn;
                [FieldOffset(40)] public Int64 TimeStamp;
                [FieldOffset(48)] public UInt32 Reason;
                [FieldOffset(52)] public UInt32 SourceInfo;
                [FieldOffset(56)] public UInt32 SecurityId;
                [FieldOffset(60)] public UInt32 FileAttributes;
                [FieldOffset(64)] public UInt16 FileNameLength;
                [FieldOffset(66)] public UInt16 FileNameOffset;
                // offset 68 is the wide character name
            }

            [StructLayout(LayoutKind.Explicit, Pack = 0)]
            private struct USN_RECORD_V4
            {
                [FieldOffset(0)] public FILE_ID_128 FileReferenceNumber;
                [FieldOffset(16)] public FILE_ID_128 ParentFileReferenceNumber;
                [FieldOffset(32)] public Int64 Usn;
                [FieldOffset(40)] public Int64 TimeStamp;
                [FieldOffset(48)] public UInt32 Reason;
                [FieldOffset(52)] public UInt32 SourceInfo;
                [FieldOffset(56)] public UInt16 RemainingExtents;
                [FieldOffset(58)] public UInt16 NumberOfExtents;
                // Offset 60 is where the extents start 
            }

            private List<_USN_RECORD_EXTENT> ExtentList = new List<_USN_RECORD_EXTENT>();

            private USN_RECORD_COMMON_HEADER commonHeader;
            private USN_RECORD_V2 recordV2;
            private USN_RECORD_V3 recordV3;
            private USN_RECORD_V4 recordV4;

            public UInt32 RecordLength { get { return commonHeader.RecordLength; } }
            public UInt16 MajorVersion { get { return commonHeader.MajorVersion; } }
            public UInt16 MinorVersion { get { return commonHeader.MinorVersion; } }
            public FILE_ID_128 FileReferenceNumber
            {
                get
                {
                    if (2 == MajorVersion)
                    {

                        return (FILE_ID_128)recordV2.FileReferenceNumber;
                    }
                    else if (3 == MajorVersion)
                    {
                        return recordV3.FileReferenceNumber;
                    }
                    else if (4 == MajorVersion)
                    {
                        return recordV4.FileReferenceNumber;
                    }
                    throw new InvalidDataException($"Invalid version number {MajorVersion}");
                }
            }
            public FILE_ID_128 ParentFileReferenceNumber
            {
                get
                {
                    if (2 == MajorVersion)
                    {
                        return (FILE_ID_128)recordV2.ParentFileReferenceNumber;
                    }
                    else if (3 == MajorVersion)
                    {
                        return recordV3.ParentFileReferenceNumber;
                    }
                    else if (4 == MajorVersion)
                    {
                        return recordV4.ParentFileReferenceNumber;
                    }
                    throw new InvalidDataException($"Invalid version number {MajorVersion}");
                }
            }
            public Int64 Usn
            {
                get
                {
                    if (2 == MajorVersion)
                    {
                        return recordV2.Usn;
                    }
                    else if (3 == MajorVersion)
                    {
                        return recordV3.Usn;
                    }
                    else if (4 == MajorVersion)
                    {
                        return recordV4.Usn;
                    }
                    throw new InvalidDataException($"Invalid version number {MajorVersion}");
                }
            }

            public Int64 TimeStamp
            {
                get
                {
                    if (2 == MajorVersion)
                    {
                        return recordV2.TimeStamp;
                    }
                    else if (3 == MajorVersion)
                    {
                        return recordV3.TimeStamp;
                    }
                    else if (4 == MajorVersion)
                    {
                        return 0; // technically invalid
                    }
                    throw new InvalidDataException($"Invalid version number {MajorVersion}");
                }

            }

            public UInt32 Reason
            {
                get
                {
                    if (2 == MajorVersion)
                    {
                        return recordV2.Reason;
                    }
                    else if (3 == MajorVersion)
                    {
                        return recordV3.Reason;
                    }
                    else if (4 == MajorVersion)
                    {
                        return recordV4.Reason;
                    }
                    throw new InvalidDataException($"Invalid version number {MajorVersion}");

                }
            }

            public UInt32 SourceInfo
            {
                get
                {
                    if (2 == MajorVersion)
                    {
                        return recordV2.SourceInfo;
                    }
                    else if (3 == MajorVersion)
                    {
                        return recordV3.SourceInfo;
                    }
                    else if (4 == MajorVersion)
                    {
                        return recordV4.SourceInfo;
                    }
                    throw new InvalidDataException($"Invalid version number {MajorVersion}");
                }
            }

            public UInt32 SecurityId
            {
                get
                {
                    if (2 == MajorVersion)
                    {
                        return recordV2.SecurityId;
                    }
                    else if (3 == MajorVersion)
                    {
                        return recordV3.SecurityId;
                    }
                    else if (4 == MajorVersion)
                    {
                        return 0; // technically not valid
                    }
                    throw new InvalidDataException($"Invalid version number {MajorVersion}");
                }
            }

            public UInt32 FileAttributes
            {
                get
                {
                    if (2 == MajorVersion)
                    {
                        return recordV2.FileAttributes;
                    }
                    else if (3 == MajorVersion)
                    {
                        return recordV3.FileAttributes;
                    }
                    else if (4 == MajorVersion)
                    {
                        return 0;
                    }
                    throw new InvalidDataException($"Invalid version number {MajorVersion}");
                }
            }

            public string? FileName
            {
                get
                {
                    if ((null != _FileName) && ((2 == MajorVersion) || (3 == MajorVersion)))
                    {
                        return _FileName;
                    }
                    else if (4 == MajorVersion)
                    {
                        return ""; // technically not valid
                    }
                    throw new InvalidDataException($"Invalid version number {MajorVersion}");
                }
            }

            public List<USN_RECORD_EXTENT> Extents
            {
                get
                {
                    if ((MajorVersion > 1) && (MajorVersion < 5))
                    {
                        return new List<USN_RECORD_EXTENT>(); // empty list - no extents
                    }
                    throw new InvalidDataException($"Invalid version number {MajorVersion}");
                }
            }

            private void UnpackV2(IntPtr Buffer)
            {
                recordV2 = Marshal.PtrToStructure<USN_RECORD_V2>(Buffer);
                _FileName = Marshal.PtrToStringUni(Buffer - Marshal.SizeOf(commonHeader) + recordV2.FileNameOffset, recordV2.FileNameLength / 2);
            }

            private void UnpackV3(IntPtr Buffer)
            {
                FILE_ID_128 fid= Marshal.PtrToStructure<FILE_ID_128>(Buffer);
                FILE_ID_128 pfid = Marshal.PtrToStructure<FILE_ID_128>(Buffer + 16);
                Log.Debug($"fid is {fid}");
                Log.Debug($"pfid is {pfid}");
                recordV3 = Marshal.PtrToStructure<USN_RECORD_V3>(Buffer);
                _FileName = Marshal.PtrToStringUni(Buffer - Marshal.SizeOf(commonHeader) + recordV3.FileNameOffset, recordV3.FileNameLength / 2);
            }

            private void UnpackV4(IntPtr Buffer)
            {
                recordV4 = Marshal.PtrToStructure<USN_RECORD_V4>(Buffer);
                if (recordV4.RemainingExtents != 0)
                {
                    throw new NotImplementedException($"Have not implemented extent continuation, remaining is {recordV4.RemainingExtents}, number is {recordV4.NumberOfExtents}");
                }
                /*
                // I have to unpack the extend records
                for (int index = 0; index < recordV4.NumberOfExtents; index++)
                {
                    _USN_RECORD_EXTENT extent = Marshal.PtrToStructure<_USN_RECORD_EXTENT>(Buffer + Offset);
                    Offset += Marshal.SizeOf(extent);

                    ExtentList.Add(extent);
                }

                if (Offset > Length)
                {
                    throw new InvalidDataException($"Offset ({Offset}) cannot be greater than length ({Length})!");
                }
                */
            }


            // Given a buffer and an offset, unpack the USN record
            // at that offset.  Upon return, the offset has been
            // updated to indicate the new location within the buffer.
            // The Length is the length of the memory region described
            // by the buffer.
            public USN_RECORD_DATA(IntPtr Buffer, ref int Offset, int Length)
            {
                commonHeader = Marshal.PtrToStructure<USN_RECORD_COMMON_HEADER>(Buffer + Offset);

                Log.Debug($"USN Record Common Header:");
                Log.Debug($"\tRecordLength:{commonHeader.RecordLength}");
                Log.Debug($"\tMajorVersion:{commonHeader.MajorVersion}");
                Log.Debug($"\tMinorVersion:{commonHeader.MinorVersion}");

                Debug.Assert(Offset + commonHeader.RecordLength <= Length);

                switch (commonHeader.MajorVersion)
                {
                    default:
                        throw new InvalidDataException($"Invalid Major version {commonHeader.MajorVersion}");
                    case 2:
                        {
                            UnpackV2(Buffer + Offset + Marshal.SizeOf(commonHeader));
                            break;
                        }
                    case 3:
                        {
                            UnpackV3(Buffer + Offset + Marshal.SizeOf(commonHeader));
                            break;
                        }
                    case 4:
                        UnpackV4(Buffer + Offset + Marshal.SizeOf(commonHeader));
                        break;

                }

                Offset += (int) commonHeader.RecordLength;

            }
        }

        public void DumpLog()
        {
            Log.Debug($"\t             RecordLength: {RecordLength}");
            Log.Debug($"\t             MajorVersion: {MajorVersion}");
            Log.Debug($"\t             MinorVersion: {MinorVersion}");
            Log.Debug($"\t      FileReferenceNumber: {FileReferenceNumber}");
            Log.Debug($"\tParentFileReferenceNumber: {ParentFileReferenceNumber}");
            Log.Debug($"\t                      Usn: {Usn}");
            Log.Debug($"\t                TimeStamp: {TimeStamp} ({DateTime.FromFileTimeUtc(TimeStamp)})");
            Log.Debug($"\t                   Reason: {Reason:X} ({ReasonToString(Reason)})");
            Log.Debug($"\t               SourceInfo: {SourceInfo}");
            Log.Debug($"\t               SecurityId: {SecurityId}");
            Log.Debug($"\t           FileAttributes: {FileAttributes}");
            Log.Debug($"\t                 FileName: {FileName}");
            Log.Debug($"\t                  Extents: ({Extents.Count})");
            foreach (USN_RECORD_EXTENT ure in Extents)
            {
                Log.Debug($"\t\t Offset:{ure.Offset}");
                Log.Debug($"\t\t Length: {ure.Length}");
            }
        }

        public UInt32 RecordLength => data.RecordLength;
        public UInt16 MajorVersion => data.MajorVersion;
        public UInt16 MinorVersion => data.MinorVersion;
        public FILE_ID_128 FileReferenceNumber => data.FileReferenceNumber;
        public FILE_ID_128 ParentFileReferenceNumber => data.ParentFileReferenceNumber;
        public Int64 Usn => data.Usn;

        public Int64 TimeStamp => data.TimeStamp;

        public UInt32 Reason => data.Reason;

        public UInt32 SourceInfo => data.SourceInfo;

        public UInt32 SecurityId => data.SecurityId;

        public UInt32 FileAttributes => data.FileAttributes;

        public string? FileName => data.FileName;
        public List<USN_RECORD_EXTENT> Extents => data.Extents;

        private USN_RECORD_DATA data;

        public static USN_RECORD UnpackUsnJournalRecord(IntPtr Buffer, ref int Offset, int BufferLength)
        {
            USN_RECORD usn_record = new USN_RECORD();

            usn_record.data = new USN_RECORD_DATA(Buffer, ref Offset, BufferLength);

            return usn_record;
        }
    }


    //
    //==================== FSCTL_QUERY_USN_JOURNAL ======================
    //
    //  Structure for FSCTL_QUERY_USN_JOURNAL
    //
    public class USN_JOURNAL_DATA
    {
        [StructLayout(LayoutKind.Explicit, Pack = 0)]

        private struct _USN_JOURNAL_DATA
        {
            [FieldOffset(0)] public UInt64 UsnJournalID;
            [FieldOffset(8)] public Int64 FirstUsn;
            [FieldOffset(16)] public Int64 NextUsn;
            [FieldOffset(24)] public Int64 LowestValidUsn;
            [FieldOffset(32)] public Int64 MaxUsn;
            [FieldOffset(40)] public UInt64 MaximumSize;
            [FieldOffset(48)] public UInt64 AllocationDelta;
            [FieldOffset(56)] public UInt16 MinSupportedMajorVersion; // V1 starts here
            [FieldOffset(58)] public UInt16 MaxSupportedMajorVersion;
            [FieldOffset(60)] public UInt32 Flags; // V2 starts here
            [FieldOffset(64)] public UInt64 RangeTrackChunkSize;
            [FieldOffset(72)] public Int64 RangeTrackFileSizeThreshold;

            public static _USN_JOURNAL_DATA FromArray(byte[] bytes)
            {
                var reader = new BinaryReader(new MemoryStream(bytes));

                var s = default(_USN_JOURNAL_DATA);

                if (Marshal.SizeOf(s) > bytes.Length)
                {
                    throw new ArgumentException("Deserializing buffer smaller than our structure (old version?)");
                }

                s.UsnJournalID = reader.ReadUInt64();
                s.FirstUsn = reader.ReadInt64();
                s.NextUsn = reader.ReadInt64();
                s.LowestValidUsn = reader.ReadInt64();
                s.MaxUsn = reader.ReadInt64();
                s.MaximumSize = reader.ReadUInt64();
                s.AllocationDelta = reader.ReadUInt64();
                s.MinSupportedMajorVersion = reader.ReadUInt16();
                s.MaxSupportedMajorVersion = reader.ReadUInt16();
                s.Flags = reader.ReadUInt32();
                s.RangeTrackChunkSize = reader.ReadUInt64();
                s.RangeTrackFileSizeThreshold = reader.ReadInt64();

                return s;
            }

            public void DebugLog()
            {
                Log.Debug($"\t                UsnJournalID: {UsnJournalID}");
                Log.Debug($"\t                    FirstUsn: {FirstUsn}");
                Log.Debug($"\t                     NextUsn: {NextUsn}");
                Log.Debug($"\t              LowestValidUsn: {LowestValidUsn}");
                Log.Debug($"\t                      MaxUsn: {MaxUsn}");
                Log.Debug($"\t                 MaximumSize: {MaximumSize}");
                Log.Debug($"\t             AllocationDelta: {AllocationDelta}");
                Log.Debug($"\t    MinSupportedMajorVersion: {MinSupportedMajorVersion}");
                Log.Debug($"\t    MaxSupportedMajorVersion: {MaxSupportedMajorVersion}");
                Log.Debug($"\t                       Flags: {Flags}");
                Log.Debug($"\t         RangeTrackChunkSize: {RangeTrackChunkSize}");
                Log.Debug($"\t RangeTrackFileSizeThreshold: {RangeTrackFileSizeThreshold}");
            }

        }

        _USN_JOURNAL_DATA _journalData;

        public UInt64 UsnJournalID { get { return _journalData.UsnJournalID; } }
        public Int64 FirstUsn { get { return _journalData.FirstUsn; } }
        public Int64 NextUsn { get { return _journalData.NextUsn; } }
        public Int64 LowestValidUsn { get { return _journalData.LowestValidUsn; } }
        public Int64 MaxUsn { get { return _journalData.MaxUsn; } }
        public UInt64 MaximumSize { get { return _journalData.MaximumSize; } }
        public UInt64 AllocationDelta { get { return _journalData.AllocationDelta; } }
        public UInt16 MinSupportedMajorVersion { get { return _journalData.MinSupportedMajorVersion; } } // V1 starts here
        public UInt16 MaxSupportedMajorVersion { get { return _journalData.MaxSupportedMajorVersion; } }
        public UInt32 Flags { get { return _journalData.Flags; } } // V2 starts here
        public UInt64 RangeTrackChunkSize { get { return _journalData.RangeTrackChunkSize; } }
        public Int64 RangeTrackFileSizeThreshold { get { return _journalData.RangeTrackFileSizeThreshold; } }

        public USN_JOURNAL_DATA(byte[] Buffer)
        {
            _journalData = _USN_JOURNAL_DATA.FromArray(Buffer);
        }

        public string GetJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public void DebugLog()
        {
            _journalData.DebugLog();
        }

        public static USN_JOURNAL_DATA? GetUsnJournalData(SafeFileHandle Handle, ref IO_STATUS_BLOCK statusBlock)
        {
            byte[] usnBuffer = new byte[1024 * 1024];

            Debug.Assert(!Handle.IsInvalid);

            // Check to see if it is actually enabled for this drive.
            NtStatusCode status = NtFsControlFile(Handle, ref statusBlock, ControlCodes.Instance.FSCTL_QUERY_USN_JOURNAL, ref usnBuffer);

            if (NtStatusCode.STATUS_JOURNAL_NOT_ACTIVE == status)
            {
                // Supported but not turned on
                return null;
            }

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException($"FSCTL_QUERY_USN_JOURNAL failed with unexpected error {status} ({status:X})");
            }

            if (!NtStatus.NT_SUCCESS(statusBlock.Status))
            {
                return null;
            }
            return new USN_JOURNAL_DATA(usnBuffer);

        }

    }

    //
    // This is used to return information about drives on the system that support the USN journal and whether or not the USN journal is enabled
    // on the given drive.
    public struct USN_JOURNAL_DRIVE_DATA
    {
        public string Drive;
        public bool Enabled;
        public USN_JOURNAL_DATA JournalData;
    }

    internal class SYSTEM_USN_INFORMATION
    {
        private static readonly Lazy<SYSTEM_USN_INFORMATION> _SystemUsnInformation = new Lazy<SYSTEM_USN_INFORMATION>((() => new SYSTEM_USN_INFORMATION()));

        public static SYSTEM_USN_INFORMATION Data { get { return _SystemUsnInformation.Value; } }

        private List<string> UsnCapableDrives = new List<string>();

        public static List<string> GetUsnCapableDrives()
        {
            return Data.Update().UsnCapableDrives;
        }

        private static List<string> FindUsnCapableDrives()
        {
            MountManager mountManager = new MountManager();

            List<string> drives = mountManager.GetAllDrives();
            List<string> usnCapableDrives = new List<string>();

            foreach (string drive in drives)
            {
                // open the drive, check if it supports the USN journal, and if it does
                // determine if it is enabled.
                SafeFileHandle driveHandle = new SafeFileHandle(IntPtr.Zero, true);
                UNICODE_STRING c_drive = new UNICODE_STRING(drive);
                OBJECT_ATTRIBUTES objattr = new OBJECT_ATTRIBUTES(new SafeFileHandle(IntPtr.Zero, true), c_drive);
                ACCESS_MASK mask = (UInt32)FILE_ACCESS_MASK.FILE_READ_ATTRIBUTES | FILE_ACCESS_MASK.FILE_WRITE_ATTRIBUTES | FILE_ACCESS_MASK.SYNCHRONIZE;
                IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
                FILE_ATTRIBUTES fileAttr = FILE_ATTRIBUTES.NORMAL;
                SHARE_ACCESS shareAccess = SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_WRITE;
                CREATE_DISPOSITION disposition = CREATE_DISPOSITION.FILE_OPEN;
                CREATE_OPTIONS options = CREATE_OPTIONS.FILE_SYNCHRONOUS_IO_NONALERT | CREATE_OPTIONS.FILE_NON_DIRECTORY_FILE;
                EXTENDED_ATTRIBUTE ea = new EXTENDED_ATTRIBUTE();

                NtStatusCode status = NtCreateFile(ref driveHandle, mask, objattr, ref statusBlock, null, fileAttr, shareAccess, disposition, options, ea);

                if (!NtStatus.NT_SUCCESS(status))
                {
                    throw new IOException($"NtCreateFile failed, status {status} ({status:X}) = {NtStatusToString.StatusToString(status)}");
                }

                // Check file system characteristics
                FILE_FS_ATTRIBUTE_INFORMATION fsAttrInfo = FILE_FS_ATTRIBUTE_INFORMATION.GetFsAttributeInformation(driveHandle);

                Log.Debug($"Check Drive {drive} for USN support:");
                if (0 != (FILE_SYSTEM_ATTRIBUTE_FLAGS.FILE_SUPPORTS_USN_JOURNAL & fsAttrInfo.FileSystemAttributes))
                {
                    usnCapableDrives.Add(drive);
                }
            }

            return usnCapableDrives;
        }

        private List<USN_JOURNAL_DRIVE_DATA> ActiveUsnJournalDrives = new List<USN_JOURNAL_DRIVE_DATA>();

        public static List<USN_JOURNAL_DRIVE_DATA> GetActiveUsnJournalDrives()
        {
            return Data.Update().ActiveUsnJournalDrives;
        }

        private static List<USN_JOURNAL_DRIVE_DATA> FindActiveUsnJournalDrives()
        {
            List<USN_JOURNAL_DRIVE_DATA> usnDrives = new List<USN_JOURNAL_DRIVE_DATA>();
            MountManager mountManager = new MountManager();

            List<string> drives = FindUsnCapableDrives();

            foreach (string drive in drives)
            {
                // open the drive, check if it supports the USN journal, and if it does
                // determine if it is enabled.
                SafeFileHandle driveHandle = new SafeFileHandle(IntPtr.Zero, true);
                UNICODE_STRING c_drive = new UNICODE_STRING(drive);
                OBJECT_ATTRIBUTES objattr = new OBJECT_ATTRIBUTES(new SafeFileHandle(IntPtr.Zero, true), c_drive);
                FILE_ACCESS_MASK mask = FILE_ACCESS_MASK.FILE_READ_ATTRIBUTES | FILE_ACCESS_MASK.FILE_WRITE_ATTRIBUTES | FILE_ACCESS_MASK.SYNCHRONIZE;
                IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
                FILE_ATTRIBUTES fileAttr = FILE_ATTRIBUTES.NORMAL;
                SHARE_ACCESS shareAccess = SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_WRITE;
                CREATE_DISPOSITION disposition = CREATE_DISPOSITION.FILE_OPEN;
                CREATE_OPTIONS options = CREATE_OPTIONS.FILE_SYNCHRONOUS_IO_NONALERT | CREATE_OPTIONS.FILE_NON_DIRECTORY_FILE;
                EXTENDED_ATTRIBUTE ea = new EXTENDED_ATTRIBUTE();

                NtStatusCode status = NtCreateFile(ref driveHandle, mask, objattr, ref statusBlock, null, fileAttr, shareAccess, disposition, options, ea);

                if (!NtStatus.NT_SUCCESS(status))
                {
                    throw new IOException($"NtCreateFile failed, status {status} ({status:X}) = {NtStatusToString.StatusToString(status)}");
                }

                USN_JOURNAL_DRIVE_DATA usnDrive = new USN_JOURNAL_DRIVE_DATA();
                ControlCodes controlCodes = ControlCodes.Instance;

                usnDrive.Drive = drive;
                USN_JOURNAL_DATA? journalData = USN_JOURNAL_DATA.GetUsnJournalData(driveHandle, ref statusBlock);

                if ((null == journalData) || !NtStatus.NT_SUCCESS(statusBlock.Status))
                {
                    continue; // not of interest
                }

                Log.Debug($"USN Journal Data for drive {drive}:");
                journalData.DebugLog();
                Log.Debug("\nJson version:");
                Log.Debug(journalData.GetJson());
                Log.Debug("\n");

                usnDrives.Add(usnDrive);

            }

            return usnDrives;
        }

        public static USN_JOURNAL_DATA? GetUsnJournalDataForDrive(string Drive)
        {
            Data.Update();
            foreach (var drive in Data.ActiveUsnJournalDrives)
            {
                if (drive.Drive == Drive)
                {
                    // Same drive
                    return drive.JournalData;
                }
            }

            return null;
        }

        private DateTime LastUpdate;

        private SYSTEM_USN_INFORMATION Update(bool Force = false)
        {
            DateTime checkValue = LastUpdate;

            Log.Debug($"LastUpdate is {LastUpdate},  Minimum is {DateTime.MinValue}, Now is {DateTime.Now}");

            checkValue.AddMinutes(10);

            if (Force || (LastUpdate == DateTime.MinValue) || (checkValue > DateTime.Now))
            {
                UsnCapableDrives = FindUsnCapableDrives();
                ActiveUsnJournalDrives = FindActiveUsnJournalDrives();
                LastUpdate = DateTime.Now;
            }

            return this;
        }
        // TODO: may want to add dynamic extension capabilities

        private SYSTEM_USN_INFORMATION()
        {
        }
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

    public class USN_JOURNAL
    {
        private string DeviceName = new string("");
        private SafeFileHandle DeviceHandle = new SafeFileHandle(IntPtr.Zero, true);
        private IntPtr UsnRecordBuffer = IntPtr.Zero;

        ~USN_JOURNAL()
        {
            if (!DeviceHandle.IsInvalid)
            {
                DeviceHandle.Close();
            }

            if (IntPtr.Zero != UsnRecordBuffer)
            {
                Marshal.FreeHGlobal(UsnRecordBuffer);
                UsnRecordBuffer = IntPtr.Zero;
            }
        }

        public USN_JOURNAL(string Drive)
        {
            DeviceName = Drive;
            OpenDrive(Drive);
        }

        private void OpenDrive(string Drive)
        {
            // open the drive, check if it supports the USN journal, and if it does
            // determine if it is enabled.
            FILE_ACCESS_MASK mask;
            OBJECT_ATTRIBUTES objattr = new OBJECT_ATTRIBUTES(new SafeFileHandle(IntPtr.Zero, true), new UNICODE_STRING(Drive));
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            FILE_ATTRIBUTES fileAttr = FILE_ATTRIBUTES.NORMAL;
            SHARE_ACCESS shareAccess = SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_WRITE;
            CREATE_DISPOSITION disposition = CREATE_DISPOSITION.FILE_OPEN;
            CREATE_OPTIONS options = CREATE_OPTIONS.FILE_SYNCHRONOUS_IO_NONALERT | CREATE_OPTIONS.FILE_NON_DIRECTORY_FILE;
            EXTENDED_ATTRIBUTE ea = new EXTENDED_ATTRIBUTE();
            mask = FILE_ACCESS_MASK.FILE_READ_ATTRIBUTES | FILE_ACCESS_MASK.FILE_WRITE_ATTRIBUTES | FILE_ACCESS_MASK.SYNCHRONIZE;

            NtStatusCode status = NtCreateFile(ref DeviceHandle, mask, objattr, ref statusBlock, null, fileAttr, shareAccess, disposition, options, ea);

            if (!NtStatus.NT_SUCCESS(status))
            {
                Log.Fatal($"Opening drive {Drive} failed with status {status:x} ({status})");
                throw new IOException($"NtCreateFile failed, status {status} ({status:X}) = {NtStatusToString.StatusToString(status)}");
            }
        }

        #region public static

        public static List<USN_JOURNAL_DRIVE_DATA> GetActiveUsnJournalDrives()
        {
            return SYSTEM_USN_INFORMATION.GetActiveUsnJournalDrives();
        }

        public static List<string> GetUsnCapableDrives()
        {
            return SYSTEM_USN_INFORMATION.GetUsnCapableDrives();
        }
        #endregion public static

        // We use this to determine where we are in reading the USN journal so we can repeatedly read it.
        private Int64 LastUsnRequested;
        private List<USN_RECORD> Records = new List<USN_RECORD>();
        private Dictionary<Int64, USN_RECORD> RecordsByUsn = new Dictionary<Int64, USN_RECORD>();

        // This routine is called to see if there are any more USN records and, if so, make sure we've grabbed them.
        public uint UpdateUsnRecords()
        {
            uint count = 0;
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);

            USN_JOURNAL_DATA? journalData = USN_JOURNAL_DATA.GetUsnJournalData(DeviceHandle, ref statusBlock);

            Debug.Assert(null != journalData); // don't call us on a drive that doesn't have a USN journal!

            Debug.Assert(journalData.MaximumSize > 4096);
            ulong bufferSize = journalData.MaximumSize * 2;
            IntPtr buffer = Marshal.AllocHGlobal((int)(bufferSize));

            try
            {
                READ_USN_JOURNAL_DATA readUsnJournalData = new READ_USN_JOURNAL_DATA(journalData);

                if (journalData.FirstUsn > LastUsnRequested)
                {
                    LastUsnRequested = journalData.FirstUsn;
                }

                Debug.Assert(!DeviceHandle.IsInvalid);

                Log.Debug($"ReadUsnJournal: using buffer of size {bufferSize}");
                Log.Debug($"ReadUsnJournal: using LastUsnRequested = {LastUsnRequested}, note journalData.FirstUsn is {journalData.FirstUsn}");
                Log.Debug($"ReadUsnJournal: using UsnJournalId = {journalData.UsnJournalID}");
                statusBlock.Status = NtStatusCode.STATUS_UNSUCCESSFUL;
                NtStatusCode status = readUsnJournalData.ReadUsnJournal(DeviceHandle, LastUsnRequested, buffer, bufferSize, ref statusBlock);

                Log.Debug($"ReadUsnJournal for drive {DeviceName} starting with {LastUsnRequested} returned status {status:x} ({status}) and buffer returned is {statusBlock.Information:X} ({statusBlock.Information}) bytes long");
                int bytesReturned = (int)statusBlock.Information;

                Debug.Assert(NtStatus.NT_SUCCESS(status));


                bool dumpedfirstrecord = false;
                // Now we need to ingest all these records.
                for (int offset = 8; offset < bytesReturned;)
                {
                    Log.Debug($"Decode USN Journal Record buffer = 0x{buffer:X} at offset {offset}");
                    USN_RECORD record = USN_RECORD.UnpackUsnJournalRecord(buffer, ref offset, bytesReturned);

                    Debug.Assert(offset <= bytesReturned);

                    if ((record != null) && !RecordsByUsn.ContainsKey(record.Usn))
                    {
                        Log.Debug("USN Journal Record:");
                        record.DumpLog();
                        Records.Add(record);
                        RecordsByUsn.Add(record.Usn, record);
                        LastUsnRequested = record.Usn;
                        count++;
                    }

                    if (!dumpedfirstrecord)
                    {
                        var options = new JsonSerializerOptions
                        {
                            WriteIndented = true,
                        };
                        Console.WriteLine($"First record added {JsonSerializer.Serialize(record,options)}");
                        dumpedfirstrecord = true;
                    }

                }

                // TODO: I need to make the above logic a loop until there's no more records.
                // Of course, since the records are being generated dynamically, this is an ongoing
                // process.

            }
            finally
            {
                if (IntPtr.Zero != buffer)
                {
                    Marshal.FreeHGlobal(buffer);
                    buffer = IntPtr.Zero;
                }
            }

            return count;
        }

        public List<USN_RECORD> ReadUsnRecord(bool RemoveFromList = false)
        {
            List<USN_RECORD> Records = new List<USN_RECORD>();



            return Records;
        }

    }
}
