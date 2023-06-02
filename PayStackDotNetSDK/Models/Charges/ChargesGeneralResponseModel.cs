namespace PayStackDotNetSDK.Models.Charges
{
    public class ChargesGeneralResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public SubmitPinData data { get; set; }
    }
    public class SubmitPinData
    {
        public string reference { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }

   
}
