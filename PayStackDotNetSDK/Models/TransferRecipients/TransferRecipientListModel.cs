using System;
using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.TransferRecipients
{
    public class TransferRecipientListModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<TransferRecipient> data { get; set; }
        public Meta meta { get; set; }
    }
   
    public class TransferRecipient
    {
        public int integration { get; set; }
        public string domain { get; set; }
        public string type { get; set; }
        public string currency { get; set; }
        public string name { get; set; }
        public Details details { get; set; }
        public object description { get; set; }
        public Metadata metadata { get; set; }
        public string recipient_code { get; set; }
        public bool active { get; set; }
        public object email { get; set; }
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
