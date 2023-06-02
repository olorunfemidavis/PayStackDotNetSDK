using PayStackDotNetSDK.Helpers;
using System;
using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.Transactions
{
    /// <summary>
    /// We do not activate authorizations for recurring billing until the first time we are able to bill that card successfully. Reauthorizing with the issuing bank may ensure a successful transaction.
    /// </summary>
    public class RequestReAuthorizationRequestModel
    {
        /// <summary>
        /// Unique transaction reference. Only - , . = and alphanumeric characters allowed. System will generate one if none is provided.
        /// </summary>
        public string reference { get; set; }
        /// <summary>
        /// (required) - Valid authorization code to charge
        /// </summary>
        public string authorization_code { get; set; }
        /// <summary>
        /// Amount in kobo
        /// </summary>
        public Int32 amount { get; set; }
        /// <summary>
        /// Currency in which amount should be charged
        /// </summary>
        public string currency { get; set; } = Constants.Currency.Naira;
        /// <summary>
        /// (required) - Customer's email address
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// Add a custom_fields attribute which has an array of objects if you would like the fields to be added to your transaction when displayed on the dashboard.
        /// </summary>
        public RequestReAuthorizationMetadata metadata { get; set; } = null;

    }
    public class RequestReAuthorizationCustomField
    {
        public string display_name { get; set; } = null;
        public string variable_name { get; set; } = null;
        public string value { get; set; } = null;
    }

    public class RequestReAuthorizationMetadata
    {
        public List<RequestReAuthorizationCustomField> custom_fields { get; set; } = null;
    }
}
