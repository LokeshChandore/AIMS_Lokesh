using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MessagingAPI.Console.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement("entryDate")]
        public DateTime EntryDate { get; set; }

        [BsonRepresentation(BsonType.Double)]
        [BsonElement("price")]
        public double Price { get; set; }
    }
}
