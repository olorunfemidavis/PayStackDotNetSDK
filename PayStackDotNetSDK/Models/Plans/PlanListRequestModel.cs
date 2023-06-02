using System;

namespace PayStackDotNetSDK.Models.Plans
{
    public class PlanListRequestModel
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
        /// Filter list by plans with specified interval
        /// </summary>
        public string interval { get; set; } = null;
        /// <summary>
        /// Filter list by plans with specified amount (in kobo)
        /// </summary>
        public Int32 amount { get; set; } 
    }
}
