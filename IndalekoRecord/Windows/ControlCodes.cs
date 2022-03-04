using NativeSupportLibrary;


namespace Indaleko.Windows
{
    public sealed class ControlCodes
    {
        public UInt32 FSCTL_ENUM_USN_DATA => USNControlCodes.Instance.FSCTL_ENUM_USN_DATA;
        public UInt32 FSCTL_READ_USN_JOURNAL => USNControlCodes.Instance.FSCTL_READ_USN_JOURNAL;
        public UInt32 FSCTL_CREATE_USN_JOURNAL => USNControlCodes.Instance.FSCTL_CREATE_USN_JOURNAL;
        public UInt32 FSCTL_READ_FILE_USN_DATA => USNControlCodes.Instance.FSCTL_READ_FILE_USN_DATA;
        public UInt32 FSCTL_WRITE_USN_CLOSE_RECORD => USNControlCodes.Instance.FSCTL_WRITE_USN_CLOSE_RECORD;
        public UInt32 FSCTL_QUERY_USN_JOURNAL => USNControlCodes.Instance.FSCTL_QUERY_USN_JOURNAL;
        public UInt32 FSCTL_DELETE_USN_JOURNAL => USNControlCodes.Instance.FSCTL_DELETE_USN_JOURNAL;
        public UInt32 FSCTL_USN_TRACK_MODIFIED_RANGES => USNControlCodes.Instance.FSCTL_USN_TRACK_MODIFIED_RANGES;
        public UInt32 FSCTL_READ_UNPRIVILEGED_USN_JOURNAL => USNControlCodes.Instance.FSCTL_READ_UNPRIVILEGED_USN_JOURNAL;


        public UInt32 IOCTL_MOUNTMGR_CREATE_POINT => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_CREATE_POINT;
        public UInt32 IOCTL_MOUNTMGR_DELETE_POINTS => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_DELETE_POINTS;
        public UInt32 IOCTL_MOUNTMGR_QUERY_POINTS => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_QUERY_POINTS;
        public UInt32 IOCTL_MOUNTMGR_DELETE_POINTS_DBONLY => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_DELETE_POINTS_DBONLY;
        public UInt32 IOCTL_MOUNTMGR_NEXT_DRIVE_LETTER => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_NEXT_DRIVE_LETTER;
        public UInt32 IOCTL_MOUNTMGR_AUTO_DL_ASSIGNMENTS => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_AUTO_DL_ASSIGNMENTS;
        public UInt32 IOCTL_MOUNTMGR_VOLUME_MOUNT_POINT_CREATED => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_VOLUME_MOUNT_POINT_CREATED;
        public UInt32 IOCTL_MOUNTMGR_VOLUME_MOUNT_POINT_DELETED => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_VOLUME_MOUNT_POINT_DELETED;
        public UInt32 IOCTL_MOUNTMGR_CHANGE_NOTIFY => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_CHANGE_NOTIFY;
        public UInt32 IOCTL_MOUNTMGR_KEEP_LINKS_WHEN_OFFLINE => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_KEEP_LINKS_WHEN_OFFLINE;
        public UInt32 IOCTL_MOUNTMGR_CHECK_UNPROCESSED_VOLUMES => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_CHECK_UNPROCESSED_VOLUMES;
        public UInt32 IOCTL_MOUNTMGR_VOLUME_ARRIVAL_NOTIFICATION => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_VOLUME_ARRIVAL_NOTIFICATION;
        public UInt32 IOCTL_MOUNTMGR_SCRUB_REGISTRY => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_SCRUB_REGISTRY;
        public UInt32 IOCTL_MOUNTMGR_QUERY_AUTO_MOUNT => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_QUERY_AUTO_MOUNT;
        public UInt32 IOCTL_MOUNTMGR_SET_AUTO_MOUNT => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_SET_AUTO_MOUNT;
        public UInt32 IOCTL_MOUNTMGR_BOOT_DL_ASSIGNMENT => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_BOOT_DL_ASSIGNMENT;
        public UInt32 IOCTL_MOUNTMGR_TRACELOG_CACHE => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_TRACELOG_CACHE;
        public UInt32 IOCTL_MOUNTMGR_PREPARE_VOLUME_DELETE => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_PREPARE_VOLUME_DELETE;
        public UInt32 IOCTL_MOUNTMGR_CANCEL_VOLUME_DELETE => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_CANCEL_VOLUME_DELETE;
        public UInt32 IOCTL_MOUNTMGR_SILO_ARRIVAL => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_SILO_ARRIVAL;
        public UInt32 IOCTL_MOUNTMGR_VOLUME_REMOVAL_NOTIFICATION => MountManager.ControlCodes.Instance.IOCTL_MOUNTMGR_VOLUME_REMOVAL_NOTIFICATION;
        public UInt32 IOCTL_MOUNTDEV_QUERY_DEVICE_NAME => MountManager.ControlCodes.Instance.IOCTL_MOUNTDEV_QUERY_DEVICE_NAME;

    }

    public class USNJournal
    {
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

    }

}
}
