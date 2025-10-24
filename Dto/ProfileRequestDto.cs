using MongoDB.Bson.Serialization.Attributes;
using Portfolio.Enums;

namespace Portfolio.Dto
{
    public class ProfileRequestDto
    {
        public string ProfileHolderName { get; set; }
        public string ProfileHolderCurrentDesignation { get; set; }
        public string ProfileHolderEmail { get; set; }
        public string ProfileHolderPhoneNumber { get; set; }
        public AvailabilityToWorkStatus ProfileHolderAvailabilityToWorkStatus { get; set; }
        public string ProfileHolderProfilePicUrl { get; set; }
        public string ProfileHolderResumeUrl { get; set; }
        public string ProfileHolderShortDescription { get; set; }
        public string ProfileHolderLongDescription { get; set; }
        public string ProfileHolderAddress { get; set; }


    }
}
