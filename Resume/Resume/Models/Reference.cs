using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    public class Reference 
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter Your Name - Field Cannot be blank")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name or Initial")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Enter Your Last Name - Field Cannot be blank")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Field Cannot be blank")]
        [Display(Name = "Employer of Reference")]
        public string Employer { get; set; }

        [Required(ErrorMessage = "Field Cannot be blank")]
        [Display(Name = "Job Title of Reference")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Field Cannot be blank")]
        [Display(Name = "Relationship to Reference")]
        public string Relationship { get; set; }  // Co-worker, Manager, Supervisor, Friend etc.

        [Display(Name = "Phone Number")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddr { get; set; }

    }
}
