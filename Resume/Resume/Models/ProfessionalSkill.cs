using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    public class ProfessionalSkill
    {

        public int ID { get; set; }

        [Required]
        [Display(Name = "Descrption of Skill/Course")]
        [StringLength(60, MinimumLength = 5)]
        public string SkillDescrption { get; set; }

        [Required]
        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyy}")]
        public DateTime Date { get; set; }

        [Display(Name = "Where?")]
        public string InstitutionName { get; set; }
        
        public string State { get; set; }

        public string City { get; set; }

        [Display(Name = "Zip Code")]
        public int? ZipCode { get; set; }


    }
}

