using System.ComponentModel.DataAnnotations;

namespace COMP2084_Assignment2_DmitryKnyazhevskiy.Models
{
    public class CampSession
    {
        public int campSessionId { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name ="Max Number of Campers")]
        public int maxCampers { get; set; }

        [Required]
        [Display(Name = "Number of Campers")]
        public int numberCampers { get; set; }

        public List<Camper>? Campers { get; set; }

    }
}
