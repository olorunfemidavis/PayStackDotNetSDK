namespace PayStackDotNetSDK.Models.Customers
{
    public class CustomersModel
    {
        /// <summary>
        /// (required) - Customer's email address
        /// </summary>
        public string email { get; set; } = null;
        /// <summary>
        /// Customer's first name
        /// </summary>
        public string first_name { get; set; } = null;
        /// <summary>
        /// Customer's last name
        /// </summary>
        public string last_name { get; set; } = null;
        /// <summary>
        /// Customer's phone number
        /// </summary>
        public string phone { get; set; } = null;
        /// <summary>
        /// A set of key/value pairs that you can attach to the customer. It can be used to store additional information in a structured format.
        /// </summary>
        public Metadata metadata { get; set; } = null;

    }
}
