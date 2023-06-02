﻿using System;
using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.Plans
{
    public class PlanResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class FetchPlanModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public PlanResponseData data { get; set; }
    }

    public class PlanListModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<PlanResponseData> data { get; set; }
    }

    public class Data
    {
        public string name { get; set; }
        public int amount { get; set; }
        public string interval { get; set; }
        public int integration { get; set; }
        public string domain { get; set; }
        public string plan_code { get; set; }
        public bool send_invoices { get; set; }
        public bool send_sms { get; set; }
        public bool hosted_page { get; set; }
        public string currency { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class PlanResponseData
    {
        public List<object> subscriptions { get; set; }
        public int integration { get; set; }
        public string domain { get; set; }
        public string name { get; set; }
        public string plan_code { get; set; }
        public object description { get; set; }
        public int amount { get; set; }
        public string interval { get; set; }
        public bool send_invoices { get; set; }
        public bool send_sms { get; set; }
        public bool hosted_page { get; set; }
        public object hosted_page_url { get; set; }
        public object hosted_page_summary { get; set; }
        public string currency { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
