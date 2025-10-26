using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class ContactMe
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRequired]
        [BsonElement("Requested_Person_Name")]
        public string Name { get; set; }
        [BsonRequired]
        [BsonElement("Requested_Person_Email")]
        public string Email { get; set; }
        [BsonRequired]
        [BsonElement("Requested_Person_PhoneNumber")]
        public string PhoneNumber { get; set; }
        [BsonElement("Message")]
        public string?  Message { get; set; }
    }
}
