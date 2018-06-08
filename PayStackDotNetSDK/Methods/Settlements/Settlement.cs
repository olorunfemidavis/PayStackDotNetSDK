using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Models.Settlements;
using System.Web;
using PayStackDotNetSDK.Interfaces;

namespace PayStackDotNetSDK.Methods.Settlements
{
    public class PaystackSettlement : ISettlements
    {
        private string _secretKey;
        public PaystackSettlement(string secretKey)
        {
            this._secretKey = secretKey;
        }
        static String GetContent(Dictionary<string, string> values)
        {
            return JsonConvert.SerializeObject(values);
        }
        static string GetUrl(String url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return "settlement";
            return $"settlement/{url}";
        }
        static string GetUrl()
        {
            return "settlement";
        }
        public async Task<SettlementResponseModel> FetchSettlement()
        {
            var url = GetUrl();
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<SettlementResponseModel>(getResult);
        }
        /// <summary>
        /// GET Fetch Settlements
        /// Settlements made to your bank accounts and the bank accounts for your subaccounts
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<SettlementResponseModel> FetchSettlement(SettlementRequestModel requestModel)
        {
            var url = GetUrl("?");
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<SettlementResponseModel>(getResult);
        }

    }
}
