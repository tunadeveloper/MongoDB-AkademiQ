using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_AkademiQ.Entities
{
    public class Reference
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string LogoUrl { get; set; }
        public string Description { get; set; }
    }
}
