using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace YelpAPI.Models
{
    [DataContract]
    public class YelpAuthToken
    {
        public int ID { get; set; }

        [DataMember]
        public string access_token { get; set; }
        [DataMember]
        public string token_type { get; set; }
        [NotMapped]
        [DataMember]
        public int expires_in { get; set; }

        // Not part of the returned serialized data back from Yelp 
        public DateTime expire_date { get; set; }
    }
}
