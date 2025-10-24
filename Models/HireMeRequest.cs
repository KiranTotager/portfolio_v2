using MongoDB.Bson.Serialization.Attributes;
using Portfolio.Enums;

namespace Portfolio.Models
{
    public class HireMeRequest
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]    
        public int Id { get; set; }
        [BsonElement("Requested_Person_Name")]
        [BsonRequired]
        public string Name { get; set; }
        [BsonRequired]
        [BsonElement("Requested_Person_Email")]
        public string Email { get; set; }
        [BsonRequired]
        public RequestFrom RequestFrom { get; set; }
        [BsonIgnoreIfNull]
        public string?  Description { get; set; }
        [BsonRequired]
        [BsonElement("Available_budget")]
        public decimal Budget { get; set; }
        
    }
}
