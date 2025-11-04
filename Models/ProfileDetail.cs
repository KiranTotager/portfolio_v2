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
        public string Name { get; set; }
        public string CurrentDesignation { get; set; }
       
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public AvailabilityToWorkStatus AvailabilityToWorkStatus { get; set; }
        public string ProfilePicUrl { get; set; }
        public string ResumeUrl { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Address { get; set; }
       
        public DateTime UpdatedAt { get; set; }
        
    }
}
