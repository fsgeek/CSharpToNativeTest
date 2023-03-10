using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArangoDBNetStandard;

namespace Indaleko
{
    internal class DBFactory
    {
        // This is the connector we use for talking to a database.  This should allow us to
        // abstract away from a particular database, assuming I've done this properly.

        public static IDatabase CreateDatabase(string databaseName, string url,  string username, string password)
        {

            return new ArangoDatabase(ArangoServer.CreateArangoServer(url, username, password), databaseName);
        }
    }
}
