using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.TransferRecipients
{
    public class TransferRecipientRequestModel
    {
        public string type { get; set; }
        public string name { get; set; }
        public string account_number { get; set; }
        public string bank_code { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public Metadata metadata { get; set; }
    }
}