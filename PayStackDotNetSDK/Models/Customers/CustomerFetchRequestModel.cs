using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Customers
{
    public class CustomerFetchRequestModel
    {
        /// <summary>
        /// By default, fetching a customer returns all their transactions. Set this to true to disable this behaviour.
        /// </summary>
        public bool exclude_transactions { get; set; }
    }
}
