using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class RefreshToken
    {
        [Required]
        [BsonElement("user_id")]
        public string UserId { get; set; }
        [Required]
        [BsonElement("Refresh_token")]
        public string Token { get; set; }
        [Required]
        [BsonElement("expiry_time")]
        public DateTime ExpiryTime { get; set; }
    }
}
