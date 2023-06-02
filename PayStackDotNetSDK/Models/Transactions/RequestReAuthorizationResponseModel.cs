namespace PayStackDotNetSDK.Models.Transactions
{
    public class RequestReAuthorizationResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public RequestAuthorizationData data { get; set; }
    }

    public class RequestAuthorizationData
    {
        public string reauthorization_url { get; set; }
        public string reference { get; set; }
    }
}
