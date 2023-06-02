using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.BulkCharges
{
    public class FetchChargesInBatchResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<object> data { get; set; }
        public Meta meta { get; set; }
    }
}
