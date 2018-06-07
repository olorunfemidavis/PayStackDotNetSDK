using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Verifications
{
    public class ResolveAccountNumberResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public AccountData data { get; set; }
    }
    public class AccountData
    {
        public string account_number { get; set; }
        public string account_name { get; set; }
    }
}
