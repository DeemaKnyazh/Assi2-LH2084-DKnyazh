using System.ComponentModel.DataAnnotations;

namespace COMP2084_Assignment2_DmitryKnyazhevskiy.Models
{
    public class Camper
    {
        public int camperId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        public int sessionId { get; set; }

        [Required]
        public int status { get; set; }

    }
}
