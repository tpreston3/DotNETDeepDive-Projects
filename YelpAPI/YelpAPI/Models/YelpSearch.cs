using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace YelpAPI.Models
{
    [NotMapped]
    public class YelpSearch
    {
        public int ID { get; set; }
        public string Term { get; set; }
        public string Location { get; set; }

    }
}
