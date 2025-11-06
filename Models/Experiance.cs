
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class Experiance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="company name is requiired"),Column("Company_Name"),MaxLength(50,ErrorMessage ="Maximum length for COmapnyName is 50 only")] 
        public string CompanyName { get; set; }
        [Required(ErrorMessage ="Designation is required"),MaxLength(100,ErrorMessage = "Maximum length for COmapnyName is 100 only")]
        public string Designation { get; set; }
        [Required(ErrorMessage ="Designation is required"),MaxLength(100,ErrorMessage = "Maximum length for Duration is 100 only")]
        public string Duration { get; set; }
        [Required(ErrorMessage ="start date is required"),Column("Started_From")]
        public DateTime StartedFrom { get; set; }
        [Column("Worked_TIll")]
        public DateTime? WorkedTill { get; set; }
        [Column("Company_Image_Url")]
        public string CompanyImageUrl { get; set; }
    }
}
