﻿using NativeCalls;
using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;
using static NativeCalls.SystemCalls;
using System.Runtime.InteropServices;


namespace MountManagerLibrary
{
    public class MountManager
    {

        // Note the primary type information comes from mountmgr.h, which is part of the WDK.

        #region constants

        public static string MOUNTMGR_DEVICE_NAME_STRING = "\\Device\\MountPointManager";
        public static string MOUNTMGR_DOS_DEVICE_NAME_STRING = "\\\\.\\MountPointManager";

        private static uint MOUNTMGRCONTROLTYPE = (uint)0x0000006D;
        private static uint MOUNTDEVCONTROLTYPE = (uint)0x0000004D;

        public readonly UInt32 IOCTL_MOUNTMGR_CREATE_POINT = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 0, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_DELETE_POINTS = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 1, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_QUERY_POINTS = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 2, Ioctl.METHOD_BUFFERED, Ioctl.FILE_ANY_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_DELETE_POINTS_DBONLY = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 3, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_NEXT_DRIVE_LETTER = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 4, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_AUTO_DL_ASSIGNMENTS = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 5, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_VOLUME_MOUNT_POINT_CREATED = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 6, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_VOLUME_MOUNT_POINT_DELETED = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 7, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_CHANGE_NOTIFY = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 8, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_KEEP_LINKS_WHEN_OFFLINE = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 9, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_CHECK_UNPROCESSED_VOLUMES = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 10, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_VOLUME_ARRIVAL_NOTIFICATION = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 11, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_SCRUB_REGISTRY = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 14, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_QUERY_AUTO_MOUNT = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 15, Ioctl.METHOD_BUFFERED, Ioctl.FILE_ANY_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_SET_AUTO_MOUNT = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 16, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_BOOT_DL_ASSIGNMENT = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 17, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_TRACELOG_CACHE = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 18, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_PREPARE_VOLUME_DELETE = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 19, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_CANCEL_VOLUME_DELETE = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 20, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_SILO_ARRIVAL = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 21, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS | Ioctl.FILE_WRITE_ACCESS);
        public readonly UInt32 IOCTL_MOUNTMGR_VOLUME_REMOVAL_NOTIFICATION = Ioctl.CTL_CODE(MOUNTMGRCONTROLTYPE, 22, Ioctl.METHOD_BUFFERED, Ioctl.FILE_READ_ACCESS);

        public readonly UInt32 IOCTL_MOUNTDEV_QUERY_DEVICE_NAME = Ioctl.CTL_CODE(MOUNTDEVCONTROLTYPE, 2, Ioctl.METHOD_BUFFERED, Ioctl.FILE_ANY_ACCESS);

#endregion constants

#region structures

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _MOUNTMGR_CREATE_POINT_INPUT
        {
            [FieldOffset(0)] UInt16 SymbolicLinkNameOffset;
            [FieldOffset(2)] UInt16 SymbolicLinkNameLength;
            [FieldOffset(4)] UInt16 DeviceNameOffset;
            [FieldOffset(6)] UInt16 DeviceNameLength;
            // Note that the balance of the buffer contains the name(s)
        }

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _MOUNTMGR_MOUNT_POINT
        {
            [FieldOffset(0)] UInt32 SymbolicLinkNameOffset;
            [FieldOffset(4)] UInt16 SymbolicLinkNameLength;
            [FieldOffset(8)] UInt32 UniqueIdOffset;
            [FieldOffset(12)] UInt16 UniqueIdLength;
            [FieldOffset(16)] UInt32 DeviceNameOffset;
            [FieldOffset(20)] UInt16 DeviceNameLength;
            // Note that the balance of the buffer contains the name(s)
        }

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _MOUNTMGR_MOUNT_POINTS
        {
            [FieldOffset(0)] UInt32 Size;
            [FieldOffset(4)] UInt32 NumberOfMountPoints;
            // Note that the balance of the buffer contains mount point(s)
        }

        // This is used for multiple (identical) data structures
        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private unsafe struct _MOUNTMGR_NAME
        {
            [FieldOffset(0)] UInt16 DeviceNameLength;
            [FieldOffset(2)] fixed char DeviceName[32768];
            // Not sure this is the best way to do this - might just want
            // to unpack it manually.
        }

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _MOUNTMGR_DRIVE_LETTER_INFORMATION
        {
            [FieldOffset(0)] byte DriveLetterWasAssigned;
            [FieldOffset(1)] byte CurrentDriveLetter; // an actual single byte char interface.
        }

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _MOUNTMGR_VOLUME_MOUNT_POINT
        {
            [FieldOffset(0)] UInt16 SourceVolumeNameOffset;
            [FieldOffset(2)] UInt16 SourceVolumeNameLength;
            [FieldOffset(4)] UInt16 TargetVolumeNameOffset;
            [FieldOffset(6)] UInt16 TargetVolumeNameLength;
        }

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private struct _MOUNTMGR_CHANGE_NOTIFY_INFO
        {
            [FieldOffset(0)] UInt32 EpicNumber;
        }

        [StructLayout(LayoutKind.Explicit, Pack = 0)]
        private unsafe struct _MOUNTMGR_TARGET_NAME
        {
            [FieldOffset(0)] UInt16 DeviceNameLength;
            [FieldOffset(2)] fixed char DeviceName[32768];
            // Not sure this is the best way to do this - might just want
            // to unpack it manually.
        }


#endregion structures

#region enums
        public enum MOUNTMGR_AUTO_MOUNT_STATE
        {
            Disabled = 0,
            Enabled
        }

        #endregion enums

        public bool MOUNTMGR_IS_DRIVE_LETTER(string s)
        {
            var array = s.ToCharArray();

            return array.Length == 28 &&
                    array[0] == '\\' &&
                    array[1] == 'D' &&
                    array[2] == 'o' &&
                    array[3] == 's' &&
                    array[4] == 'D' &&
                    array[5] == 'e' &&
                    array[6] == 'v' &&
                    array[7] == 'i' &&
                    array[8] == 'c' &&
                    array[9] == 'e' &&
                    array[10] == 's' &&
                    array[11] == '\\' &&
                    array[12] >= 'A' &&
                    array[12] <= 'Z' &&
                    array[13] == ':';

        }

        public bool MOUNTMGR_IS_VOLUME_NAME(string s)
        {
            var array = s.ToCharArray();
            return (array.Length == 96 || (array.Length == 98 && array[48] == '\\')) &&
                     array[0] == '\\' &&
                     (array[1] == '?' || array[1] == '\\') &&
                     array[2] == '?' &&
                     array[3] == '\\' &&
                     array[4] == 'V' &&
                     array[5] == 'o' &&
                     array[6] == 'l' &&
                     array[7] == 'u' &&
                     array[8] == 'm' &&
                     array[9] == 'e' &&
                     array[10] == '{' &&
                     array[19] == '-' &&
                     array[24] == '-' &&
                     array[29] == '-' &&
                     array[34] == '-' &&
                     array[47] == '}';
        }

        public bool MOUNTMGR_IS_DOS_VOLUME_NAME(string s)
        {
            var array = s.ToCharArray();

            return MOUNTMGR_IS_VOLUME_NAME(s) &&
                array.Length == 96 &&
                array[1] == '\\';
        }

        public bool MOUNTMGR_IS_DOS_VOLUME_NAME_WB(string s)
        {
            var array = s.ToCharArray();

            return MOUNTMGR_IS_VOLUME_NAME(s) &&
                array.Length == 98 &&
                array[1] == '\\';

        }

        public bool MOUNTMGR_IS_NT_VOLUME_NAME(string s)
        {
            var array = s.ToCharArray();

            return MOUNTMGR_IS_VOLUME_NAME(s) &&
                array.Length == 96 &&
                array[1] == '?';

        }

        public bool MOUNTMGR_IS_NT_VOLUME_NAME_WB(string s)
        {
            var array = s.ToCharArray();

            return MOUNTMGR_IS_VOLUME_NAME(s) &&
                array.Length == 98 &&
                array[1] == '?';
        }

        #region private data
        private SafeFileHandle MountManagerHandle = new SafeFileHandle(IntPtr.Zero, true);
        #endregion private data

        #region private methods
        private void LoadMountManagerData()
        {
            NtStatusCode status;
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            byte[] buffer = new byte[1024 * 1024];

            if (MountManagerHandle.IsInvalid)
            {
                throw new IOException("Mount Manager handle is invalid, cannot load mount manager data");
            }

            status = NtDeviceIoControlFile(
                MountManagerHandle,
                new EVENT(),
                new APC(),
                ref statusBlock,
                IOCTL_MOUNTMGR_QUERY_POINTS,
                ref buffer, // input buffer
                ref buffer // output buffer
                );

            if (!NtStatus.NT_SUCCESS(status)) 
            {
                throw new IOException($"NtDeviceIoControlFile failed, status {status} ({status:X}) = {NtStatusToString.StatusToString(status)}");
            }
        }
        #endregion private methods

        #region constructors
        public MountManager()
        {
            UNICODE_STRING c_drive = new UNICODE_STRING(MOUNTMGR_DEVICE_NAME_STRING);
            OBJECT_ATTRIBUTES objattr = new OBJECT_ATTRIBUTES(MountManagerHandle, c_drive);
            ACCESS_MASK mask = (UInt32)ACCESS_MASK.GENERIC_READ;
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            FILE_ATTRIBUTES fileAttr = 0;
            SHARE_ACCESS shareAccess = SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_WRITE;
            CREATE_DISPOSITION disposition = CREATE_DISPOSITION.FILE_OPEN;
            CREATE_OPTIONS options = 0;
            EXTENDED_ATTRIBUTE ea = new EXTENDED_ATTRIBUTE();

            NtStatusCode status = NtCreateFile(ref MountManagerHandle, mask, objattr, ref statusBlock, 0, fileAttr, shareAccess, disposition, options, ea);

            if (!NtStatus.NT_SUCCESS(status))
            {
                throw new IOException($"NtCreateFile failed, status {status} ({status:X}) = {NtStatusToString.StatusToString(status)}");
            }

            LoadMountManagerData();
        }
        #endregion constructors

        #region destructors
        ~MountManager()
        {
            MountManagerHandle.Close();
        }
        #endregion destructors
    }
}