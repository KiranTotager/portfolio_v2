
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class Experiance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required] 
        public string CompanyName { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public DateTime StartedFrom { get; set; }
        public DateTime? WorkedTill { get; set; }
        public string CompanyImageUrl { get; set; }
    }
}
