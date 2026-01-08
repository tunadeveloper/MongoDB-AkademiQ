using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_AkademiQ.Entities;

public class Newsletter
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public string Email { get; set; }
}
