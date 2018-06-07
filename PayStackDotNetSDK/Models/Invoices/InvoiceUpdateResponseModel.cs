using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Invoices
{
    public class InvoiceUpdateResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public InvoiceUpdateData data { get; set; }
    }

    public class InvoiceUpdateData
    {
        public int id { get; set; }
        public string domain { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public DateTime due_date { get; set; }
        public bool has_invoice { get; set; }
        public object invoice_number { get; set; }
        public object description { get; set; }
        public object pdf_url { get; set; }
        public List<object> line_items { get; set; }
        public List<object> tax { get; set; }
        public string request_code { get; set; }
        public string status { get; set; }
        public bool paid { get; set; }
        public object paid_at { get; set; }
        public object metadata { get; set; }
        public List<Notification> notifications { get; set; }
        public string offline_reference { get; set; }
        public Customer customer { get; set; }
        public DateTime created_at { get; set; }
    }

   
}
