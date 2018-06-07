using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Verifications
{
    public class ResolveBVNResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public BVNData data { get; set; }
        public Meta meta { get; set; }
    }
    public class BVNData
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string dob { get; set; }
        public string formatted_dob { get; set; }
        public string mobile { get; set; }
        public string bvn { get; set; }
    }

    public class Meta
    {
        public int calls_this_month { get; set; }
        public int free_calls_left { get; set; }
    }

  
}
