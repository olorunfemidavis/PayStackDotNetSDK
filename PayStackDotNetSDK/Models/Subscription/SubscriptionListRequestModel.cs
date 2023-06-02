using System;

namespace PayStackDotNetSDK.Models.Subscription
{
    public class SubscriptionListRequestModel
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
        /// Filter by Customer ID
        /// </summary>
        public string customer { get; set; }
        /// <summary>
        /// Filter by Plan ID
        /// </summary>
        public string plan { get; set; }
    }
}
