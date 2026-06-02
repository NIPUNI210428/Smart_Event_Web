using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Smart_Event_Web.Models
{
    [BsonIgnoreExtraElements]
    public class Venue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Venue_id")]
        public int Venue_id { get; set; }

        [BsonElement("Venue_Name")]
        public string Venue_Name { get; set; } = string.Empty;

        [BsonElement("Address")]
        public string Address { get; set; } = string.Empty;

        [BsonElement("Capacity")]
        public int Capacity { get; set; }
    }
}  
