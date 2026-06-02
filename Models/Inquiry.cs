using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Smart_Event_Web.Models
{
    public class Inquiry
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("GuestName")]
        public string GuestName { get; set; } = default!;

        [BsonElement("Email")]
        public string Email { get; set; } = default!;

        [BsonElement("Subject")]
        public string Subject { get; set; } = default!;

        [BsonElement("Message")]
        public string Message { get; set; } = default!;

        [BsonElement("SubmittedAt")]
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}
