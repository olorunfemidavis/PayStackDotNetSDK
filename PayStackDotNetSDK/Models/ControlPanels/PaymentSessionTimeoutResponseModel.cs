using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.ControlPanels
{
    public class PaymentSessionTimeoutResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public int payment_session_timeout { get; set; }
    }
}
