using PayStackDotNetSDK.Helpers;

namespace PayStackDotNetSDK.Models.Refunds
{
    public class CreateRefundRequestModel
    {
        /// <summary>
        /// transaction(required) : Identifier for transaction to be refunded
        /// </summary>
        public string transaction { get; set; }
        /// <summary>
        /// amount(optional) : How much in kobo to be refunded to the customer.Amount is optional(defaults to original transaction amount) and cannot be more than the original transaction amount.
        /// </summary>
        public int amount { get; set; }
        /// <summary>
        /// currency: Three-letter ISO currency
        /// </summary>
        public string currency { get; set; } = Constants.Currency.Naira;
        /// <summary>
        /// customer_note(optional): customer reason
        /// </summary>
        public string customer_note { get; set; }
        /// <summary>
        /// merchant_note(optional) : merchant reason
        /// </summary>
        public string merchant_note { get; set; }
      
    }
}