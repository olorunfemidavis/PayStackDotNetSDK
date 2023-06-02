namespace PayStackDotNetSDK.Models.Charges
{
    public class TokenizePaymentRequestModel
    {
        public Card card { get; set; }
        public string email { get; set; }
    }
    /// <summary>
    /// card (required) - Card number
    /// </summary>
    public class Card
    {
        /// <summary>
        /// card.cvv (required) - Card security code
        /// </summary>
        public string cvv { get; set; }
        /// <summary>
        /// card.expiry_month (required) - Expiry month of card
        /// </summary>
        public int expiry_month { get; set; }
        /// <summary>
        /// card.expiry_year (required) - Expiry year of card
        /// </summary>
        public int expiry_year { get; set; }
        /// <summary>
        /// card.number (required) - Card to tokenize
        /// </summary>
        public string number { get; set; }
        public string type { get; set; }
    }
}
