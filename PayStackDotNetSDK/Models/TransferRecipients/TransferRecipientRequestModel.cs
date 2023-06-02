using PayStackDotNetSDK.Helpers;

namespace PayStackDotNetSDK.Models.TransferRecipients
{
    /// <summary>
    /// Creates a new recipient. An duplicate account number will lead to the retrieval of the existing record.
    /// </summary>
    public class TransferRecipientRequestModel
    {
        /// <summary>
        /// type (required) - Recipient Type (Only nuban at this time)
        /// </summary>
        public string type { get; set; } = Constants.BankType.Nuban;
        /// <summary>
        /// name (required) - A name for the recipient
        /// </summary>
        public string name { get; set; }
        public string account_number { get; set; }
        /// <summary>
        /// bank_code (required) - Required if type is nuban
        /// </summary>
        public string bank_code { get; set; }
        /// <summary>
        /// currency - Currency for the account receiving the transfer.
        /// </summary>
        public string currency { get; set; }
        public string description { get; set; }
        /// <summary>
        /// metadata - Store additional information about your recipient.
        /// </summary>
        public Metadata metadata { get; set; }
    }
}