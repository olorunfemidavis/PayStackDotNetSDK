using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Verifications
{
    public class ResolvePhoneNumberResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public ResolvePhoneNumberData data { get; set; }
    }
    public class ResolvePhoneNumberData
    {
        public string requestId { get; set; }
        public string state { get; set; }
    }

}
