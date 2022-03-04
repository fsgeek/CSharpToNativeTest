using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Principal;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Indaleko
{
    public class Record
    {

        public struct Source
        {
            Guid Identifier;
            int Version;
        }

        public Guid SourceIdentifier { get; }
        public int SourceVersion { get; }

        public UInt64 Timestamp { get; }

        public Dictionary<string, object?> Attributes { get; }

        public byte[] Data { get; }

        protected Record(Guid SourceId, int SourceVersion, Dictionary<string, object?> Attributes, byte[] Data)
        {
            SourceIdentifier = SourceId;
            this.SourceVersion = SourceVersion;
            this.Attributes = Attributes;
            // TODO: need to create timestamp using some canonical format; I don't really care what it is.
            UInt64 now = (UInt64)DateTime.UtcNow.ToBinary();
            UInt64 unixEpoch = (UInt64)DateTime.UnixEpoch.ToBinary();
            now -= unixEpoch;  // It's now a UNIX Epoch date/time value
            Timestamp = now - unixEpoch;
            this.Data = Data;
        }

        public BsonDocument GenerateBsonDocument()
        {
            var document = new BsonDocument();

            document.Add("SourceIdentifier", new BsonBinaryData(SourceIdentifier, GuidRepresentation.Standard));
            document.Add("SourceVersion", new BsonInt32(SourceVersion));
            document.Add("Timestamp", new BsonTimestamp((Int64)Timestamp));

            Console.WriteLine($"Stored timestamp is... {document["Timestamp"].AsBsonTimestamp}");

            var attrs = new BsonDocument(Attributes);

            document.Add("Attributes", attrs);


            document.Add("Data", new BsonBinaryData(Data));

            return document;
        }

    }
}