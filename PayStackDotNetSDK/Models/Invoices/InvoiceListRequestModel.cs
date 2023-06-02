namespace PayStackDotNetSDK.Models.Invoices
{
    public class InvoiceListRequestModel
    {
        /// <summary>
        /// customer - Specify an ID for the customer whose requests you want to retrieve
        /// </summary>
        public string customer { get; set; } = null;
        /// <summary>
        /// status - Filter requests by status ('failed', 'success', 'abandoned')
        /// </summary>
        public string status { get; set; } = null;
        /// <summary>
        /// currency - Filter requests sent in a particular currency.
        /// </summary>
        public string currency { get; set; } = null;
        /// <summary>
        /// paid - Filter requests that have been paid for
        /// </summary>
        public bool paid { get; set; }
        /// <summary>
        /// include_archive - Includes archived requests in the response
        /// </summary>
        public bool include_archive { get; set; }
        /// <summary>
        /// payment_request - Filter specific invoice by passing invoice code
        /// </summary>
        public string payment_request { get; set; } = null;
    }
}
