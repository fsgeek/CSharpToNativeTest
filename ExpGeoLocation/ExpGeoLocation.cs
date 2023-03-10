using Microsoft.Win32.SafeHandles;
using Serilog;
using CommandLine;
using Windows.Devices.Geolocation;
// using System.Text.Json;

namespace CSharpToNativeTest
{
    class ExpGeoLocation
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

        private async Task GetCurrentLocation()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                _geolocator = new Geolocator { ReportInterval = 60000 };
                Geoposition position = await _geolocator.GetGeopositionAsync();
                Console.WriteLine($"Current position: {position}");
                Console.WriteLine($"Allowed Access: {position.Coordinate}");

            }
            else
            {
                Console.WriteLine($"Access is not allowed ({accessStatus}");
            }

        }

        internal class Location
        {
            double Latitude;
            double Longitude;

            Location(double latitude, double longitude)
            {
                Latitude = latitude;
                Longitude = longitude;
            }

            Location(Geoposition geoposition)
            {
                Latitude = geoposition.Coordinate.Latitude;
                Longitude = geoposition.Coordinate.Longitude;
            }
        }

        private Geolocator? _geolocator = null;

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

            // So this retrieves the current location once

            if (GeolocationAccessStatus.Allowed == await Geolocator.RequestAccessAsync())
            {
                Geolocator gl = new Geolocator { ReportInterval = 60000 };
                Geoposition position = await gl.GetGeopositionAsync();

                Console.WriteLine($"Position is: {position.Coordinate.Longitude}, {position.Coordinate.Latitude}");
                Console.WriteLine($"{position.Coordinate.ToString()}");
            }

            // Prior work has been focused on static data sets.  To make this a useful system service we need to support dynamic data collection, which
            // gives rise to the systems problem that are at the heart of my research.
            Log.Information("Test Done");
            Log.CloseAndFlush();
        }
    }
}
