using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    public class Accomplishment
    {

        public int ID { get; set; }

        [Required]
        [Display(Name = "Add a Major Accomplishment")]
        public string accomplishment { get; set; }

        [Display(Name = "Major Accomplishments")]
        public virtual List<Accomplishment> Accomplishments { get; set; }

       // [Display(Name = "For Which Job?")]
        
       // public int? JobID { get; private set; }
        //[ForeignKey("JobID")]
        public virtual Job Jobs { get; set; }


        

    }
}