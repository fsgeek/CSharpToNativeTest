using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indaleko
{
    public interface IStorageProvider
    {
        //
        // This is the interface for storage providers.
        //

        string Name { get; }
        int Version { get; }
        Dictionary<string, object?> Attributes{ get;}
        byte[] Data { get; }

        // TODO: need to define methods for this storage provider
    }
}
