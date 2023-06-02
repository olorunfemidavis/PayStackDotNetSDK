using System;
using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.Pages
{
    public class PageListModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<PageList> data { get; set; }
        public PageListMeta meta { get; set; }
    }
    public class PageList
    {
        public int integration { get; set; }
        public object plan { get; set; }
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

    public class PageListMeta
    {
        public int total { get; set; }
        public int skipped { get; set; }
        public int perPage { get; set; }
        public int page { get; set; }
        public int pageCount { get; set; }
    }
}
