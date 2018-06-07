using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayStackDotNetSDK.Models.Transactions
{
    public class TransactionListResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Data> data { get; set; }
        public Meta meta { get; set; }

    }
    public class Meta
    {
        public int total { get; set; }
        public int total_volume { get; set; }
        public int skipped { get; set; }
        public int perPage { get; set; }
        public int page { get; set; }
        public int pageCount { get; set; }
    }

}