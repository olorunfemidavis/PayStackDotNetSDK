using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.Banks
{
    public class BankListResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Bank> data { get; set; }
    }
}
