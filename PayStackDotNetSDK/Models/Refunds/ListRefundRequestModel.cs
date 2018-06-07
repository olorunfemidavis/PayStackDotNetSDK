using PayStackDotNetSDK.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Refunds
{
    public class ListRefundRequestModel
    {
        public string transaction { get; set; }
        public string currency { get; set; } = Constants.Currency.Naira;
    }
}
