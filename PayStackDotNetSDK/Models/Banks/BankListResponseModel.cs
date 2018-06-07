using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Banks
{
    public class BankListResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Bank> data { get; set; }
    }
}
