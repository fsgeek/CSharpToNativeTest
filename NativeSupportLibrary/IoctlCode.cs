using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeSupportLibrary
{
    public class Ioctl
    {

        public const UInt32 METHOD_BUFFERED = 0;
        public const UInt32 METHOD_IN_DIRECT = 1;
        public const UInt32 METHOD_OUT_DIRECT = 2;
        public const UInt32 METHOD_NEITHER = 3;

        public const UInt32 FILE_ANY_ACCESS = 0;
        public const UInt32 FILE_SPECIAL_ACCESS = FILE_ANY_ACCESS;
        public const UInt32 FILE_READ_ACCESS = 0x0001;
        public const UInt32 FILE_WRITE_ACCESS = 0x0002;


        public const UInt32 FILE_DEVICE_BEEP = (UInt32)0x00000001;
        public const UInt32 FILE_DEVICE_CD_ROM = (UInt32)0x00000002;
        public const UInt32 FILE_DEVICE_CD_ROM_FILE_SYSTEM = (UInt32)0x00000003;
        public const UInt32 FILE_DEVICE_CONTROLLER = (UInt32)0x00000004;
        public const UInt32 FILE_DEVICE_DATALINK = (UInt32)0x00000005;
        public const UInt32 FILE_DEVICE_DFS = (UInt32)0x00000006;
        public const UInt32 FILE_DEVICE_DISK = (UInt32)0x00000007;
        public const UInt32 FILE_DEVICE_DISK_FILE_SYSTEM = (UInt32)0x00000008;
        public const UInt32 FILE_DEVICE_FILE_SYSTEM = (UInt32)0x00000009;
        public const UInt32 FILE_DEVICE_INPORT_PORT = (UInt32)0x0000000a;
        public const UInt32 FILE_DEVICE_KEYBOARD = (UInt32)0x0000000b;
        public const UInt32 FILE_DEVICE_MAILSLOT = (UInt32)0x0000000c;
        public const UInt32 FILE_DEVICE_MIDI_IN = (UInt32)0x0000000d;
        public const UInt32 FILE_DEVICE_MIDI_OUT = (UInt32)0x0000000e;
        public const UInt32 FILE_DEVICE_MOUSE = (UInt32)0x0000000f;
        public const UInt32 FILE_DEVICE_MULTI_UNC_PROVIDER = (UInt32)0x00000010;
        public const UInt32 FILE_DEVICE_NAMED_PIPE = (UInt32)0x00000011;
        public const UInt32 FILE_DEVICE_NETWORK = (UInt32)0x00000012;
        public const UInt32 FILE_DEVICE_NETWORK_BROWSER = (UInt32)0x00000013;
        public const UInt32 FILE_DEVICE_NETWORK_FILE_SYSTEM = (UInt32)0x00000014;
        public const UInt32 FILE_DEVICE_NULL = (UInt32)0x00000015;
        public const UInt32 FILE_DEVICE_PARALLEL_PORT = (UInt32)0x00000016;
        public const UInt32 FILE_DEVICE_PHYSICAL_NETCARD = (UInt32)0x00000017;
        public const UInt32 FILE_DEVICE_PRINTER = (UInt32)0x00000018;
        public const UInt32 FILE_DEVICE_SCANNER = (UInt32)0x00000019;
        public const UInt32 FILE_DEVICE_SERIAL_MOUSE_PORT = (UInt32)0x0000001a;
        public const UInt32 FILE_DEVICE_SERIAL_PORT = (UInt32)0x0000001b;
        public const UInt32 FILE_DEVICE_SCREEN = (UInt32)0x0000001c;
        public const UInt32 FILE_DEVICE_SOUND = (UInt32)0x0000001d;
        public const UInt32 FILE_DEVICE_STREAMS = (UInt32)0x0000001e;
        public const UInt32 FILE_DEVICE_TAPE = (UInt32)0x0000001f;
        public const UInt32 FILE_DEVICE_TAPE_FILE_SYSTEM = (UInt32)0x00000020;
        public const UInt32 FILE_DEVICE_TRANSPORT = (UInt32)0x00000021;
        public const UInt32 FILE_DEVICE_UNKNOWN = (UInt32)0x00000022;
        public const UInt32 FILE_DEVICE_VIDEO = (UInt32)0x00000023;
        public const UInt32 FILE_DEVICE_VIRTUAL_DISK = (UInt32)0x00000024;
        public const UInt32 FILE_DEVICE_WAVE_IN = (UInt32)0x00000025;
        public const UInt32 FILE_DEVICE_WAVE_OUT = (UInt32)0x00000026;
        public const UInt32 FILE_DEVICE_8042_PORT = (UInt32)0x00000027;
        public const UInt32 FILE_DEVICE_NETWORK_REDIRECTOR = (UInt32)0x00000028;
        public const UInt32 FILE_DEVICE_BATTERY = (UInt32)0x00000029;
        public const UInt32 FILE_DEVICE_BUS_EXTENDER = (UInt32)0x0000002a;
        public const UInt32 FILE_DEVICE_MODEM = (UInt32)0x0000002b;
        public const UInt32 FILE_DEVICE_VDM = (UInt32)0x0000002c;
        public const UInt32 FILE_DEVICE_MASS_STORAGE = (UInt32)0x0000002d;
        public const UInt32 FILE_DEVICE_SMB = (UInt32)0x0000002e;
        public const UInt32 FILE_DEVICE_KS = (UInt32)0x0000002f;
        public const UInt32 FILE_DEVICE_CHANGER = (UInt32)0x00000030;
        public const UInt32 FILE_DEVICE_SMARTCARD = (UInt32)0x00000031;
        public const UInt32 FILE_DEVICE_ACPI = (UInt32)0x00000032;
        public const UInt32 FILE_DEVICE_DVD = (UInt32)0x00000033;
        public const UInt32 FILE_DEVICE_FULLSCREEN_VIDEO = (UInt32)0x00000034;
        public const UInt32 FILE_DEVICE_DFS_FILE_SYSTEM = (UInt32)0x00000035;
        public const UInt32 FILE_DEVICE_DFS_VOLUME = (UInt32)0x00000036;
        public const UInt32 FILE_DEVICE_SERENUM = (UInt32)0x00000037;
        public const UInt32 FILE_DEVICE_TERMSRV = (UInt32)0x00000038;
        public const UInt32 FILE_DEVICE_KSEC = (UInt32)0x00000039;
        public const UInt32 FILE_DEVICE_FIPS = (UInt32)0x0000003A;
        public const UInt32 FILE_DEVICE_INFINIBAND = (UInt32)0x0000003B;
        public const UInt32 FILE_DEVICE_VMBUS = (UInt32)0x0000003E;
        public const UInt32 FILE_DEVICE_CRYPT_PROVIDER = (UInt32)0x0000003F;
        public const UInt32 FILE_DEVICE_WPD = (UInt32)0x00000040;
        public const UInt32 FILE_DEVICE_BLUETOOTH = (UInt32)0x00000041;
        public const UInt32 FILE_DEVICE_MT_COMPOSITE = (UInt32)0x00000042;
        public const UInt32 FILE_DEVICE_MT_TRANSPORT = (UInt32)0x00000043;
        public const UInt32 FILE_DEVICE_BIOMETRIC = (UInt32)0x00000044;
        public const UInt32 FILE_DEVICE_PMI = (UInt32)0x00000045;
        public const UInt32 FILE_DEVICE_EHSTOR = (UInt32)0x00000046;
        public const UInt32 FILE_DEVICE_DEVAPI = (UInt32)0x00000047;
        public const UInt32 FILE_DEVICE_GPIO = (UInt32)0x00000048;
        public const UInt32 FILE_DEVICE_USBEX = (UInt32)0x00000049;
        public const UInt32 FILE_DEVICE_CONSOLE = (UInt32)0x00000050;
        public const UInt32 FILE_DEVICE_NFP = (UInt32)0x00000051;
        public const UInt32 FILE_DEVICE_SYSENV = (UInt32)0x00000052;
        public const UInt32 FILE_DEVICE_VIRTUAL_BLOCK = (UInt32)0x00000053;
        public const UInt32 FILE_DEVICE_POINT_OF_SERVICE = (UInt32)0x00000054;
        public const UInt32 FILE_DEVICE_STORAGE_REPLICATION = (UInt32)0x00000055;
        public const UInt32 FILE_DEVICE_TRUST_ENV = (UInt32)0x00000056;
        public const UInt32 FILE_DEVICE_UCM = (UInt32)0x00000057;
        public const UInt32 FILE_DEVICE_UCMTCPCI = (UInt32)0x00000058;
        public const UInt32 FILE_DEVICE_PERSISTENT_MEMORY = (UInt32)0x00000059;
        public const UInt32 FILE_DEVICE_NVDIMM = (UInt32)0x0000005a;
        public const UInt32 FILE_DEVICE_HOLOGRAPHIC = (UInt32)0x0000005b;
        public const UInt32 FILE_DEVICE_SDFXHCI = (UInt32)0x0000005c;
        public const UInt32 FILE_DEVICE_UCMUCSI = (UInt32)0x0000005d;
        public const UInt32 FILE_DEVICE_PRM = (UInt32)0x0000005e;
        public const UInt32 FILE_DEVICE_EVENT_COLLECTOR = (UInt32)0x0000005f;
        public const UInt32 FILE_DEVICE_USB4 = (UInt32)0x00000060;
        public const UInt32 FILE_DEVICE_SOUNDWIRE = (UInt32)0x00000061;

        public static UInt32 CTL_CODE(UInt32 DeviceType, UInt32 Function, UInt32 Method, UInt32 Access)
        {
            return (DeviceType << 16) | (Access << 14) | (Function << 2) | Method;
        }

        public static UInt32 DEVICE_TYPE_FROM_CTL_CODE(UInt32 ctrlCode)
        {
            return (ctrlCode & 0xffff0000) >> 16;
        }

        public static UInt32 METHOD_FROM_CTL_CODE(uint ctrlCode)
        {
            return (ctrlCode & 3);
        }


    }
}
