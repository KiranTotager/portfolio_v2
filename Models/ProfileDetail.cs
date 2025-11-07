using Portfolio.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Portfolio.Models
{
    public class ProfileDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required"),MaxLength(50,ErrorMessage = "Maximum length for Name is 50 only")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Current Designation is Required"),MaxLength(50,ErrorMessage = "Maximum length for Current Designation is 50 only")]
        public string CurrentDesignation { get; set; }
        [Required(ErrorMessage = "Current Email is Required"),MaxLength(100,ErrorMessage = "Maximum length for Email  is 50 only")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Current PhoneNumber is Required"),MaxLength(50,ErrorMessage = "Maximum length for PhoneNumber  is 50 only")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Current AvailabilityToWorkStatus is Required"),Column("Availability_To_WOrk_Status")]
        public AvailabilityToWorkStatus AvailabilityToWorkStatus { get; set; }
        [Column("Profile_Url")]
        public string? ProfilePicUrl { get; set; }
        [Column("Resume_Url"),Required(ErrorMessage ="Resume url is required")]
        public string ResumeUrl { get; set; }
        [Required(ErrorMessage ="Short description is required"),MaxLength(300,ErrorMessage = "Maximum length for Short_Description  is 300 only"),Column("Short_Description")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Long description is required"),MaxLength(1000,ErrorMessage = "Maximum length for Long_Description  is 1000 only"),Column("Long_Description")]
        public string LongDescription { get; set; }
        [Required(ErrorMessage = "Address is required"),MaxLength(1000,ErrorMessage = "Maximum length for Address  is 50 only"),Column("Address")]
        public string Address { get; set; }
        [Column("Updated_At")]
        public DateTime UpdatedAt { get; set; }
        
    }
}
