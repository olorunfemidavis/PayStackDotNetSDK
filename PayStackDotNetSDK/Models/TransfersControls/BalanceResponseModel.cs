using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.TransfersControls
{
    public class BalanceResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Balance> data { get; set; }
    }
    public class Balance
    {
        public string currency { get; set; }
        public int balance { get; set; }
    }
}
