using System.IdentityModel.Tokens.Jwt;

namespace Indaleko
{
    public class DropboxStorageConfiguration : IStorageProvider
    {
        public string Name { get { return _dropboxStorageConfigurationName; } }
        public int Version { get { return _dropboxStorageConfigurationVersion; } }
        public Guid StorageProviderUuid { get { return _dropboxStorageProviderUuid; } }
        public Dictionary<string, object?> Attributes { get { return _dropboxStorageAttributes; } }
        public byte[] Data { get { return _dropboxData; } }

        public class DropboxCredentialInformation
        {
            public JwtSecurityToken SecurityToken { get; }

            public DropboxCredentialInformation(JwtSecurityToken securityToken)
            {
                SecurityToken = securityToken;
            }

            public DropboxCredentialInformation(string JwtFile) 
            {
                SecurityToken = new JwtSecurityToken(File.ReadAllText(JwtFile));
            }
        }

        private static string _dropboxStorageConfigurationName = "Dropbox";
        private DropboxCredentialInformation _dropboxCredentialInformation { get; set; }
        private Guid _dropboxStorageProviderUuid = Guid.Parse("2156fcda-9732-4b01-bb0d-ff0cd07a3124");
        private int _dropboxStorageConfigurationVersion = 1;
        private Dictionary<string, object?> _dropboxStorageAttributes = new Dictionary<string, object?>(); // empty for now
        private byte[] _dropboxData = new byte[0]; // empty for now.  Maybe endpoint information?

        private DropboxStorageConfiguration(JwtSecurityToken jwtToken) 
        {
            _dropboxCredentialInformation = new DropboxCredentialInformation(jwtToken);
        }

        private DropboxStorageConfiguration(DropboxCredentialInformation dbCred)
        {
            _dropboxCredentialInformation = dbCred;
        }

        public static DropboxStorageConfiguration CreateDropboxStorageConfiguration(DropboxCredentialInformation dropboxCredentialInformation) 
        {
            var dbsc = new DropboxStorageConfiguration(dropboxCredentialInformation);

            return dbsc;
        }

        public static DropboxStorageConfiguration CreateDropboxStorageConfigurat(string JwtSecurityTokenPath) 
        { 
            var dbsc = new DropboxStorageConfiguration(new JwtSecurityToken(JwtSecurityTokenPath));

            return dbsc;
        }
    }
}
