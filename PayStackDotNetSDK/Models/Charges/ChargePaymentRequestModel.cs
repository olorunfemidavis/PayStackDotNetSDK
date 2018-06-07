using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Charges
{
    public class ChargePaymentRequestModel
    {
        /// <summary>
        /// email (required) - Customer's email address
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// amount (required) - Amount in kobo
        /// </summary>
        public string amount { get; set; }
        public Metadata metadata { get; set; }
        public Card card { get; set; }
        /// <summary>
        ///Bank account to charge (don't send if charging an authorization code or card)
        /// </summary>
        public ChargeBank bank { get; set; }

        public string pin { get; set; }
        public string authorization_code { get; set; }

    }
    /// <summary>
    /// Bank account to charge (don't send if charging an authorization code or card)
    /// </summary>
    public class ChargeBank
    {
        /// <summary>
        /// bank.code (required) - A code for the bank (check banks for the banks supported). Only the ones for which paywithbank is true will work.
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// bank.account_number (required) - 10 digit nuban for the account to charge
        /// </summary>
        public string account_number { get; set; }
    }

    public class CustomField
    {
        public string value { get; set; }
        public string display_name { get; set; }
        public string variable_name { get; set; }
    }

    public class Metadata
    {
        public List<CustomField> custom_fields { get; set; }
    }

 
}
/*






bank - Bank account to charge (don't send if charging an authorization code or card)
bank.code (required) - A code for the bank (check banks for the banks supported). Only the ones for which paywithbank is true will work.
bank.account_number (required) - 10 digit nuban for the account to charge
authorization_code - An authorization code to charge (don't send if charging a card or bank account)
pin - 4-digit PIN (send with a non-reusable authorization code)
metadata - A JSON object*/
