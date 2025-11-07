using Portfolio.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Dto.RequestDto
{
    public class ProfileRequestDto
    {
        [Required]
        [MinLength(3)]
        [SwaggerSchema(Description ="please provide the name of the user,this will be displayed on landing page,and minimum length should be 3 characters")]
        public string ProfileHolderName { get; set; }
        [Required]
        [MinLength(3)]
        [SwaggerSchema(Description = "please provide the designation of the user,this will be displayed on landing page,and minimum length should be 3 characters")]
        public string ProfileHolderCurrentDesignation { get; set; }
        [Required]
        [EmailAddress]
        [SwaggerSchema(Description = "please provide the email of the user,this will be displayed on landing page")]
        public string ProfileHolderEmail { get; set; }
        [Required]
        [RegularExpression(@"^[6-9]\d{9}$",ErrorMessage ="please enter 10 digit valid indian number ")]
        [SwaggerSchema(Description = "please provide the phone number of the user,this will be displayed on landing page")]
        public string ProfileHolderPhoneNumber { get; set; }
        [Required]
        [SwaggerSchema(Description = "please provide the avaialability to work of the user,this will be displayed on landing page,and pease provide the data from the provide enums only")]
        public AvailabilityToWorkStatus ProfileHolderAvailabilityToWorkStatus { get; set; }
        [Required]
        [SwaggerSchema(Description = "please provide the image of the user,this will be displayed on landing page,should be resolution of 400X400 and size should be less than 1 mb")]
        public IFormFile ProfileImage { get; set; }
        [Required]
        [SwaggerSchema(Description = "please provide the Resume of the user,this will be displayed on landing page,and file should be less than the 5 mb and should be in the pdf only")]
        public IFormFile ResumeFile { get; set; }
        [Required]
        [MinLength(10)]
        [SwaggerSchema(Description = "please provide the short description of the user,this will be displayed on landing page,and minimum length should be 10 characters")]
        public string ProfileHolderShortDescription { get; set; }
        [Required]
        [MinLength(50)]
        [SwaggerSchema(Description = "please provide the long description of the user,this will be displayed on landing page,and minimum length should be 50 characters")]
        public string ProfileHolderLongDescription { get; set; }
        [Required]
        [MinLength(10)] 
        [SwaggerSchema(Description = "please provide the address of the user,this will be displayed on landing page,,and minimum length should be 10 characters")]
        public string ProfileHolderAddress { get; set; }

    }
}
