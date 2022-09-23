using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace USBDeviceCheck
{
    public static class HardwareInfo
    {

        public static Dictionary<string,string> GetMachineInformation()
        { 
            var machineInfoDict = new Dictionary<string,string>();
            ManagementClass mc = new ManagementClass("win32_processor");
          
            foreach (var mo in mc.GetInstances())
            {
                foreach (var info in mo.Properties)
                {
                    string value = String.Empty;

                    if (null == info.Value)
                    {
                        value = "";
                    }
                    else
                    {
                        value = info.Value.ToString();
                    }

                    machineInfoDict.Add(info.Name, value);
                }
                
            }

            return machineInfoDict;

        }

        public static String GetProcessorId()
        {
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            String Id = String.Empty;

            Console.WriteLine($"ManagementObjectCollection size is {moc.Count}");
            Console.WriteLine($"Path = {mc.ClassPath.ToString()}");
            foreach (ManagementObject mo in moc)
            {
                Id = mo.Properties["processorID"].Value.ToString();
                foreach (var info in mo.Properties)
                {
                    try
                    {
                        if (null != info.Value)
                        {
                            Console.WriteLine($"\tFound field {info.Name} = {info.Value.ToString()}");
                        }
                        else
                        {
                            Console.WriteLine($"\tFound field {info.Name} = null");
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"\tFound field {info.Name} threw exception {ex.ToString()}");
                    }
                }
            }
            return Id;

#if false
        Found field AddressWidth
        Found field Architecture
        Found field AssetTag
        Found field Availability
        Found field Caption
        Found field Characteristics
        Found field ConfigManagerErrorCode
        Found field ConfigManagerUserConfig
        Found field CpuStatus
        Found field CreationClassName
        Found field CurrentClockSpeed
        Found field CurrentVoltage
        Found field DataWidth
        Found field Description
        Found field DeviceID
        Found field ErrorCleared
        Found field ErrorDescription
        Found field ExtClock
        Found field Family
        Found field InstallDate
        Found field L2CacheSize
        Found field L2CacheSpeed
        Found field L3CacheSize
        Found field L3CacheSpeed
        Found field LastErrorCode
        Found field Level
        Found field LoadPercentage
        Found field Manufacturer
        Found field MaxClockSpeed
        Found field Name
        Found field NumberOfCores
        Found field NumberOfEnabledCore
        Found field NumberOfLogicalProcessors
        Found field OtherFamilyDescription
        Found field PartNumber
        Found field PNPDeviceID
        Found field PowerManagementCapabilities
        Found field PowerManagementSupported
        Found field ProcessorId
        Found field ProcessorType
        Found field Revision
        Found field Role
        Found field SecondLevelAddressTranslationExtensions
        Found field SerialNumber
        Found field SocketDesignation
        Found field Status
        Found field StatusInfo
        Found field Stepping
        Found field SystemCreationClassName
        Found field SystemName
        Found field ThreadCount
        Found field UniqueId
        Found field UpgradeMethod
        Found field Version
        Found field VirtualizationFirmwareEnabled
        Found field VMMonitorModeExtensions
        Found field VoltageCaps
#endif
        }

    }

}
