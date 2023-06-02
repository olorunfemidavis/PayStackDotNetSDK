using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayStackDotNetSDK.Interfaces;
using Newtonsoft.Json;
using PayStackDotNetSDK.Models.Charges;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Models.BulkCharges;
using PayStackDotNetSDK.Models;
using System.Web;

namespace PayStackDotNetSDK.Methods.BulkCharges
{
    public class PaystackBulkCharge : IBulkCharges
    {
        private string _secretKey;
        public PaystackBulkCharge(string secretKey)
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
                return "bulkcharge";
            return $"bulkcharge/{url}";
        }
        static string GetUrl()
        {
            return "bulkcharge";
        }
        /// <summary>
        /// POST Initiate Bulk Charge
        /// Send an array of objects with authorization codes and amount in kobo so we can process transactions as a batch.
        /// </summary>
        /// <param name="chargePayments"></param>
        /// <returns></returns>
        public async Task<InitiateBulkChargeResponseModel> InitiateBulkCharge(List<ChargePaymentRequestModel> chargePayments)
        {
            string url = GetUrl();
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(chargePayments), this._secretKey);
            return JsonConvert.DeserializeObject<InitiateBulkChargeResponseModel>(content);
        }

        public async Task<ListBulkChargeBatchesResponseModel> ListBulkChargeBatches()
        {
            var url = GetUrl();
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<ListBulkChargeBatchesResponseModel>(getResult);
        }
        /// <summary>
        /// GET List Bulk Charge Batches
        /// This lists all bulk charge batches created by the integration. Statuses can be active, paused, or complete.
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<ListBulkChargeBatchesResponseModel> ListBulkChargeBatches(GeneralListRequestModel requestModel)
        {
            var url = GetUrl("?");
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<ListBulkChargeBatchesResponseModel>(getResult);
        }
        /// <summary>
        /// GET Fetch Bulk Charge Batch
        /// This endpoint retrieves a specific batch code. It also returns useful information on its progress by way of the total_charges and pending_charges attributes.
        /// </summary>
        /// <param name="id_or_code"></param>
        /// <returns></returns>
        public async Task<FetchBulkChargeBatchResponseModel> FetchBulkChargeBatch(string id_or_code)
        {
            var url = GetUrl(id_or_code);
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<FetchBulkChargeBatchResponseModel>(getResult);
        }
        /// <summary>
        ///  GET Fetch Charges in a Batch
        /// This endpoint retrieves the charges associated with a specified batch code. Pagination parameters are available. You can also filter by status. Charge statuses can be pending, success or failed.
        /// </summary>
        /// <param name="id_or_code"></param>
        /// <returns></returns>
        public async Task<FetchChargesInBatchResponseModel> FetchChargesInBatch(string id_or_code)
        {
            var url = GetUrl($"{id_or_code}/charges");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<FetchChargesInBatchResponseModel>(getResult);
        }
        /// <summary>
        /// GET Fetch Charges in a Batch
        /// This endpoint retrieves the charges associated with a specified batch code. Pagination parameters are available. You can also filter by status. Charge statuses can be pending, success or failed.
        /// </summary>
        /// <param name="id_or_code"></param>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<FetchChargesInBatchResponseModel> FetchChargesInBatch(string id_or_code,FetchChargesInBatchRequestModel requestModel)
        {
            var url = GetUrl($"{id_or_code}/charges?");
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<FetchChargesInBatchResponseModel>(getResult);
        }
        /// <summary>
        /// GET Pause Bulk Charge Batch
        /// Use this endpoint to pause processing a batch
        /// </summary>
        /// <param name="batch_code"></param>
        /// <returns></returns>
        public async Task<GeneralResponseModel> PauseBulkCharge(string batch_code)
        {
            var url = GetUrl($"pause/{batch_code}");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<GeneralResponseModel>(getResult);
        }
        /// <summary>
        /// GET Resume Bulk Charge Batch
        /// Use this endpoint to pause processing a batch
        /// </summary>
        /// <param name="batch_code"></param>
        /// <returns></returns>
        public async Task<GeneralResponseModel> ResumeBulkCharge(string batch_code)
        {
            var url = GetUrl($"resume/{batch_code}");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<GeneralResponseModel>(getResult);
        }
    }
}
