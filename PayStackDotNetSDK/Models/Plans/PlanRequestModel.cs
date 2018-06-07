using PayStackDotNetSDK.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Plans
{
    public class PlanRequestModel
    {
        /// <summary>
        /// (required) - Name of plan
        /// </summary>
        public string name { get; set; } = null;
        /// <summary>
        /// Short description of plan
        /// </summary>
        public string description { get; set; } = null;
        /// <summary>
        /// (required) - Amount to be charged in kobo
        /// </summary>
        public int amount { get; set; }
        /// <summary>
        /// (required) - Interval in words. Valid intervals are hourly, daily, weekly, monthly, annually.
        /// </summary>
        public string interval { get; set; } = null;
        /// <summary>
        /// Set to false if you don't want invoices to be sent to your customers
        /// </summary>
        public bool send_invoices { get; set; } = false;
        /// <summary>
        /// Set to false if you don't want text messages to be sent to your customers
        /// </summary>
        public bool send_sms { get; set; } = false;
        /// <summary>
        /// Currency in which amount is set
        /// </summary>
        public string currency { get; set; } = Constants.Currency.Naira;
        /// <summary>
        /// Number of invoices to raise during subscription to this plan. Can be overridden by specifying an invoice_limit while subscribing.
        /// </summary>
        public int invoice_limit { get; set; } = 0;
       
    }
}
