using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indaleko
{
    public interface IDatabase
    {
        void Connect();
        void Disconnect();
        bool IsConnected();
        void Query(string QueryString);

    }
}
