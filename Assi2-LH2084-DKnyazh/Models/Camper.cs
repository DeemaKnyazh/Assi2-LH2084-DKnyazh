using Assi2_LH2084_DKnyazh.Models;
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
        [Display(Name = "Age")]
        public int age { get; set; }

        [Required]
        [Display(Name = "Camp Session")]
        public int campSessionId { get; set; }

        public int? statusId { get; set; }

        public Status? Status { get; set; }

        public CampSession? CampSession { get; set; }

    }
}
