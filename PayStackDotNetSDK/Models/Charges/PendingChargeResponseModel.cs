using System;
using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.Charges
{
    public class PendingChargeResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public PendingChargeData data { get; set; }
    }
    public class PendingChargeMetadata
    {
        public string referrer { get; set; }
    }

    public class History
    {
        public string type { get; set; }
        public string message { get; set; }
        public int time { get; set; }
    }

    public class Log
    {
        public int time_spent { get; set; }
        public int attempts { get; set; }
        public object authentication { get; set; }
        public int errors { get; set; }
        public bool success { get; set; }
        public bool mobile { get; set; }
        public List<object> input { get; set; }
        public object channel { get; set; }
        public List<History> history { get; set; }
    }

    public class Authorization
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
    }

    public class PendingChargeCustomer
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

    public class PendingChargeData
    {
        public int amount { get; set; }
        public string currency { get; set; }
        public DateTime transaction_date { get; set; }
        public string status { get; set; }
        public string reference { get; set; }
        public string domain { get; set; }
        public PendingChargeMetadata metadata { get; set; }
        public string gateway_response { get; set; }
        public object message { get; set; }
        public string channel { get; set; }
        public string ip_address { get; set; }
        public Log log { get; set; }
        public int fees { get; set; }
        public Authorization authorization { get; set; }
        public PendingChargeCustomer customer { get; set; }
        public object plan { get; set; }
    }

   
}
