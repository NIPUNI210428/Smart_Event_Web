using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Smart_Event_Web.Models
{
    [BsonIgnoreExtraElements]
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Event_id")]
        public int Event_id { get; set; }

       
        [BsonElement("Event_Name")]
        public string Event_Name { get; set; } = string.Empty;

        [BsonElement("Category")]
        public string Category { get; set; } = string.Empty;

        [BsonElement("Venue")]
        public string Venue { get; set; } = string.Empty;

        
        [BsonElement("Event_Date")]
        public string Event_Date { get; set; } = string.Empty;

        [BsonElement("Price")]
        public double Price { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; } = string.Empty;

        [BsonElement("ImageFileName")]
        public string? ImageFileName { get; set; }
    }
} 