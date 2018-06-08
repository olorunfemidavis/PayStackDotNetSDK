using Newtonsoft.Json;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Interfaces;
using PayStackDotNetSDK.Models.SubAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PayStackDotNetSDK.Methods.Subaccounts
{
    public class PaystackSubAccount : ISubAccounts
    {

        private string _secretKey;
        public PaystackSubAccount(string secretKey)
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
                return "subaccount";
            return $"subaccount/{url}";
        }
        static string GetUrl()
        {
            return "subaccount";
        }

        public async Task<SubAccountResponseModel> CreateSubAccount(string business_name, string settlement_bank_code, string account_number,
                                float percentage_charge)
        {
            string url = GetUrl();
            var values = new Dictionary<string, string>
        {
           { "business_name", business_name },
           { "settlement_bank", $"{settlement_bank_code}" },
           { "account_number", $"{account_number}" },
           { "percentage_charge", $"{percentage_charge}" },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<SubAccountResponseModel>(content);
        }
        /// <summary>
        /// Receive payments for the created subaccount by providing their code when doing a transaction. 
        /// </summary>
        /// <param name="subAccount"></param>
        /// <returns></returns>
        public async Task<SubAccountResponseModel> CreateSubAccount(SubAccountModel subAccount)
        {
            string url = GetUrl();
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(subAccount), this._secretKey);
            return JsonConvert.DeserializeObject<SubAccountResponseModel>(content);
        }

        public async Task<SubAccountListModel> ListSubAccounts()
        {
            var url = GetUrl();
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<SubAccountListModel>(getResult);
        }
        public async Task<SubAccountListModel> ListSubAccounts(ListSubAccountsRequestModel requestModel)
        {
            var url = GetUrl();
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<SubAccountListModel>(getResult);
        }
        /// <summary>
        /// Fetch Subaccount
        /// </summary>
        /// <param name="id_or_slug"></param>
        /// <returns></returns>
        public async Task<SubAccountResponseModel> FetchSubAccount(string id_or_slug)
        {
            var url = GetUrl(id_or_slug);
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<SubAccountResponseModel>(getResult);
        }
        public async Task<SubAccountResponseModel> UpdateSubAccount(string id_or_slug, string business_name, string settlement_bank_code, string account_number,
                               float percentage_charge)
        {
            string url = GetUrl(id_or_slug);
            var values = new Dictionary<string, string>
        {
           { "business_name", business_name },
           { "settlement_bank", $"{settlement_bank_code}" },
           { "account_number", $"{account_number}" },
           { "percentage_charge", $"{percentage_charge}" },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<SubAccountResponseModel>(content);
        }
        public async Task<SubAccountResponseModel> CreateSubAccount(string id_or_slug, SubAccountModel subAccount)
        {
            string url = GetUrl(id_or_slug);
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(subAccount), this._secretKey);
            return JsonConvert.DeserializeObject<SubAccountResponseModel>(content);
        }

    }
}
