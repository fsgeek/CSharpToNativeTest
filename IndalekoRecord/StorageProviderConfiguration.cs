using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indaleko
{
    public class StorageProviderConfiguration
    {
        public class IndalekoStorageProvider : Indaleko.Record
        {
            private IndalekoStorageProvider(Guid ProviderIdentifier, int Version, Dictionary<string, object?> Attributes, byte[] Data) : base(ProviderIdentifier, Version, Attributes, Data)
            { 
            }

            public static IndalekoStorageProvider CreateIndalekoStorageProvider(Guid ProviderIdentifier, int Version, Dictionary<string, object?> Attributes, byte[] Data)
            {
                // For now, we just cretate the object.
                return new IndalekoStorageProvider(ProviderIdentifier, Version, Attributes, Data);
            }

        }
        //
        // The purpose of this class is to capture information about a given
        // storage provider.
        //
        private IStorageProvider _storageProvider;

        public string StorageProviderName => _storageProvider.Name;

        StorageProviderConfiguration(IStorageProvider storageProvider)
        {
            _storageProvider = storageProvider;

        }

        static StorageProviderConfiguration CreateNewStorageProvider(IStorageProvider storageProvider, Dictionary<string, object?> Attributes, byte[] Data, int Version = 1)
        {
            var isp = IndalekoStorageProvider.CreateIndalekoStorageProvider(Guid.NewGuid(), Version, Attributes, Data);
            var spc = new StorageProviderConfiguration(storageProvider);
            return spc;
        }
    }
}
