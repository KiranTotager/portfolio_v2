using Portfolio.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Dto.ResponseDto
{
    public class ProfileResponseDto
    {
        public string ProfileHolderName { get; set; }
        public string ProfileHolderCurrentDesignation { get; set; }
        public string ProfileHolderEmail { get; set; }
        public string ProfileHolderPhoneNumber { get; set; }
        public AvailabilityToWorkStatus ProfileHolderAvailabilityToWorkStatus { get; set; }
        public string ProfileImageUrl { get; set; }
        public string ResumeFileUrl { get; set; }
        public string ProfileHolderShortDescription { get; set; }
        public string ProfileHolderLongDescription { get; set; }
        public string ProfileHolderAddress { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
