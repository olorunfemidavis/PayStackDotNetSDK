using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Transactions
{
    public class TransactionListRequestModel
    {
        /// <summary>
        /// Specify how many records you want to retrieve per page
        /// </summary>
        public Int32 perPage { get; set; }
        /// <summary>
        /// Specify exactly what page you want to retrieve
        /// </summary>
        public Int32 page { get; set; }
        /// <summary>
        /// Specify an ID for the customer whose transactions you want to retrieve
        /// </summary>
        public Int32 customer { get; set; }
        /// <summary>
        /// Filter transactions by status ('failed', 'success', 'abandoned')
        /// </summary>
        public string status { get; set; } = null;
        /// <summary>
        /// A timestamp at which to stop listing transaction e.g. 2016-09-24T00:00:05.000Z, 2016-09-21
        /// </summary>
        public DateTime from { get; set; }
        /// <summary>
        /// A timestamp at which to stop listing transaction e.g. 2016-09-24T00:00:05.000Z, 2016-09-21
        /// </summary>
        public DateTime to { get; set; } 
        /// <summary>
        /// Filter transactions by amount. Specify the amount in kobo.
        /// </summary>
        public Int32 amount { get; set; } 

    }
}


