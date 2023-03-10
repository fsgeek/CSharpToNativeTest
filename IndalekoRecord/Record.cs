
namespace Indaleko
{

    // https://github.com/coronabytes/dotnet-arangodb
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

    }

}