﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Resume.Models
{
    public class Contact
    {
        public int ID { get; set; }

        // Display for First Name
        [Required(ErrorMessage = "Enter Your Name - Field Cannot be blank")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name or Initial")]
        public string MiddleName { get; set; }
        
        [Required(ErrorMessage = "Enter Your Last Name - Field Cannot be blank")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter Your a Street Number - Field Cannot be blank")]
        [Display(Name = "Street Number")]
        public int StreetNumber { get; set; }

        [Required(ErrorMessage = "Enter Your a Street Name - Field Cannot be blank")]
        [Display(Name = "Street Name")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Enter Your a City - Field Cannot be blank")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter Your a State - Field Cannot be blank")]
        public string State { get; set; }

        [Required(ErrorMessage = "Enter Your a Zip Code - Field Cannot be blank")]
        [Display(Name ="Zip Code")]
        public int ZipCode { get; set; }

        [Display(Name ="Phone Number")]
        [DisplayFormat(ApplyFormatInEditMode= true)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string  EmailAddr { get; set; }

        [Display(Name = "Enter a Website")]
        [DataType(DataType.Url)]
        public string Website { get; set; }

        [Display(Name = "Employments History")]
        public ICollection<Job> Jobs { get; set; } //List of Jobs Per Contact

        [Display(Name = "Professional References ")]
        public ICollection<Reference> References { get; set; } //List of References Per Contact

        [Display(Name = "Education History")]
        public ICollection<Education> Educations { get; set; } // List of Education Per Contact

        [Display(Name = "Descrption of Skills/Courses")]
        public ICollection<ProfessionalSkill> ProfessionalSkills{ get; set; }   // List of Professional Skills Per Contact

       

    }
}
