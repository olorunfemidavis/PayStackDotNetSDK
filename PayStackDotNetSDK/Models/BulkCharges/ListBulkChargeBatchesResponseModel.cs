using System;
using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.BulkCharges
{
    public class ListBulkChargeBatchesResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<ListBulkChargeBatch> data { get; set; }
        public Meta meta { get; set; }
    }
    public class ListBulkChargeBatch
    {
        public int integration { get; set; }
        public string domain { get; set; }
        public string batch_code { get; set; }
        public string status { get; set; }
        public string easy_cron_id { get; set; }
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
