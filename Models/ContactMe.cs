using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class ContactMe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="name is required"), MaxLength(100,ErrorMessage ="maximum length for name 100 only")]
        public string Name { get; set; }
        [Required(ErrorMessage ="email id is required"), MaxLength(100,ErrorMessage ="email id should be within the length of  100")]
        public string Email { get; set; }
        [Required(ErrorMessage ="phone number is required"), MaxLength(15,ErrorMessage ="phone number should be within the length of 15")]
        public string PhoneNumber { get; set; }
        [MaxLength(300,ErrorMessage = "message should be within the length of  300 ")]
        public string?  Message { get; set; }
    }
}
