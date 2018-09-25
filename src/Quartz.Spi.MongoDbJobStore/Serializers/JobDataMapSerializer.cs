using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Newtonsoft.Json;

namespace Quartz.Spi.MongoDbJobStore.Serializers
{
    internal class JobDataMapSerializer : SerializerBase<JobDataMap>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, JobDataMap value)
        {
            if (value == null)
                context.Writer.WriteNull();
            else
                context.Writer.WriteString(JsonConvert.SerializeObject(value));
        }

        public override JobDataMap Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            if (context.Reader.CurrentBsonType != BsonType.Null)
                return JsonConvert.DeserializeObject<JobDataMap>(context.Reader.ReadString());

            context.Reader.ReadNull();
            return null;
        }
    }
}