using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Smart_Event_Web.Models
{
    [BsonIgnoreExtraElements]
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Event_id")]
        public int Event_id { get; set; }

        [BsonElement("Member_id")]
        public int Member_id { get; set; }

        [BsonElement("Rating")]
        public int Rating { get; set; }

        [BsonElement("Comments")]
        public string Comments { get; set; } = string.Empty;

        [BsonElement("Review_Date")]
        public string Review_Date { get; set; } = string.Empty;
    }
} 
