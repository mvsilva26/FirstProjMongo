using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjMongo.Model
{
    public class Address
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Streat { get; set; }
        public string Number { get; set; }





    }
}
