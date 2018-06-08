using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PayStackDotNetSDK.Interfaces;
using Newtonsoft.Json;
using PayStackDotNetSDK.Models.TransferRecipients;
using PayStackDotNetSDK.Helpers;
using System.Web;

namespace PayStackDotNetSDK.Methods.TransferRecipients
{
    public class PaystackTransferRecipient : ITransferRecipients
    {
        string _secretKey;
        public PaystackTransferRecipient(string secretKey)
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
                return "transferrecipient";
            return $"transferrecipient/{url}";
        }
        static string GetUrl()
        {
            return "transferrecipient";
        }
        /// <summary>
        /// POST Create Transfer Recipient with default values
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="account_number"></param>
        /// <param name="bank_code"></param>
        /// <returns></returns>
        public async Task<TransferRecipientModel> CreateTransferRecipient(string type, string name, string account_number,
           string bank_code)
        {
            string url = GetUrl();
            var values = new Dictionary<string, string>
        {
           { "type", type },
           { "name", $"{name}" },
           { "bank_code", $"{bank_code}" },
           { "account_number", $"{account_number}" }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<TransferRecipientModel>(content);
        }
        /// <summary>
        /// POST Create Transfer Recipient with more details
        /// </summary>
        /// <param name="recipientRequestModel"></param>
        /// <returns></returns>
        public async Task<TransferRecipientModel> CreateTransferRecipient(TransferRecipientRequestModel recipientRequestModel)
        {
            string url = GetUrl();
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(recipientRequestModel), this._secretKey);
            return JsonConvert.DeserializeObject<TransferRecipientModel>(content);
        }
        /// <summary>
        /// GET List Transfer Recipients
        /// </summary>
        /// <returns></returns>
        public async Task<TransferRecipientListModel> ListTransferRecipients()
        {
            var url = GetUrl();
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<TransferRecipientListModel>(getResult);
        }
        /// <summary>
        /// GET List Transfer Recipients with filters
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<TransferRecipientListModel> ListTransferRecipients(TransferRecipientListRequestModel requestModel)
        {
            var url = GetUrl("?");
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<TransferRecipientListModel>(getResult);
        }

    }
}
