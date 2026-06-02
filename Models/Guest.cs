using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Smart_Event_Web.Models
{
    public class Guest
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public int Guest_id { get; set; }

        
        public string Session_token { get; set; } = default!;
    }
}
