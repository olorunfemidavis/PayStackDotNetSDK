using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Transactions
{
    public class ExportRequestModel
    {
        /// <summary>
        /// Set to true to export only settled transactions. false for pending transactions. Leave undefined to export all transactions
        /// </summary>
        public bool settled { get; set; }
        /// <summary>
        /// Specify a payment page's id to export only transactions conducted on said page
        /// </summary>
        public Int32 payment_page { get; set; }
        /// <summary>
        /// Specify customer id.
        /// </summary>
        public string customer { get; set; }
        /// <summary>
        /// Currency in which you are charging the customer in.
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// An ID for the settlement whose transactions we should export
        /// </summary>
        public string settlement { get; set; }
        /// <summary>
        /// Amount for transactions to export
        /// </summary>
        public string amount { get; set; }
        /// <summary>
        /// Status for transactions to export ('failed', 'success', 'abandoned')
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Lower bound of date range. Leave undefined to export transactions from day one.
        /// </summary>
        public DateTime from { get; set; }
        /// <summary>
        /// Upper bound of date range. Leave undefined to export transactions till date.
        /// </summary>
        public DateTime to { get; set; }


    }
}
