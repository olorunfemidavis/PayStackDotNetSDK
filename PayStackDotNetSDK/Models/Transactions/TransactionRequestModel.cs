using PayStackDotNetSDK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayStackDotNetSDK.Models.Transactions
{
    public class TransactionRequestModel
    {
        /// <summary>
        /// (required) - Customer's email address
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// (required) - Amount in kobo
        /// </summary>
        public int amount { get; set; }
        /// <summary>
        /// The code for the subaccount that owns the payment.
        /// </summary>
        public string subaccount { get; set; } = null;
        /// <summary>
        /// A flat fee to charge the subaccount for this transaction, in kobo. This overrides the split percentage set when the subaccount was created. Ideally, you will need to use this if you are splitting in flat rates (since subaccount creation only allows for percentage split).
        /// </summary>
        public Int32 transaction_charge { get; set; } = 0;
        /// <summary>
        /// Who bears Paystack charges? account or subaccount (defaults to account).
        /// </summary>
        public string bearer { get; set; } = "account";
        /// <summary>
        /// Overrides the callback URL set on Paystack dashboard.
        /// </summary>
        public string callback_url { get; set; } = null;
        /// <summary>
        ///  Generate a reference or leave this param blank for Paystack to generate one for you
        /// </summary>
        public string reference { get; set; } = null;
        /// <summary>
        /// If transaction is to create a subscription to a predefined plan, provide plan code here. This would invalidate the value provided in amount
        /// </summary>
        public string plan { get; set; } = null;
        /// <summary>
        /// Number of times to charge customer during subscription to plan
        /// </summary>
        public Int32 invoice_limit { get; set; } = 0;
        /// <summary>
        /// Send us 'card' or 'bank' or 'card','bank' as an array to specify what options to show the user paying
        /// </summary>
        public string[] channels { get; set; }
        /// <summary>
        /// Stringified JSON object. Add a custom_fields attribute which has an array of objects if you would like the fields to be added to your transaction when displayed on the dashboard.
        /// </summary>
        public Metadata metadata { get; set; } = null;
        public string currency { get; set; } = Constants.Currency.Naira;
        public string firstName { get; set; } = null;
        public string lastName { get; set; } = null;
        public bool makeReferenceUnique { get; set; } = false;

    }
  

}
