using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Transactions
{
    public class TransactionTotalsRequestModel
    {
        /// <summary>
        /// from - Lower bound of date range.Leave undefined to show totals from day one.
        /// </summary>
        public DateTime from { get; set; }
        /// <summary>
        /// to - Upper bound of date range.Leave undefined to show totals till date.
        /// </summary>
        public DateTime to { get; set; }
    }
}
