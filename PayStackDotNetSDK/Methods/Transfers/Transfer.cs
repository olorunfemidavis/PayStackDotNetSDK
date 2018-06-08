using Newtonsoft.Json;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Interfaces;
using PayStackDotNetSDK.Models;
using PayStackDotNetSDK.Models.Transfers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PayStackDotNetSDK.Methods.Transfers
{
    public class PaystackTransfer : ITransfers
    {
        string _secretKey;
        public PaystackTransfer(string secretKey)
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
                return "transfer";
            return $"transfer/{url}";
        }
        static string GetUrl()
        {
            return "transfer";
        }
        /// <summary>
        /// POST Initiate Transfer
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="recipient_code"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public async Task<TransferInitiationResponseModel> InitiateTransfer(int amount, string recipient_code, string source = "balance")
        {
            string url = GetUrl();
            var values = new Dictionary<string, string>
        {
           { "recipient", recipient_code },
           { "amount", $"{amount}" },
            { "source", source }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<TransferInitiationResponseModel>(content);
        }
        /// <summary>
        /// POST Initiate Transfer
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="recipient_code"></param>
        /// <param name="source"></param>
        /// <param name="currency"></param>
        /// <param name="reason"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public async Task<TransferInitiationResponseModel> InitiateTransfer(int amount, string recipient_code, string source = "balance", string currency = "NGN", string reason = null, string reference = null)
        {
            string url = GetUrl();
            var values = new Dictionary<string, string>
        {
           { "recipient", recipient_code },
           { "amount", $"{amount}" },
            { "source", source },
            { "currency", $"{currency}" },
            { "reason", reason },
            { "reference", reference.ToLower() }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<TransferInitiationResponseModel>(content);
        }
        /// <summary>
        /// GET List Transfers
        /// </summary>
        /// <returns></returns>
        public async Task<TransferListResponseModel> ListTransfers()
        {
            var url = GetUrl();
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<TransferListResponseModel>(getResult);
        }
        /// <summary>
        /// GET List Transfers with params
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<TransferListResponseModel> ListTransfers(GeneralListRequestModel requestModel)
        {
            var url = GetUrl();
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<TransferListResponseModel>(getResult);

        }

        public async Task<TransferModel> FetchTransfer(string transfer_code)
        {
            var client = HttpConnection.CreateClient(this._secretKey);
            var response = await client.GetAsync($"transfer/{transfer_code}");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TransferModel>(json);
        }

        public async Task<FinalizeTransferResponseModel> FinalizeTransfer(string transfer_code, string otp)
        {
            string url = GetUrl("finalize_transfer");
            var values = new Dictionary<string, string>
        {
           { "transfer_code", transfer_code },
           { "otp", $"{otp}" }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<FinalizeTransferResponseModel>(content);
        }
        public async Task<GeneralResponseModel> InitiateBulkTransfer(List<TransferInitiationRequestModel> transfers, string currency = Constants.Currency.Naira, string source = Constants.Transfer.Source.Balance)
        {
            string url = GetUrl("bulk");
            var values = new Dictionary<string, string>
        {
           { "currency", currency },
           { "transfers", JsonConvert.SerializeObject(transfers) },
            { "source", source },
        };
            var content = await BaseClient.PutEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<GeneralResponseModel>(content);
        }
    }
}
