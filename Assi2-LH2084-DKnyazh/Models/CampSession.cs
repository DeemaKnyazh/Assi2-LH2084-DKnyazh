﻿using System.ComponentModel.DataAnnotations;

namespace COMP2084_Assignment2_DmitryKnyazhevskiy.Models
{
    public class CampSession
    {
        public int campSessionId { get; set; }

        [Display(Name = "Start Date")]

        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]

        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name ="Max Number of Campers")]
        public int maxCampers { get; set; }

 
        public int numberCampers { get; set; }

        public List<Camper>? Campers { get; set; }

    }
}
