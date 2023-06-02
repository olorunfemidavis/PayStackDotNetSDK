using System;

namespace PayStackDotNetSDK.Models.Pages
{
    public class FetchPageModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public FetchPageData data { get; set; }
    }
    public class FetchPageData
    {
        public int integration { get; set; }
        public string domain { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string slug { get; set; }
        public object custom_fields { get; set; }
        public string type { get; set; }
        public object redirect_url { get; set; }
        public object success_message { get; set; }
        public bool collect_phone { get; set; }
        public bool active { get; set; }
        public bool published { get; set; }
        public bool migrate { get; set; }
        public object notification_email { get; set; }
        public object metadata { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
