namespace PayStackDotNetSDK.Models.Verifications
{
    public class ResolveCardBinResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public CardData data { get; set; }
    }
    public class CardData
    {
        public string bin { get; set; }
        public string brand { get; set; }
        public string sub_brand { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string card_type { get; set; }
        public string bank { get; set; }
        public int linked_bank_id { get; set; }
    }

}
