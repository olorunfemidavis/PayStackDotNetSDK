using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Transfers
{
    public class FinalizeTransferResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public inalizeTransferData data { get; set; }
    }
    public class inalizeTransferData
    {
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
        public int integration { get; set; }
        public int recipient { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

   
}
