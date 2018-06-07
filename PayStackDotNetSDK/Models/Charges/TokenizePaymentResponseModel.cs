using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Charges
{
    public class TokenizePaymentResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
    public class Customer
    {
        public int id { get; set; }
        public object first_name { get; set; }
        public object last_name { get; set; }
        public string email { get; set; }
        public string customer_code { get; set; }
        public object phone { get; set; }
        public Metadata metadata { get; set; }
        public string risk_action { get; set; }
    }

    public class Data
    {
        public string authorization_code { get; set; }
        public string bin { get; set; }
        public string last4 { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public string channel { get; set; }
        public string card_type { get; set; }
        public string bank { get; set; }
        public string country_code { get; set; }
        public string brand { get; set; }
        public bool reusable { get; set; }
        public string signature { get; set; }
        public Customer customer { get; set; }
    }

  
}
