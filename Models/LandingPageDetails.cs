using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class LandingPageDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }
        [Required(ErrorMessage ="hello message is required"),MaxLength(100,ErrorMessage ="maximum allowed characters are 100")]
        public string HelloMessage { get; set; }
        [Required(ErrorMessage ="Passion message is required"),MaxLength(300,ErrorMessage ="maximum allowed characters are 300")]
        public string PassionMessage { get; set; }
        [Required(ErrorMessage ="Short Description is required"),MaxLength(500,ErrorMessage ="maximum allowed characters are 500")]
        public string ShortDescription { get; set; }
    }
}
