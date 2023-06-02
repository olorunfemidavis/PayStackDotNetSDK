namespace PayStackDotNetSDK.Models.Transactions
{
    public class ExportResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public ExportData data { get; set; }
    }

    public class ExportData
    {
        public string path { get; set; }
    }
}
