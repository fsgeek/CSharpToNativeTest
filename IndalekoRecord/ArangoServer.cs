using System;
using System.Diagnostics;
using ArangoDBNetStandard;
using ArangoDBNetStandard.DatabaseApi;
using ArangoDBNetStandard.DatabaseApi.Models;
using ArangoDBNetStandard.Transport.Http;

namespace Indaleko
{
    public class ArangoServer
    {
        private HttpApiTransport? _httpTransport = null;

        private string? _url = null;
        private string? _user = null;
        private string? _password = null;
        private static ArangoServer? _server = null;
        private DatabaseApiClient? _databaseApiClient = null;

        public ArangoServer Server { get; }

        private ArangoServer()
        {

        }

        public static ArangoServer? GetArangoServer()
        {
            return _server;
        }

        public HttpApiTransport GetTransportForDatabase(string databaseName)
        {
            return HttpApiTransport.UsingBasicAuth(new Uri(_url), databaseName, _user, _password);
        }

        public static ArangoServer CreateArangoServer(string url,  string user, string password)
        {
            if (null == _server)
            {
                _server = new ArangoServer();
                _server._url = url;
                _server._user = user;
                _server._password = password;
                _server._httpTransport = HttpApiTransport.UsingBasicAuth(new Uri(url), "_system", user, password);

                _server._databaseApiClient = new DatabaseApiClient(_server._httpTransport);
            }
            else
            {
                // If this is a need, this package has to be generalized somehow
                Debug.Assert(url == _server._url, "Conflict with existing server definition");
                Debug.Assert(user == _server._user, "Conflict with existing user definition");
                Debug.Assert(password == _server._password, "Conflict with existing password");
            }
            return _server;
        }

        public List<string> GetDatabases()
        {
            var res = _databaseApiClient.GetDatabasesAsync().Result;
            return new List<string>(res.Result);
        }

        public bool CreateNewDatabase(string databaseName)
        {
            PostDatabaseBody request = new PostDatabaseBody();
            PostDatabaseResponse response;

            request.Name = databaseName;

            response = _databaseApiClient.PostDatabaseAsync(request).Result;

            // docs say this is "always true" so I'm guessing it raises if it fails.
            return response.Result;
        }

    }
}
