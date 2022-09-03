using Microsoft.Win32.SafeHandles;
using Serilog;
using CommandLine;
using System.Security.Principal;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.Win32;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.DirectoryServices;
using Core.Arango;


namespace USBDeviceCheck
{
    // Note: this is copied from ArangoDBTest - really should be extracted and made into a
    // library.

    // https://github.com/coronabytes/dotnet-arangodb
    public class IndalekoRecord
    {

        public struct Source
        {
            Guid Identifier;
            int Version;
        }

        public Guid SourceIdentifier { get; }
        public int SourceVersion { get; }

        public UInt64 Timestamp { get; }

        public Dictionary<string, object?> Attributes { get; }

        public byte[] Data { get; }

        protected IndalekoRecord(Guid SourceId, int SourceVersion, Dictionary<string, object?> Attributes, byte[] Data)
        {
            SourceIdentifier = SourceId;
            this.SourceVersion = SourceVersion;
            this.Attributes = Attributes;
            // TODO: need to create timestamp using some canonical format; I don't really care what it is.
            UInt64 now = (UInt64)DateTime.UtcNow.ToBinary();
            UInt64 unixEpoch = (UInt64)DateTime.UnixEpoch.ToBinary();
            now -= unixEpoch;  // It's now a UNIX Epoch date/time value
            Timestamp = now - unixEpoch;
            this.Data = Data;
        }

    }

    public class Machine : IndalekoRecord
    {
        // Use a "well-known GUID to indicate this is coming from the local machine
        private const string LocalMachineGuidString = "84635987-5a15-48c1-95e7-64651d4923cd";
        private static readonly Guid LocalMachineGuid = new Guid(LocalMachineGuidString);
        private static string? LocalMachineGuidDescription = "NTFS USN Journal";
        private static readonly ReadOnlyCollection<int> _versions = new ReadOnlyCollection<int>(new[] { 1, });
        private static ReadOnlyCollection<int> Versions { get { return _versions; } }
        public string _key { get; set; }
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
            _key = Machine.LocalMachineGuid.ToString();
        }

    }
    class Program
    {
        public static SecurityIdentifier GetComputerSid()
        {
            return new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid;
        }

        public class Options
        {
            [Option(Default = (int)Serilog.Events.LogEventLevel.Information, HelpText = "Log Level")]
            public int LogLevel { get; set; }
        }

        static void RunOptions(Options opts)
        {
            int loglevel = 3;

            if (null != opts)
            {
                if ((opts.LogLevel < (int)Serilog.Events.LogEventLevel.Verbose) || (opts.LogLevel > (int)Serilog.Events.LogEventLevel.Fatal))
                {
                    Console.WriteLine($"LogLevel must be between {(int)Serilog.Events.LogEventLevel.Fatal} (Fatal messages only) and {(int)Serilog.Events.LogEventLevel.Information} ()");
                }
                loglevel = opts.LogLevel;

                switch (loglevel)
                {
                    case (int)Serilog.Events.LogEventLevel.Verbose:
                        Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose().WriteTo.Console().CreateLogger();
                        break;
                    case (int)Serilog.Events.LogEventLevel.Debug:
                        Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().CreateLogger();
                        break;
                    case (int)Serilog.Events.LogEventLevel.Information:
                        Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();
                        break;
                    case (int)Serilog.Events.LogEventLevel.Warning:
                        Log.Logger = new LoggerConfiguration().MinimumLevel.Warning().WriteTo.Console().CreateLogger();
                        break;
                    case (int)Serilog.Events.LogEventLevel.Error:
                        Log.Logger = new LoggerConfiguration().MinimumLevel.Error().WriteTo.Console().CreateLogger();
                        break;
                    default:
                        Log.Logger = new LoggerConfiguration().MinimumLevel.Fatal().WriteTo.Console().CreateLogger();
                        break;
                }
            }
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
            Console.WriteLine(errs);
            throw new InvalidProgramException("Invalid command line option");
        }

        static async Task Main(string[] args)
        {

            Parser.Default.ParseArguments<Options>(args).WithParsed(RunOptions).WithNotParsed(HandleParseError);

            //             Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose).CreateLogger();
            Log.Information("Start Test");
            Log.Verbose("Verbose enabled");
            Log.Debug("Debug enabled");
            Log.Information("Information enabled");
            Log.Warning("Warning enabled");
            Log.Error("Error enabled");
            Log.Fatal("Fatal enabled");

            string systemSid;
            string userName;
            using (WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent())
            {
                systemSid = windowsIdentity.User.Value.Substring(0, windowsIdentity.User.Value.LastIndexOf('-'));
                userName = windowsIdentity.Name;
                Console.WriteLine(windowsIdentity.User.Value);
            }
            Console.WriteLine($"systemSid = {systemSid}");
            Console.WriteLine($"name = {userName}");
            Console.WriteLine($"Machine = {Environment.MachineName}");
            Console.WriteLine($"UserDomainName = {Environment.UserDomainName}");
            Console.WriteLine($"GetComputerSid = {GetComputerSid()}");

            // Console.WriteLine(UserPrincipal.Current.Sid.ToString());
            // var user = WindowsIdentity.GetCurrent().User;
            // string sid = UserPrincipal.Current.Sid.ToString();

            // Console.WriteLine("Name: " + UserPrincipal.Current.Name);
            // Console.WriteLine("GUID: " + UserPrincipal.Current.Guid);
            // Console.WriteLine(" SID: " + UserPrincipal.Current.Sid);
            // Console.WriteLine("UPN: " + UserPrincipal.Current.UserPrincipalName);


            // Let's connect to ArangoDB
            var arango_system = new ArangoContext("Server=http://localhost:8529;User=root;Password=Kwishut22;");

            Console.WriteLine("Arango Context Established");

            // await arango.Database.CreateAsync("wamtest");
            var dblist = await arango_system.Database.ListAsync();
            Console.WriteLine($"dblist length = {dblist.Count}");
            foreach (var db in dblist)
            {
                Console.WriteLine($"\t{db}");
            }

            string wamtestDB = "wamtest";
            if (dblist.Contains(wamtestDB))
            {
                Console.WriteLine($"Use existing {wamtestDB} database");
            }
            else
            {
                if (await arango_system.Database.CreateAsync(wamtestDB))
                {
                    Console.WriteLine($"Created {wamtestDB} database");
                }
                else
                {
                    Console.WriteLine($"Creation of {wamtestDB} database failed");
                }
            }

            string machineCollection = "machines";

            try
            {
                var machines = await arango_system.Collection.GetAsync(wamtestDB, machineCollection);
            }
            catch (ArangoException ex)
            {
                if (ex.ErrorNumber == ArangoErrorCode.ErrorArangoDataSourceNotFound)
                {
                    await arango_system.Collection.CreateAsync(wamtestDB, new Core.Arango.Protocol.ArangoCollection
                    {
                        Name = machineCollection,
                        Type = Core.Arango.Protocol.ArangoCollectionType.Document,
                        KeyOptions = new Core.Arango.Protocol.ArangoKeyOptions
                        {
                            Type = Core.Arango.Protocol.ArangoKeyType.Uuid,
                            AllowUserKeys = true
                        }
                    });
                }
                else Debug.Assert(false); // something else is wrong
            }

            var collections = await arango_system.Collection.ListAsync(wamtestDB);

            Console.WriteLine($"Found {collections.Count} collections");

            foreach (var collection in collections)
            {
                Console.WriteLine($"{collection.Name}");
            }

            Console.WriteLine(JsonSerializer.Serialize<Machine>(Machine.GetMachineInfo()));


            Machine machine = Machine.GetMachineInfo();
            Machine dbmachine;

            try
            {
                dbmachine = await arango_system.Document.GetAsync<Machine>(wamtestDB, machineCollection, machine._key);
                // let's see if we can find the data for this machine
            }
            catch (ArangoException ex)
            {
                await arango_system.Document.CreateAsync<Machine>(wamtestDB, machineCollection, machine);
                dbmachine = await arango_system.Document.GetAsync<Machine>(wamtestDB, machineCollection, machine._key);
            }

            Console.WriteLine($"Database returns:\n{JsonSerializer.Serialize<Machine>(dbmachine)}");
            Console.WriteLine($"   Local Version:\n{JsonSerializer.Serialize<Machine>(machine)}");

            // await arango_system.Document.CreateAsync<Machine>(wamtestDB, machineCollection, machineData);

            // Prior work has been focused on static data sets.  To make this a useful system service we need to support dynamic data collection, which
            // gives rise to the systems problem that are at the heart of my research.
            Log.Information("Test Done");
            Log.CloseAndFlush();
        }
    }
}
