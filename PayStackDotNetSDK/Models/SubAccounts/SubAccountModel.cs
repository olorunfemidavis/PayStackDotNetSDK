namespace PayStackDotNetSDK.Models.SubAccounts
{
    public class SubAccountModel
    {
        /// <summary>
        ///  (required) - Name of business for subaccount
        /// </summary>
        public string business_name { get; set; } = null;
        /// <summary>
        /// (required) - Code of Bank (see list of accepted names by calling List Banks
        /// </summary>
        public string settlement_bank { get; set; } = null;
        /// <summary>
        /// (required) - NUBAN Bank Account Number
        /// </summary>
        public string account_number { get; set; } = null;
        /// <summary>
        /// (required) - What is the default percentage charged when receiving on behalf of this subaccount?
        /// </summary>
        public float percentage_charge { get; set; }
        /// <summary>
        /// A contact email for the subaccount
        /// </summary>
        public string primary_contact_email { get; set; } = null;
        /// <summary>
        ///  A name for the contact person for this subaccount
        /// </summary>
        public string primary_contact_name { get; set; } = null;
        /// <summary>
        /// A phone number to call for this subaccount
        /// </summary>
        public string primary_contact_phone { get; set; } = null;
        /// <summary>
        /// Any of auto, weekly, monthly, manual. Auto means payout is T+1 and manual means payout to the subaccount should only be made when requested.
        /// </summary>
        public string settlement_schedule { get; set; } = "auto";

        public Metadata metadata { get; set; }
    }
}
