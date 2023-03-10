using ArangoDBNetStandard;
using ArangoDBNetStandard.CollectionApi;
using ArangoDBNetStandard.CollectionApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Indaleko
{
    public class ArangoCollection
    {
        private ArangoDatabase _database;
        private string _collectionName;

        public ArangoCollection(ArangoDatabase database, string collectionName)
        {
            _database = database;
            _collectionName = collectionName;

            var count = _database.GetCollectionCount(collectionName);

            if (count < 0)
            {
                // collection doesn't exist
                // need to create it.
                Debug.Assert(_database.CreateCollection(_collectionName), "Collection creation should not fail");
            }

            // TODO: the above should raise if the collection doesn't exist, right?

        }

        public string PostDocument<T>(T document)
        {
            Debug.Assert(null != _database.ArangoDBClient, "Cannot work with a null database client structure");

            return _database.ArangoDBClient.Document.PostDocumentAsync<T>(_collectionName, document).Result._id;
        }

        public T GetDocument<T>(string id)
        {
            Debug.Assert(null != _database.ArangoDBClient, "Cannot work with a null database client structure");
            return _database.ArangoDBClient.Document.GetDocumentAsync<T>(_collectionName, id).Result;
        }

        public string DeleteDocument(string id)
        {
            Debug.Assert(null != _database.ArangoDBClient, "Cannot work with a null database client structure");
            return _database.ArangoDBClient.Document.DeleteDocumentAsync(_collectionName, id).Result._id;
        }

    }
}
