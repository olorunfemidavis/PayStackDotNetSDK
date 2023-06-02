using System.Collections.Generic;

namespace PayStackDotNetSDK.Models.Invoices
{
    public class InvoiceTotalsResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public InvoiceTotalsData data { get; set; }
    }
    public class Pending
    {
        public string currency { get; set; }
        public int amount { get; set; }
    }

    public class Successful
    {
        public string currency { get; set; }
        public int amount { get; set; }
    }

    public class Total
    {
        public string currency { get; set; }
        public int amount { get; set; }
    }

    public class InvoiceTotalsData
    {
        public List<Pending> pending { get; set; }
        public List<Successful> successful { get; set; }
        public List<Total> total { get; set; }
    }

   
}
