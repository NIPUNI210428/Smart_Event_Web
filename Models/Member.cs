using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Smart_Event_Web.Models
{
    [BsonIgnoreExtraElements]
    public class Member
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        
        [BsonElement("Member_id")]
        public int Member_id { get; set; }

        [Required, Display(Name = "First Name")]
        [BsonElement("FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [Required, Display(Name = "Last Name")]
        [BsonElement("LastName")]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        [BsonElement("Email")]
        public string Email { get; set; } = string.Empty;

        [Required, Phone, Display(Name = "Phone Number")]
        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;

        [BsonElement("Preferences")]
        public string? Preferences { get; set; }

        [Required, DataType(DataType.Password)]
        [BsonElement("Password")]
        public string Password { get; set; } = string.Empty;
    }
} 