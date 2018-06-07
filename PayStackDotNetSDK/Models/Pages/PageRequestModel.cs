using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Pages
{
    /// <summary>
    /// name (required) - Name of page
    ///description - Short description of page
    ///amount - Default amount you want to accept using this page. If none is set, customer is free to provide any amount of their choice. The latter scenario is useful for accepting donations
    ///slug - URL slug you would like to be associated with this page. Page will be accessible at https://paystack.com/pay/[slug]
    ///redirect_url - If you would like Paystack to redirect someplace upon successful payment, specify the URL here.
    ///send_invoices - Set to false if you don't want invoices to be sent to your customers
    ///custom_fields - If you would like to accept custom fields, specify them here. 

    /// </summary>
    public class PageRequestModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string amount { get; set; }
        public string slug { get; set; }
        public string redirect_url { get; set; }
        public string send_invoices { get; set; }
        public List<CustomField> custom_fields { get; set; } = null;
    }
}
