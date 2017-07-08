using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace YelpAPI.Models
{
    [NotMapped]
    [DataContract]
    public class YelpSearchResult
    {

        public int ID { get; set; }

        [DataMember]
        public int total { get; set; }

        [DataMember]
        public List<Business> businesses { get; set; }

        [DataMember]
        public Region region { get; set; }
    }

        public class Category
        {
            public int CategoryID { get; set; }
            public string alias { get; set; }
            public string title { get; set; }
        }

        public class Coordinates
        {
            public int CoordinatesID { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
        }

        public class Location
        {
            public int LocationID { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string address2 { get; set; }
            public string address3 { get; set; }
            public string state { get; set; }
            public string address1 { get; set; }
            public string zip_code { get; set; }
        }

        public class Business
        {
            public int BusinessID { get; set; }
            public double rating { get; set; }
            public string price { get; set; }
            public string phone { get; set; }
            public string id { get; set; }
            public bool is_closed { get; set; }
            public List<Category> categories { get; set; }
            public int review_count { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public Coordinates coordinates { get; set; }
            public string image_url { get; set; }
            public Location location { get; set; }
            public double distance { get; set; }
          
            //public List<string> transactions { get; set; }
        }

        public class Center
        {
            public int CenterID { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
        }

        public class Region
        {
            public int RegionID { get; set; }
            public Center center { get; set; }
        }

        
    }

