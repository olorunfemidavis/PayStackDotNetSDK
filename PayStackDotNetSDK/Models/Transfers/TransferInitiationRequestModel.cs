using PayStackDotNetSDK.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Transfers
{
    public class TransferInitiationRequestModel
    {
        /// <summary>
        /// source(required) - Where should we transfer from? Only balance for now
        /// </summary>
        public string source { get; set; }
        /// <summary>
        /// amount - Amount to transfer in kobo
        /// </summary>
        public int amount { get; set; }
        /// <summary>
        /// currency - NGN
        /// </summary>
        public string currency { get; set; } = Constants.Currency.Naira;
        /// <summary>
        /// reason
        /// </summary>
        public string reason { get; set; } = null;
        /// <summary>
        /// recipient(required) - Code for transfer recipient
        /// </summary>
        public string recipient { get; set; }
        /// <summary>
        /// reference - If specified, the field should be a unique identifier(in lowercase) for the object. Only - , _ and alphanumeric characters allowed.
        /// </summary>
        public string reference { get; set; }
        
    }
}




