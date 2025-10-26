using MongoDB.Bson.Serialization.Attributes;
using Portfolio.Enums;

namespace Portfolio.Models
{
    public class ApplicationUser
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRequired]
        [BsonElement("User_Name")]
        public string UserName { get; set; }
        [BsonRequired]
        [BsonElement("Email_Id")]
        public string EmailId { get; set; }
        [BsonRequired]
        [BsonElement("Hashed_Password")]
        public string HashedPassword { get; set; }
        [BsonRequired]
        [BsonElement("Role")]
        public ApplicationUserRoles Role { get; set; }
    }
}
