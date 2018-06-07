using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Customers
{
    public class CustomersListRequestModel
    {
        /// <summary>
        /// Specify how many records you want to retrieve per page
        /// </summary>
        public Int32 perPage { get; set; }
        /// <summary>
        /// Specify exactly what page you want to retrieve
        /// </summary>
        public Int32 page { get; set; }
     
    }
}
