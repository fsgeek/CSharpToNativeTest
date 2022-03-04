using Microsoft.Win32.SafeHandles;
using MongoDB.Bson;
using MongoDB.Driver;
using Serilog;
using CommandLine;
using System.Security.Principal;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.Win32;

namespace MongoDBTest
{

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

        protected IndalekoRecord(Guid SourceId, int SourceVersion, Dictionary<string, object?> Attributes, byte [] Data)
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

        public BsonDocument GenerateBsonDocument()
        {
            var document = new BsonDocument();

            document.Add("SourceIdentifier", new BsonBinaryData(SourceIdentifier, GuidRepresentation.Standard));
            document.Add("SourceVersion", new BsonInt32(SourceVersion));
            document.Add("Timestamp", new BsonTimestamp((Int64) Timestamp));

            Console.WriteLine($"Stored timestamp is... {document["Timestamp"].AsBsonTimestamp}");
            
            var attrs = new BsonDocument(Attributes);

            document.Add("Attributes", attrs);


            document.Add("Data", new BsonBinaryData(Data));

            return document;
        }

    }

    public class Machine : IndalekoRecord
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


            // Let's connect to Mongo
            MongoClient dbClient = new MongoClient("mongodb://Indaleko:Kwishut21@localhost:27017/?authSource=admin");

            Console.WriteLine("Mongo Databases:");
            using (IAsyncCursor<BsonDocument> cursor = dbClient.ListDatabases())
            {
                while (cursor.MoveNext())
                {
                    foreach (var doc in cursor.Current)
                    {
                        Console.WriteLine($"\t{doc["name"]}");
                    }
                }
            }

            // Let's see if we can find our database
            IMongoDatabase wamtestdb = dbClient.GetDatabase("wamtest");

            if (wamtestdb != null)
            {
                Console.WriteLine("Found test database");
            }
            else
            {
                Console.WriteLine("Did not find test database");
                return;
            }

            var identCollection = wamtestdb.GetCollection<BsonDocument>("machines");

            if (null == identCollection)
            {
                throw new Exception("Could not find the collection");
            }

            var filter = Builders<BsonDocument>.Filter.Eq("machine_name", Environment.MachineName);

            if (null == filter)
            {
                Console.WriteLine("Did not find machine");
            }
            else
            {
                // Let's insert information about this machine
                var uuid = Guid.NewGuid();

                Machine machineInfo = Machine.GetMachineInfo();
                if (null == machineInfo)
                {
                    throw new NullReferenceException("Machine information is null");
                }

                string systemGuid = "";
                object result;

                if (machineInfo.Attributes.TryGetValue("SystemGuid", out result) && (systemGuid.GetType() == result.GetType()))
                {
                    systemGuid = (string) result;

                    // Let's see if we can find this in the dictionary.
                    var sysGuidFilter = Builders<BsonDocument>.Filter.Eq("Attributes.SystemGuid", systemGuid);

                    if (null == sysGuidFilter)
                    {
                        throw new Exception("Unexpected lookup failure");
                    }

                    Console.WriteLine("Starting to look for machine information");
                    var machineList = await identCollection.Find(sysGuidFilter).ToListAsync();


                    if (0 == machineList.Count)
                    {
                        // Let's add this to MongoDB
                        var machineDocument = machineInfo.GenerateBsonDocument();

                        identCollection.InsertOne(machineDocument);
                        Console.WriteLine("Created new entry");
                        Console.WriteLine($"Machine Info:\n{machineDocument.ToJson()}");
                        Console.WriteLine($"_id is: {machineDocument["_id"]}");
                    }
                    else
                    {
                        Console.WriteLine($"Found {machineList.Count} matching entries");
                        foreach (var entry in machineList)
                        {
                            var _id = new ObjectId(entry["_id"].ToString());

                            Console.WriteLine($"_id timestamp is {_id.CreationTime}");
                        }
                    }
                }

                // What do we want to put into machine identity?  How about:
                // Name
                // Unique identifier (if any)
                // IP address (?)
                // OS Data: this probably consists of a common name and version identifiers.
                // Configuration Data
                // 
            }


            // Prior work has been focused on static data sets.  To make this a useful system service we need to support dynamic data collection, which
            // gives rise to the systems problem that are at the heart of my research.
            Log.Information("Test Done");
            Log.CloseAndFlush();
        }
    }
}
