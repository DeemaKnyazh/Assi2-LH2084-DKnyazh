using COMP2084_Assignment2_DmitryKnyazhevskiy.Models;
using System.ComponentModel.DataAnnotations;

namespace Assi2_LH2084_DKnyazh.Models
{
    public class Status
    {
        public int statusId {  get; set; }
        [Required]
        public String statusName { get; set; }
        public List<Camper>? Campers { get; set; }
    }
}
