using PayStackDotNetSDK.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Invoices
{
    public class InvoiceRequestModel
    {
        /// <summary>
        /// customer (required) - Customer ID or code
        /// Updating Invoice:  only works in draft mode
        /// </summary>
        public string customer { get; set; }
        /// <summary>
        /// due_date (required) - ISO 8601 representation of request due date
        /// </summary>
        public string due_date { get; set; }
        /// <summary>
        /// amount (required) - Invoice amount. Only useful if line items and tax values are ignored. endpoint will throw a friendly warning if neither is available. description
        /// </summary>
        public Int32 amount { get; set; }
        public string description { get; set; }
        /// <summary>
        /// line_items - Array of line items in the format [{"name":"item 1", "amount":2000}]
        /// </summary>
        public List<LineItem> line_items { get; set; }
        /// <summary>
        /// tax - Array of taxes to be charged in the format [{"name":"VAT", "amount":2000}]
        /// </summary>
        public List<Tax> tax { get; set; }
        /// <summary>
        /// currency - Defaults to Naira
        /// Updating Invoice:  only works in draft mode
        /// </summary>
        public string currency { get; set; } = Constants.Currency.Naira;
        /// <summary>
        /// send_notification - Indicates whether Paystack sends an email notification to customer. Defaults to true.
        /// </summary>
        public bool send_notification { get; set; } = true;
        /// <summary>
        /// draft - Indicate if request should be saved as draft. Defaults to false and overrides send_notification.
        /// </summary>
        public bool draft { get; set; }
        /// <summary>
        /// has_invoice - Set to true to create a draft invoice (adds an auto incrementing invoice number if none is provided) even if there are no line_items or tax passed.
        /// </summary>
        public bool has_invoice { get; set; }
        /// <summary>
        /// invoice_number - Numeric value of invoice. Invoice will start from 1 and auto increment from there. This field is to help override whatever value Paystack decides. Auto increment for subsequent invoices continue from this point.
        /// </summary>
        public Int32 invoice_number { get; set; }

        public Metadata Metadata { get; set; }

    }
    public class LineItem
    {
        public string name { get; set; }
        public int amount { get; set; }
    }

    public class Tax
    {
        public string name { get; set; }
        public int amount { get; set; }
    }
}