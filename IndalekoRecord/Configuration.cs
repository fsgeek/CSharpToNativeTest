using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indaleko
{
    public class Configuration
    {
        //
        // This is a generic configuration.  We need to specialize these as we begin to define specific types of configuration
        //

        public Guid ConfigurationIdentifier { get; }
        public string ConfigurationName { get; }
        public byte[] ConfigurationData { get; }

        private static string ConfigurationCollectionName = @"IndalekoConfiguration";
        private static Configuration? _instance = null;
        private ArangoDatabase? _database = null;
        private ArangoCollection? _configCollection = null;

        internal class ConfigurationCollection
        {
            private static ConfigurationCollection? _instance = null;
            private ArangoCollection? _collection = null;

            private ConfigurationCollection() { }

            static ConfigurationCollection CreateConfigurationCollection(ArangoDatabase database)
            {
                if (null == _instance)
                {
                    _instance = new ConfigurationCollection();
                    _instance._collection = new ArangoCollection(database, "Configuration");
                }

                return _instance;
            }

        }

        private Configuration()
        {
            ConfigurationName = "unnamed";
            ConfigurationData = new byte[0];
        }

        public static Configuration GetConfiguration(ArangoDatabase database)
        {
            if (null == _instance)
            {
                _instance = new Configuration();
                _instance._database = database;
            }

            return _instance;
        }

        public Dictionary<string,string> LoadConfiguration(string configurationName)
        {
            return new Dictionary<string,string>();
        }
    }
}
