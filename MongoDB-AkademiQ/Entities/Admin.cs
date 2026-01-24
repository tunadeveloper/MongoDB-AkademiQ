using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_AkademiQ.Entities
{
    public class Admin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }
    }
}
