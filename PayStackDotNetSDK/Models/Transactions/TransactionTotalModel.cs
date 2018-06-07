using System;
using System.Collections.Generic;
using System.Text;

namespace PayStackDotNetSDK.Models.Transactions
{
    public class TransactionTotalModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public TotalData data { get; set; }
    }

    public class TotalVolumeByCurrency
    {
        public string currency { get; set; }
        public int amount { get; set; }
    }

    public class PendingTransfersByCurrency
    {
        public string currency { get; set; }
        public int amount { get; set; }
    }

    public class TotalData
    {
        public int total_transactions { get; set; }
        public int unique_customers { get; set; }
        public int total_volume { get; set; }
        public List<TotalVolumeByCurrency> total_volume_by_currency { get; set; }
        public int pending_transfers { get; set; }
        public List<PendingTransfersByCurrency> pending_transfers_by_currency { get; set; }
    }
}
