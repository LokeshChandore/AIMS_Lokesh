using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MessagingAPI.Console.Models
{
    public class PriceReduction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("dayOfWeek")]
        public int DayOfWeek { get; set; }

        [BsonElement("reduction")]
        public double Reduction { get; set; }
    }
}
