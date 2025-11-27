using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Dto.RequestDto
{
    public class ContactUsRequestDto
    {
        [Required(ErrorMessage ="name is mandatory")]
        [SwaggerSchema("name of the person who want's to connect with us")]
        public string Name { get; set; }

        [SwaggerSchema("email id of the person who want's to connect with us")]
        [Required(ErrorMessage ="Email id is mandatory"),EmailAddress]
        public string Email { get; set; }

        [SwaggerSchema("phone number of the person who want's to connect with us")]
        [Required(ErrorMessage ="phone number is mandatory"),RegularExpression(@"^\d{10}$",ErrorMessage ="please provide the valid phone number")]
        public string PhoneNumber { get; set; }

        [SwaggerSchema("message of the person who want's to connect with us")]
        [Required(ErrorMessage ="message is mandatory")]
        public string Message { get; set; }
    }
}
