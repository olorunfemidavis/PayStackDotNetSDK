using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayStackDotNetSDK.Interfaces;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Models.Refunds;
using System.Web;

namespace PayStackDotNetSDK.Methods.Refunds
{
    public class PaystackRefund : IRefunds
    {
        private string _secretKey;
        public PaystackRefund(string secretKey)
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
                return "refund";
            return $"refund/{url}";
        }
        static string GetUrl()
        {
            return "refund";
        }
        /// <summary>
        /// POST Create Refund
        /// This creates a refund which is then processed by the Paystack team
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<CreateRefundResponseModel> CreateRefund(string transaction)
        {
            string url = GetUrl();
            var values = new Dictionary<string, string>
        {
           { "transaction", transaction }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<CreateRefundResponseModel>(content);
        }
        /// <summary>
        /// POST Create Refund
        /// This creates a refund which is then processed by the Paystack team
        /// </summary>
        /// <param name="transactionRequest"></param>
        /// <returns></returns>
        public async Task<CreateRefundResponseModel> CreateRefund(CreateRefundRequestModel transactionRequest)
        {
            string url = GetUrl();
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(transactionRequest), this._secretKey);
            return JsonConvert.DeserializeObject<CreateRefundResponseModel>(content);
        }
        /// <summary>
        /// GET List Refunds
        /// </summary>
        /// <returns></returns>
        public async Task<ListRefundResponseModel> ListRefund()
        {
            var url = GetUrl();
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<ListRefundResponseModel>(getResult);
        }
        /// <summary>
        /// GET List Refunds
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<ListRefundResponseModel> ListRefund(ListRefundRequestModel requestModel)
        {
            var url = GetUrl("?");
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<ListRefundResponseModel>(getResult);
        }
        /// <summary>
        /// GET Fetch Refund
        /// id - ID of the transaction to be refunded
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FetchRefundResponseModel> FetchRefund(string id)
        {
            var url = GetUrl(id);
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<FetchRefundResponseModel>(getResult);
        }
    }
}
