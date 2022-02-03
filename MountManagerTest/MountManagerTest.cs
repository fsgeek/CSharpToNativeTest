using NativeCalls;
using NativeSupportLibrary;
using Microsoft.Win32.SafeHandles;
using MountManagerLibrary;

namespace MountManagerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MountManager mountMgr = new MountManager();

            Console.WriteLine("Test Done");
        }
    }
}
