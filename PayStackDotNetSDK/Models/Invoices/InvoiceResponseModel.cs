using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Invoices
{
    public class InvoiceResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public InvoiceResponseData data { get; set; }
    }
    public class InvoiceResponseData
    {
        public int id { get; set; }
        public string domain { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public DateTime due_date { get; set; }
        public bool has_invoice { get; set; }
        public object invoice_number { get; set; }
        public object description { get; set; }
        public List<LineItem> line_items { get; set; }
        public List<Tax> tax { get; set; }
        public string request_code { get; set; }
        public string status { get; set; }
        public bool paid { get; set; }
        public InvoiceListMeta metadata { get; set; }
        public List<Notification> notifications { get; set; }
        public string offline_reference { get; set; }
        public int customer { get; set; }
        public DateTime created_at { get; set; }
    }
}
