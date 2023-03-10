using ArangoDBNetStandard.DocumentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Indaleko
{
    public class ArangoDocument
    {
        private ArangoCollection _collection;

        public ArangoDocument(ArangoCollection collection)
        {
            _collection = collection;
        }

        public bool CreateDocument<T>(T document)
        {
            var response = _collection.PostDocument<T>(document);
            return true;
        }
    }
}
