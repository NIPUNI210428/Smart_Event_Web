using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Smart_Event_Web.Models;

[BsonIgnoreExtraElements] 
public class Booking
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } 

    [BsonElement("Booking_id")]
    public int Booking_id { get; set; }

    [BsonElement("Member_id")]
    public int Member_id { get; set; }

    [BsonElement("Event_id")]
    public int Event_id { get; set; }

    [Required]
    [BsonElement("Seat_type")]
    public string Seat_type { get; set; } = "Standard";

    [Required]
    [Range(1, 10)]
    [BsonElement("Quantity")]
    public int Quantity { get; set; }

    [BsonElement("Booking_date")]
    public string Booking_date { get; set; } = string.Empty; 
} 
