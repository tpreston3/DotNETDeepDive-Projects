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
        public string Description { get; set; }

       // Navigation Property to Jobs Model
       public Job Jobs{ get; set; }




    }
}