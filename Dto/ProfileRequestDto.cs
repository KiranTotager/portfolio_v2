using MongoDB.Bson.Serialization.Attributes;
using Portfolio.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Dto
{
    public class ProfileRequestDto
    {
        [Required]
        [MinLength(3)]
        [SwaggerSchema(Description ="please provide the name of the user,this will be displayed on landing page")]
        public string ProfileHolderName { get; set; }
        [Required]
        [MinLength(3)]
        [SwaggerSchema(Description = "please provide the designation of the user,this will be displayed on landing page")]
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
        [SwaggerSchema(Description = "please provide the avaialability to work of the user,this will be displayed on landing page")]
        public AvailabilityToWorkStatus ProfileHolderAvailabilityToWorkStatus { get; set; }
        [Required]
        [SwaggerSchema(Description = "please provide the image of the user,this will be displayed on landing page")]
        public IFormFile FormFile { get; set; }
        [Required]
        [SwaggerSchema(Description = "please provide the Resume of the user,this will be displayed on landing page")]
        public IFormFile ResumeFile { get; set; }
        [Required]
        [MinLength(10)]
        [SwaggerSchema(Description = "please provide the short description of the user,this will be displayed on landing page")]
        public string ProfileHolderShortDescription { get; set; }
        [Required]
        [MinLength(50)]
        [SwaggerSchema(Description = "please provide the long description of the user,this will be displayed on landing page")]
        public string ProfileHolderLongDescription { get; set; }
        [Required]
        [MinLength(10)] 
        [SwaggerSchema(Description = "please provide the address of the user,this will be displayed on landing page")]
        public string ProfileHolderAddress { get; set; }

    }
}
