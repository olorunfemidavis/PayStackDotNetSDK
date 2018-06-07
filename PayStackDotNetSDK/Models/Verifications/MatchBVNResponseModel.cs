using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Verifications
{
    public class MatchBVNResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
        public Meta meta { get; set; }
    }
    public class Data
    {
        public bool is_match { get; set; }
    }
  
}
