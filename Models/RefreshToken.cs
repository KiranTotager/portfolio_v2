using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class RefreshToken
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public DateTime ExpiryTime { get; set; }
        [Required]
        public  string DeviceInfo { get; set; }
        [Required]
        public string DeviceIp { get; set; }
        [Required]
        public bool IsRevoked { get; set; }
    }
}
