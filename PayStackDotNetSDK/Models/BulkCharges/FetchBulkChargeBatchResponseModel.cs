using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.BulkCharges
{
    public class FetchBulkChargeBatchResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public BulkChargeBatcheData data { get; set; }
    }
    public class BulkChargeBatcheData
    {
        public int integration { get; set; }
        public string domain { get; set; }
        public string batch_code { get; set; }
        public string status { get; set; }
        public int id { get; set; }
        public int total_charges { get; set; }
        public int pending_charges { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
