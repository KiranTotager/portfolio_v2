using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Dto.RequestDto
{
    public class LoginRequestDto
    {
        [Required]
        [SwaggerSchema("please provide the email id for login")]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        [SwaggerSchema("please provide the password for login")]
        public string Password { get; set; }
    }
}
