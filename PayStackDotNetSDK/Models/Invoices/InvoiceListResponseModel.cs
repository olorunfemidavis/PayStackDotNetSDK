using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Invoices
{
    public class InvoiceListResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<InvoiceList> data { get; set; }
        public InvoiceListMeta meta { get; set; }
    }
    public class Notification
    {
        public DateTime sent_at { get; set; }
        public string channel { get; set; }
    }
    public class InvoiceListMeta
    {
        public int total { get; set; }
        public int skipped { get; set; }
        public int perPage { get; set; }
        public int page { get; set; }
        public int pageCount { get; set; }
    }
    public class Customer
    {
        public int id { get; set; }
        public object first_name { get; set; }
        public object last_name { get; set; }
        public string email { get; set; }
        public string customer_code { get; set; }
        public object phone { get; set; }
        public object metadata { get; set; }
        public string risk_action { get; set; }
    }
    public class InvoiceList
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
        public List<LineItem> line_items { get; set; }
        public List<Tax> tax { get; set; }
        public string request_code { get; set; }
        public string status { get; set; }
        public bool paid { get; set; }
        public object paid_at { get; set; }
        public InvoiceListMeta metadata { get; set; }
        public List<Notification> notifications { get; set; }
        public string offline_reference { get; set; }
        public Customer customer { get; set; }
        public DateTime created_at { get; set; }
    }
}
