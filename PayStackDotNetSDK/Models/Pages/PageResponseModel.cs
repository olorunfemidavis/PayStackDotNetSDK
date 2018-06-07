using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Pages
{
    public class PageResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public string name { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public int integration { get; set; }
        public string domain { get; set; }
        public string slug { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public bool collect_phone { get; set; }
        public bool active { get; set; }
        public bool published { get; set; }
        public bool migrate { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
