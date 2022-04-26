using MongoDB.Bson;
using MongoDB.Driver;


namespace Indaleko
{
    //
    // The purpose of the activity log is to provide a generalized interface for storing information
    // into the activity log.  Someone using this shouldn't need to know where/how the activity log
    // is maintained.
    //
    // Note that this is a singleton, since I don't envision having multiple activity logs.
    //
    public class ActivityLog
    {
        //
        // Having a static configuration is not flexible, but it is expedient.
        //
        public static void ConfigureActivityLog(ActivityLog Log)
        {
            throw new NotImplementedException("ActivityLog is a base class.");
        }
    }

    public class MongoActivityLog : ActivityLog
    {
        private static readonly Lazy<MongoActivityLog> _MongoActivityLog = new Lazy<MongoActivityLog>((() => new MongoActivityLog()));
        private string _ConnectionString = "mongodb://Indaleko:Kwishut21@localhost:27017/?authSource=admin";
        private string _DatabaseName = "Indaleko";
        private string _LogName = "Activity";
        private MongoClient activityLogClient;
        private IMongoDatabase activityLogDatabase;
        private IMongoCollection<BsonDocument> activityLogCollection;

        private MongoActivityLog()
        {
        }

        private static MongoActivityLog _Instance { get { return _MongoActivityLog.Value; } }

        public static string ConnectionName
        {
            get
            {
                return _Instance._ConnectionString;
            }

            set
            {
                if (null == _Instance.activityLogClient)
                {
                    _Instance._ConnectionString = value;
                }

            }
        }

        public static string DatabaseName
        {
            get
            {
                return _Instance._DatabaseName;
            }

            set
            {
                if (null == _Instance.activityLogDatabase)
                {
                    _Instance._DatabaseName = value;
                }
            }
        }

        public static string LogName
        {
            get
            {
                return _Instance._LogName;
            }

            set
            {
                if (null == _Instance.activityLogCollection)
                {
                    _Instance._LogName = value;
                }
            }
        }

        public void ConfigureActivityLog(MongoActivityLog MongoConfigurationData)
        {
            _Instance.activityLogClient = new MongoClient(ConnectionName);
            _Instance.activityLogDatabase = _Instance.activityLogClient.GetDatabase(DatabaseName);
            _Instance.activityLogCollection = _Instance.activityLogDatabase.GetCollection<BsonDocument>(LogName);
        }

        public void WriteRecord(Record RecordToAdd)
        {
            var document = RecordToAdd.GenerateBsonDocument();

            activityLogCollection.InsertOne(document);

        }

    }

}

