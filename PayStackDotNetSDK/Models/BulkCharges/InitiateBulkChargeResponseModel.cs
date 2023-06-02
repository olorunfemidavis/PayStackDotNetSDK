using System;

namespace PayStackDotNetSDK.Models.BulkCharges
{
    public class InitiateBulkChargeResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public BulkChargeData data { get; set; }
    }
    public class BulkChargeData
    {
        public string domain { get; set; }
        public string batch_code { get; set; }
        public string status { get; set; }
        public string easy_cron_id { get; set; }
        public int id { get; set; }
        public int integration { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
