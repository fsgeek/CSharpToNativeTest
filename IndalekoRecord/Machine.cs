using MongoDB.Bson;
using MongoDB.Driver;
using Serilog;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.Win32;
using System.Security.Principal;
using System.DirectoryServices;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;


namespace Indaleko
{
    public class Machine : Record
    {
        // Use a "well-known GUID to indicate this is coming from the local machine
        public const string LocalMachineGuidString = "84635987-5a15-48c1-95e7-64651d4923cd";
        public static readonly Guid LocalMachineGuid = new Guid(LocalMachineGuidString);
        public static string? LocalMachineGuidDescription = "NTFS USN Journal";
        private static readonly ReadOnlyCollection<int> _versions = new ReadOnlyCollection<int>(new[] { 1, });
        public static ReadOnlyCollection<int> Versions { get { return _versions; } }
        private static Dictionary<string, object> _attributes = new Dictionary<string, object>();
        // public static Dictionary<string,string> Attributes { get { return _attributes; } }

        private static Machine? _instance = null;

        public static Machine GetMachineInfo()
        {
            if (_instance == null)
            {
                _attributes.Clear();
                _attributes.Add("MachineName", Environment.MachineName);
                _attributes.Add("DomainName", Environment.UserDomainName);
                _attributes.Add("PageSize", Environment.SystemPageSize.ToString());
                _attributes.Add("OSVersion", Environment.Version.ToString());
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    _attributes.Add("OS", "Windows");

                    var sid = new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid;
                    _attributes.Add("SystemSID", sid.ToString());

                    using (WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent())
                    {
                        if (null != windowsIdentity)
                        {
                            _attributes.Add("DomainSID", windowsIdentity.User.Value.Substring(0, windowsIdentity.User.Value.LastIndexOf('-')));
                        }
                    }

                    object? regGuid = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Cryptography", "MachineGuid", null);

                    if (null != regGuid)
                    {
                        Guid machineGuid;

                        if (typeof(string) == regGuid.GetType())
                        {
                            machineGuid = new Guid((string)regGuid);
                        }
                        else
                        {
                            throw new Exception($"Not sure what to do with type {regGuid.GetType()}");
                        }

                        if (default(Guid) != machineGuid)
                        {
                            _attributes.Add("SystemGuid", machineGuid.ToString());
                        }
                    }
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    _attributes.Add("OS", "Linux");
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    _attributes.Add("OS", "OSX");
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
                {
                    _attributes.Add("OS", "FreeBSD");
                }
                else
                {
                    throw new ApplicationException("Unsupported OS platform");
                }

                _instance = new Machine();
            }
            return _instance;
        }

        private Machine() : base(Machine.LocalMachineGuid, Machine.Versions[Machine.Versions.Count - 1], _attributes, new byte[0])
        {
        }

    }
}
