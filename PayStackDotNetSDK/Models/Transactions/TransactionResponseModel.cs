using System;
using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.Transactions
{
    public class TransactionResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Metadata
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
        public string brand { get; set; }
        public string account_name { get; set; }
        public string authorization_code { get; set; }
        public string card_type { get; set; }
        public string last4 { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public string bin { get; set; }
        public string bank { get; set; }
        public string channel { get; set; }
        public string signature { get; set; }
        public bool reusable { get; set; }
        public string country_code { get; set; }
    }

    public class Customer
    {
        public string phone { get; set; }
        public Metadata metadata { get; set; }
        public string risk_action { get; set; }
        public object international_format_phone { get; set; }
        
        public int id { get; set; }
        public string customer_code { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
    }

    public class Data
    {
        public long id { get; set; }
        public string receipt_number { get; set; }
        public object paid_at { get; set; }
        public DateTime created_at { get; set; }
        public Fees_Split fees_split { get; set; }
        public object plan { get; set; }
        //public Split split { get; set; }
        public object order_id { get; set; }
        public object paidAt { get; set; }
        public DateTime createdAt { get; set; }
        public int requested_amount { get; set; }
        public object pos_transaction_data { get; set; }
        public object source { get; set; }
        public object fees_breakdown { get; set; }
        //public Plan_Object plan_object { get; set; }
        public Subaccount subaccount { get; set; }
        
        public int amount { get; set; }
        public string currency { get; set; }
        public DateTime transaction_date { get; set; }
        public string status { get; set; }
        public string reference { get; set; }
        public string domain { get; set; }
        public Metadata metadata { get; set; }
        public string gateway_response { get; set; }
        public object message { get; set; }
        public string channel { get; set; }
        public string ip_address { get; set; }
        public Log log { get; set; }
        public object fees { get; set; }
        public Authorization authorization { get; set; }
        public Customer customer { get; set; }
    }
    
    public class Subaccount
    {
        public int id { get; set; }
        public string subaccount_code { get; set; }
        public string business_name { get; set; }
        public string description { get; set; }
        public object primary_contact_name { get; set; }
        public object primary_contact_email { get; set; }
        public object primary_contact_phone { get; set; }
        public object metadata { get; set; }
        public int percentage_charge { get; set; }
        public string settlement_bank { get; set; }
        public int bank_id { get; set; }
        public string account_number { get; set; }
        public string currency { get; set; }
        public bool active { get; set; }
    }
    
    public class Fees_Split
    {
        public int paystack { get; set; }
        public int integration { get; set; }
        public int subaccount { get; set; }
        public Fees_Split_Params _params { get; set; }
    }

    public class Fees_Split_Params
    {
        public string bearer { get; set; }
        public string transaction_charge { get; set; }
        public string percentage_charge { get; set; }
    }
}
