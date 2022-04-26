using NativeCalls;
using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;
using MountManagerLibrary;
using Serilog;

namespace MountManagerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MountManager mountMgr = new MountManager();
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            Log.Information("Start Test");

            Console.WriteLine("List of drives with drive letters:");
            foreach (string drive in mountMgr.GetDrivesWithLetters())
            {
                Console.WriteLine("\t" + drive);
            }

            Console.WriteLine("List of all drives:");
            foreach (string drive in mountMgr.GetAllDrives())
            {
                Console.WriteLine($"\t{drive}");
            }

            Log.Information("Test Done");
            Log.CloseAndFlush();
        }
    }
}
