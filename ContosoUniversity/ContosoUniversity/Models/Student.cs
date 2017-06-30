using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Student : Person
    {
        //public int ID { get; set; }

        //[Required]
        //[Display(Name = "Last Name")]
        //[StringLength(50, ErrorMessage ="Get a shorter last name must be less than 50 Characters")]
        //[RegularExpression(@"^[A-Z].*$", ErrorMessage ="First Letter must be capital letter")]
        //public string LastName { get; set; }

        //[Required]
        //[Display(Name = "First Name")]
        //[StringLength(50, ErrorMessage = "Get a shorter First name must be less than 50 Characters")]
        //[RegularExpression(@"^[A-Z].*$", ErrorMessage = "First Letter must be capital letter")]
        //public string  FirstMidName { get; set; }

        [Required]
        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date, ErrorMessage ="Please enter a valid date (YYYY/MM/DD)")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        //[NotMapped]
        //public string FullName
        //{
        //    get {
        //        return String.Format("{0} {1}", FirstMidName, LastName);
        //    }
        //}
    }
}
