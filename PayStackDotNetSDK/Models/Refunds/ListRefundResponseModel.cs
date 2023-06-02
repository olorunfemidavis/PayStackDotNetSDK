using System;
using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.Refunds
{
    public class ListRefundResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Refund> data { get; set; }
        public Meta meta { get; set; }
    }
    public class Refund
    {
        public int integration { get; set; }
        public string domain { get; set; }
        public int transaction { get; set; }
        public int dispute { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string channel { get; set; }
        public object deducted_amount { get; set; }
        public int fully_deducted { get; set; }
        public string status { get; set; }
        public string refunded_by { get; set; }
        public DateTime refunded_at { get; set; }
        public DateTime expected_at { get; set; }
        public object settlement { get; set; }
        public string customer_note { get; set; }
        public string merchant_note { get; set; }
        public object bank_reference { get; set; }
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int is_deleted { get; set; }
    }

    public class Meta
    {
        public int total { get; set; }
        public int skipped { get; set; }
        public int perPage { get; set; }
        public int page { get; set; }
        public int pageCount { get; set; }
    }

}
