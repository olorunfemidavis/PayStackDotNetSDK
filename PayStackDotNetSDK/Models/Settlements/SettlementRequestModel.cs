using System;

namespace PayStackDotNetSDK.Models.Settlements
{
    public class SettlementRequestModel
    {
        /// <summary>
        /// Lower bound of date range. Leave undefined to export settlement from day one.
        /// </summary>
        public DateTime from { get; set; }
        /// <summary>
        /// Upper bound of date range. Leave undefined to export settlements till date.
        /// </summary>
        public DateTime to { get; set; }
        /// <summary>
        /// subaccount - Provide a subaccount code to export only settlements for that subaccount. Set to none to export only transactions for the account.
        /// </summary>
        public string subaccount { get; set; }
    }
}