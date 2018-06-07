using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Settlements
{
    public class SettlementResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<object> data { get; set; }
        public Meta meta { get; set; }
    }
    public class Meta
    {
        public int total { get; set; }
        public int skipped { get; set; }
        public int perPage { get; set; }
        public int page { get; set; }
        public int pageCount { get; set; }
    }

   
}
