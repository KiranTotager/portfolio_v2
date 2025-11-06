using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Dto.RequestDto
{
    public class LandingPageDetailDto
    {
        [SwaggerSchema("here give what message you want to display in landing page ex: hello,i'm kiran")]
        [Required(ErrorMessage = "hello message is required"), MaxLength(100, ErrorMessage = "maximum allowed characters are 100")]
        public string HelloMessage { get; set; }
        [SwaggerSchema("here give about your passion in a attractive way to show on landing page")]
        [Required(ErrorMessage = "Passion message is required"), MaxLength(300, ErrorMessage = "maximum allowed characters are 300")]
        public string PassionMessage { get; set; }
        [Required(ErrorMessage = "Short Description is required"), MaxLength(500, ErrorMessage = "maximum allowed characters are 500")]
        [SwaggerSchema("here provide a attractive ',' separated desciption to show on landing page")]
        public string ShortDescription { get; set; }
    }
}
