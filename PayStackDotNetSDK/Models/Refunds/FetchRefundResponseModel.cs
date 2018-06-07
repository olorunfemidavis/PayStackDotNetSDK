using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Refunds
{
    public class FetchRefundResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public RefundData data { get; set; }
    }
    public class RefundData
    {
        public int integration { get; set; }
        public int transaction { get; set; }
        public int dispute { get; set; }
        public object settlement { get; set; }
        public string domain { get; set; }
        public int amount { get; set; }
        public object deducted_amount { get; set; }
        public bool fully_deducted { get; set; }
        public string currency { get; set; }
        public string channel { get; set; }
        public string status { get; set; }
        public string refunded_by { get; set; }
        public DateTime refunded_at { get; set; }
        public DateTime expected_at { get; set; }
        public string customer_note { get; set; }
        public string merchant_note { get; set; }
        public object bank_reference { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

   
}
