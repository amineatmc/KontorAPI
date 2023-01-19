using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.Model
{
    public class PersonModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
