using Microsoft.Win32;
using System.Collections;

namespace Indaleko.Windows
{
    //
    // A way to store configuration data in the registry so it doesn't have to be embedded in code.
    public class RegistryData
    {
        // public const string IndalekoRegistryKey = "HKEY_CURRENT_USER\\Indaleko";
        // public readonly string ServiceRegistryKeyName;
        public const string IndalekoRegistryKeyName = "Indaleko";

        private RegistryKey IndalekoRegistryKey;
        private RegistryKey ServiceKey;
        private string ServiceName;
        private Dictionary<string, object?> ServiceValues = new Dictionary<string, object?>();
        private Dictionary<string, object?> Parameters = new Dictionary<string, object?>();

        public RegistryData(string ServiceName)
        {
            if (null == ServiceName)
            {
                throw new ArgumentNullException(nameof(ServiceName));
            }

            if ((ServiceName.Length < 4) || (ServiceName.Length >= 256))
            {
                // Don't use service names smaller than 4 characters or larger than 255.
                throw new ArgumentOutOfRangeException(nameof(ServiceName));
            }

            this.ServiceName = ServiceName;
            IndalekoRegistryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser,RegistryView.Registry64).CreateSubKey(IndalekoRegistryKeyName);

            ServiceKey = IndalekoRegistryKey.CreateSubKey(ServiceName);

            foreach (string ValueName in ServiceKey.GetValueNames())
            {
              ServiceValues[ValueName] = ServiceKey.GetValue(ValueName);
            }

            var subKeys = ServiceKey.GetSubKeyNames();

            if (subKeys.Contains("Parameters"))
            {
                var paramKey = ServiceKey.OpenSubKey("Parameters");

                foreach (string ValueName in paramKey.GetValueNames())
                {
                    Parameters[ValueName] = paramKey.GetValue(ValueName);
                }
            }
        }

        public object this[string Key]
        {
            get {  
            
                if ((null != ServiceValues) && ServiceValues.ContainsKey(Key) && (null != ServiceValues[Key]))
                {
                   return ServiceValues[Key];
                }

                if ((null != Parameters) && Parameters.ContainsKey(Key) && (null != Parameters[Key]))
                {
                    return Parameters[Key];
                }

                throw new ArgumentException("Invalid Key");

            }
        }

        public bool ContainsKey(string Key)
        {
            return ServiceValues.ContainsKey(Key);
        }

        public Dictionary<string, object?> GetValues()
        {
            // Merge dictionaries, preferring entries in main key to those in Parameters
            return ServiceValues.Concat(Parameters.Where(kvp => !ServiceValues.ContainsKey(kvp.Key))).GroupBy(p => p.Key).ToDictionary(g => g.Key, g => g.Last().Value);
        }

    }
}
