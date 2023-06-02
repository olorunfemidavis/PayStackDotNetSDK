using System;
using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.Invoices
{
    public class ViewInvoiceResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
  

    public class ViewInvoiceCustomer
    {
        public List<object> transactions { get; set; }
        public List<object> subscriptions { get; set; }
        public List<object> authorizations { get; set; }
        public object first_name { get; set; }
        public object last_name { get; set; }
        public string email { get; set; }
        public object phone { get; set; }
        public Metadata metadata { get; set; }
        public string domain { get; set; }
        public string customer_code { get; set; }
        public string risk_action { get; set; }
        public int id { get; set; }
        public int integration { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class Data
    {
        public List<object> transactions { get; set; }
        public string domain { get; set; }
        public string request_code { get; set; }
        public object description { get; set; }
        public List<LineItem> line_items { get; set; }
        public List<Tax> tax { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public DateTime due_date { get; set; }
        public string status { get; set; }
        public bool paid { get; set; }
        public object paid_at { get; set; }
        public Metadata metadata { get; set; }
        public bool has_invoice { get; set; }
        public object invoice_number { get; set; }
        public string offline_reference { get; set; }
        public object pdf_url { get; set; }
        public List<Notification> notifications { get; set; }
        public bool archived { get; set; }
        public string source { get; set; }
        public int id { get; set; }
        public int integration { get; set; }
        public ViewInvoiceCustomer customer { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int pending_amount { get; set; }
    }

}
