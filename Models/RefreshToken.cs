using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class RefreshToken
    {
        public long Id { get; set; }
        [Required(ErrorMessage ="User id is required")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Token is required")]
        public string Token { get; set; }
        [Required(ErrorMessage = "ExpiryTime is required")]
        public DateTime ExpiryTime { get; set; }
        [Required(ErrorMessage = "DeviceInfo is required")]
        public  string DeviceInfo { get; set; }
        [Required(ErrorMessage = "DeviceIp is required")]
        public string DeviceIp { get; set; }
        [Required(ErrorMessage = "IsRevoked is required")]
        public bool IsRevoked { get; set; }
    }
}
