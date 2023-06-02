using System;
using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.Transfers
{
    public class TransferListResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Transfer> data { get; set; }
        public Meta meta { get; set; }
    }
   
    public class Transfer
    {
        public int integration { get; set; }
        public Recipient recipient { get; set; }
        public string domain { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string reference { get; set; }
        public string source { get; set; }
        public object source_details { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
        public object failures { get; set; }
        public string transfer_code { get; set; }
        public object titan_code { get; set; }
        public object transferred_at { get; set; }
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
