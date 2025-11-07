using Portfolio.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Dto.RequestDto
{
    public class ApplicationUserRequestDto
    {
        [Required]
        [SwaggerSchema("please provide the name of the user")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [SwaggerSchema(Description = "please provide the email id of the user, this will be used for login")]
        public string EmailID { get; set; }
        [Required]
        [SwaggerSchema(Description = "please provide the password of the user, password should be minimum 8 characters long and should contain at least one uppercase letter, one lowercase letter, one digit and one special character")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[a-zA-Z\d@$!%*?&]{8,}$", ErrorMessage = "password should be minimum 8 characters long and should contain at least one uppercase letter, one lowercase letter, one digit and one special character")]
        public string Password { get; set; }
        [Required]
        [SwaggerSchema(Description = "please provide the role of the user, select from the available roles")]
        public ApplicationUserRoles Role { get; set; }
    }
}
