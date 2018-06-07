using Newtonsoft.Json;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Interfaces;
using PayStackDotNetSDK.Models;
using PayStackDotNetSDK.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PayStackDotNetSDK.Methods.Transactions
{
    public class Transaction : ITransactions
    {
        private string _secretKey;
        public Transaction(string secretKey)
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
                return "transaction";
            return $"transaction/{url}";
        }
        static string GetUrl()
        {
            return "transaction";
        }

        /// <summary>
        /// Initialize Transaction
        /// </summary>
        /// <param name="email"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<PaymentInitalizationResponseModel> InitializeTransaction(string email, int amount)
        {
            string url = GetUrl("initialize");
            var values = new Dictionary<string, string>
        {
           { "email", email },
           { "amount", $"{amount}" },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<PaymentInitalizationResponseModel>(content);
        }

        public async Task<PaymentInitalizationResponseModel> InitializeTransaction(TransactionRequestModel transactionRequest)
        {
            string url = GetUrl("initialize");
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(transactionRequest), this._secretKey);
            return JsonConvert.DeserializeObject<PaymentInitalizationResponseModel>(content);
        }

        public async Task<TransactionResponseModel> VerifyTransaction(string reference)
        {
            var url = GetUrl($"verify/{reference}");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<TransactionResponseModel>(getResult);
        }


        public async Task<TransactionListResponseModel> ListTransactions()
        {
            var url = GetUrl();
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<TransactionListResponseModel>(getResult);
        }
        public async Task<TransactionListResponseModel> ListTransactions(TransactionListRequestModel requestModel)
        {
            var url = GetUrl();
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<TransactionListResponseModel>(getResult);
        }

        public async Task<TransactionResponseModel> FetchTransaction(int id)
        {
            var url = GetUrl($"{id}");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<TransactionResponseModel>(getResult);
        }

        public async Task<TransactionResponseModel> ChargeAuthorization(string authorization_code, string email, int amount)
        {
            string url = GetUrl("charge_authorization");
            var values = new Dictionary<string, string>
        {
           { "authorization_code", authorization_code },
           { "amount", $"{amount}" },
            { "email", email },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<TransactionResponseModel>(content);
        }
        public async Task<TransactionResponseModel> ChargeAuthorization(TransactionRequestModel transactionRequest)
        {
            string url = GetUrl("charge_authorization");
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(transactionRequest), this._secretKey);
            return JsonConvert.DeserializeObject<TransactionResponseModel>(content);
        }


        /// <summary>
        /// View Transaction Timeline
        /// Provide id_or_reference
        /// </summary>
        /// <param name="referenceOrID"></param> 
        /// <returns></returns>
        public async Task<TransactionResponseModel> TransactionTimeline(string referenceOrID)
        {
            var url = GetUrl($"timeline/{referenceOrID}");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<TransactionResponseModel>(getResult);
        }

        /// <summary>
        /// Total amount received on your account
        /// </summary>
        /// <returns></returns>
        public async Task<TransactionTotalModel> TransactionTotals()
        {
            var url = GetUrl("totals");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<TransactionTotalModel>(getResult);
        }
        public async Task<TransactionTotalModel> TransactionTotals(TransactionTotalsRequestModel requestModel)
        {
            var url = GetUrl("totals");
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<TransactionTotalModel>(getResult);
        }

        public async Task<ExportResponseModel> ExportTransactions()
        {
            var url = GetUrl("export");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<ExportResponseModel>(getResult);
        }
        public async Task<ExportResponseModel> ExportTransactions(ExportRequestModel exportRequest)
        {
            var url = GetUrl("export");
            var properties = from p in exportRequest.GetType().GetProperties()
                             where p.GetValue(exportRequest, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(exportRequest, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<ExportResponseModel>(getResult);
        }
        public async Task<RequestReAuthorizationResponseModel> RequestReAuthorization(string authorization_code, string email, int amount)
        {
            string url = GetUrl("request_reauthorization");
            var values = new Dictionary<string, string>
        {
           { "authorization_code", authorization_code },
           { "amount", $"{amount}" },
            { "email", email },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<RequestReAuthorizationResponseModel>(content);
        }
        public async Task<RequestReAuthorizationResponseModel> RequestReAuthorization(RequestReAuthorizationRequestModel requestModel)
        {
            string url = GetUrl("request_reauthorization");
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(requestModel), this._secretKey);
            return JsonConvert.DeserializeObject<RequestReAuthorizationResponseModel>(content);
        }

        public async Task<TransactionResponseModel> CheckAuthorization(string authorization_code, string email, int amount)
        {
            string url = GetUrl("check_authorization");
            var values = new Dictionary<string, string>
        {
           { "authorization_code", authorization_code },
           { "amount", $"{amount}" },
            { "email", email },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<TransactionResponseModel>(content);
        }
        public async Task<TransactionResponseModel> CheckAuthorization(string authorization_code, string email, int amount, string currency)
        {
            string url = GetUrl("check_authorization");
            var values = new Dictionary<string, string>
        {
           { "authorization_code", authorization_code },
           { "amount", $"{amount}" },
            { "email", email },
            { "currency", currency },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<TransactionResponseModel>(content);
        }

    }

}
