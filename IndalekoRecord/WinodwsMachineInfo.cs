using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indaleko;

namespace Indaleko
{
    public class WindowsMachineInfo
    {
        private string _config_name = "WindowsMachineInfo";
        private Configuration? _config = null;

        private Record? _record;

        private static Dictionary<string, object> _attributes = new Dictionary<string, object>();
        private static WindowsMachineInfo? _instance = null;

        private WindowsMachineInfo(ArangoServer server)
        {
        }
    }
}
