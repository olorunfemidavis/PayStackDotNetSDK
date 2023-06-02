using System;
using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.TransfersControls
{
    public class BalanceLedgerResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<BalanceLedger> data { get; set; }
        public Meta meta { get; set; }
    }
    public class BalanceLedger
    {
        public int integration { get; set; }
        public string domain { get; set; }
        public int balance { get; set; }
        public string currency { get; set; }
        public int difference { get; set; }
        public string reason { get; set; }
        public string model_responsible { get; set; }
        public int model_row { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
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
