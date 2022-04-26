using NativeCalls;
using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;
using USNJournal;
using Serilog;
using CommandLine;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CSharpToNativeTest
{
    class Program
    {
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

        static void Main(string[] args)
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

            UNICODE_STRING c_drive = new UNICODE_STRING("\\??\\C:");
            SafeFileHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            OBJECT_ATTRIBUTES objattr = new OBJECT_ATTRIBUTES(handle, c_drive);
            ACCESS_MASK mask = (UInt32)ACCESS_MASK.SYNCHRONIZE;
            IO_STATUS_BLOCK statusBlock = new IO_STATUS_BLOCK();
            FILE_ATTRIBUTES fileAttr = 0;
            SHARE_ACCESS shareAccess = SHARE_ACCESS.FILE_SHARE_READ | SHARE_ACCESS.FILE_SHARE_WRITE;
            CREATE_DISPOSITION disposition = CREATE_DISPOSITION.FILE_OPEN;
            CREATE_OPTIONS options = CREATE_OPTIONS.FILE_NON_DIRECTORY_FILE;
            EXTENDED_ATTRIBUTE ea = new EXTENDED_ATTRIBUTE();
            NtStatusCode status = SystemCalls.NtCreateFile(ref handle, mask, objattr, ref statusBlock, (LARGE_INTEGER)0, fileAttr, shareAccess, disposition, options, ea);

            if (!NtStatus.NT_SUCCESS(status))
            {
                Console.WriteLine("NtCreateFile failed, status {0} ({0:X}) = {1}", status, NtStatusToString.StatusToString(status));
            }

            Console.WriteLine("Drives supporting USN journals:");
            List<string> UsnCapableDrives = USN_JOURNAL.GetUsnCapableDrives();
            foreach (string drive in UsnCapableDrives)
            {
                Console.WriteLine($"\t{drive}");
            }

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

            Console.WriteLine("Drives with active USN journals:");
            List<USN_JOURNAL_DRIVE_DATA> UsnDrives = USN_JOURNAL.GetActiveUsnJournalDrives();
            foreach (USN_JOURNAL_DRIVE_DATA data in UsnDrives)
            {
                Console.WriteLine($"\t{data.Drive}");
                USN_JOURNAL usnJournal = new USN_JOURNAL(data.Drive);
                uint count = usnJournal.UpdateUsnRecords();
                Console.WriteLine($"\tRetrieved {count} records from {data.Drive}");
                Thread.Sleep(5000);
                count = usnJournal.UpdateUsnRecords();
                Console.WriteLine($"\tRetrieved {count} more records from {data.Drive}");
            }

            /*
             * This is what fsutil shows for the USN journal information
             * 
             *  PS C:\Users\TonyMason\source\repos\CSharpToNativeTest\MountManagerTest\bin\Debug\net6.0> fsutil usn queryJournal c:
                Usn Journal ID   : 0x01d6a0c52c1b9016
                First Usn        : 0x0000000c02800000
                Next Usn         : 0x0000000c04d18550
                Lowest Valid Usn : 0x0000000000000000
                Max Usn          : 0x00000fffffff0000
                Maximum Size     : 0x0000000002000000 (32.0 MB)
                Allocation Delta : 0x0000000000800000 ( 8.0 MB)
                Minimum record version supported : 2
                Maximum record version supported : 4
                Write range tracking: Disabled
            */

            // Prior work has been focused on static data sets.  To make this a useful system service we need to support dynamic data collection, which
            // gives rise to the systems problem that are at the heart of my research.
            Log.Information("Test Done");
            Log.CloseAndFlush();
        }
    }
}
