using System;

namespace PayStackDotNetSDK.Models.TransferRecipients
{
    public class TransferRecipientModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
    public class Details
    {
        public string account_number { get; set; }
        public object account_name { get; set; }
        public string bank_code { get; set; }
        public string bank_name { get; set; }
    }

    public class Data
    {
        public string name { get; set; }
        public int integration { get; set; }
        public string domain { get; set; }
        public string type { get; set; }
        public Details details { get; set; }
        public string currency { get; set; }
        public string recipient_code { get; set; }
        public bool active { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

  
}
