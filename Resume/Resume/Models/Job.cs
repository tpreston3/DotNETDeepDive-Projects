using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    public class Job
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Employer Name")]
        public string EmployerName { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime StopDate { get; set; }

        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }

        public ICollection<Employment> Employments { get; set; } //An ICollection List of Accomplishments 


    }
}
