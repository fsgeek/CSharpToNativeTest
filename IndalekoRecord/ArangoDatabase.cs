using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
//using Core.Arango;
using ArangoDBNetStandard;
using ArangoDBNetStandard.DatabaseApi.Models;
using ArangoDBNetStandard.CollectionApi.Models;

namespace Indaleko
{
    public class ArangoDatabase : IDatabase
    {
        private ArangoServer? _server = null;
        private string? dbName = null;
        private ArangoDBClient? _client = null;

        public ArangoDBClient? ArangoDBClient { get { return _client; }  }
        public bool Connected = false;

        public ArangoDatabase(ArangoServer server, string databaseName)
        {
            _server = server;
            dbName = databaseName;
            _client = new ArangoDBClient(server.GetTransportForDatabase(dbName));
        }

        public void Connect()
        {
            Debug.Assert(null != _client, "Improperly initialized");
            var databases = _server.GetDatabases();
            if (!databases.Contains(dbName) )
            {
                Connected = _server.CreateNewDatabase(dbName);
            }
        }

        public void Disconnect()
        {
            // not implemented
        }

        public bool IsConnected()
        {
            return null != _client;
        }

        public void Query(string QueryString)
        {
            throw new NotImplementedException();
        }

        public long GetCollectionCount(string collectionName)
        {
            long count = 0;

            if (!Connected)
            {
                Connect();
            }

            if (null != _client)
            {
                try
                {
                    count = _client.Collection.GetCollectionCountAsync(collectionName).Result.Count;
                }
                catch (Exception ex)
                { 
                    Debug.WriteLine(ex);
                    count = -1; // usually means the database doesn't exist.
                }
            }
            return count;
        }

        public long GetCollections()
        {
            if (null == _client)
            {
                return 0;
            }

            var collections = _client.Collection.GetCollectionsAsync().Result;

            return 0;
        }

        public bool CreateCollection(string collectionName)
        {
            var newCollectionBody = new PostCollectionBody();

            newCollectionBody.Name = collectionName;

            if (null == _client)
            {
                return false;
            }

            var result = _client.Collection.PostCollectionAsync(newCollectionBody).Result;

            return true; // raises on fail
        }
    }
}
