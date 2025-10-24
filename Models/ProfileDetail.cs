using MongoDB.Bson.Serialization.Attributes;
using Portfolio.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Portfolio.Models
{
    public class ProfileDetail
    {
        [BsonRequired]
        [BsonElement("Full_Name")]
        public string Name { get; set; }
        [BsonElement("Current_Designation")]
        [BsonRequired]
        public string CurrentDesignation { get; set; }
       
        [BsonRequired]
        [BsonElement("Work_Email")] 
        public string Email { get; set; }
        [BsonRequired]
        [BsonElement("Phone_Number")]
        public string PhoneNumber { get; set; }
        [BsonRequired]
        [BsonElement("Availability_To_Work_Status")]
        public AvailabilityToWorkStatus AvailabilityToWorkStatus { get; set; }
        [BsonRequired]
        [BsonElement("Profile_Pic_Url")]
        public string ProfilePicUrl { get; set; }
        [BsonElement("Resume_Url")]
        [BsonRequired]
        public string ResumeUrl { get; set; }
        [BsonRequired]
        [BsonElement("Short_Description")]
        public string ShortDescription { get; set; }
        [BsonRequired]
        [BsonElement("long_Description")]
        public string LongDescription { get; set; }
        [BsonRequired]
        [BsonElement("Address")]
        public string Address { get; set; }
       
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [BsonRequired]
        [BsonElement("Profile_Updated_At")]
        public DateTime ResumeUpdatedAt { get; set; }
    }
}
