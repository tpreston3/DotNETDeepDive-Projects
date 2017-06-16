using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    public class Education 
    {
        public int ID { get; set; }

        [Display(Name = "Assocaited Contact")]
        public int ContactID { get; set; }

        [Display(Name = "Name Of Institution")]
        public string InstitutionName { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }
        
        [Required]
        [Display(Name = "Date Started")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Graduation")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime Graduation { get; set; }

        public Contact Contact { get; set; } // Navigation Property 

    }
}
