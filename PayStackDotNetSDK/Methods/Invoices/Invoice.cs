using Newtonsoft.Json;
using PayStackDotNetSDK.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PayStackDotNetSDK.Models.Invoices;
using System.Linq;
using System.Web;
using PayStackDotNetSDK.Models;
using PayStackDotNetSDK.Interfaces;

namespace PayStackDotNetSDK.Methods.Invoices
{
    public class PaystackInvoice : IInvoices
    {
        private string _secretKey;
        public PaystackInvoice(string secretKey)
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
                return "paymentrequest";
            return $"paymentrequest/{url}";
        }
        static string GetUrl()
        {
            return "paymentrequest";
        }
        /// <summary>
        /// Create Invoice with basic params
        /// </summary>
        /// <param name="customer_id_or_code"></param>
        /// <param name="due_date_ISO_8601"></param>
        /// <param name="amount_in_kobo"></param>
        /// <returns></returns>
        public async Task<InvoiceResponseModel> CreateInvoice(string customer_id_or_code, string due_date_ISO_8601, int amount_in_kobo)
        {
            string url = GetUrl();
            var values = new Dictionary<string, string>
        {
           { "customer", customer_id_or_code },
           { "due_date", $"{due_date_ISO_8601}" },
           { "amount", $"{amount_in_kobo}" },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<InvoiceResponseModel>(content);
        }
        /// <summary>
        /// Create Invoice with full params
        /// </summary>
        /// <param name="invoiceRequest"></param>
        /// <returns></returns>
        public async Task<InvoiceResponseModel> CreateInvoice(InvoiceRequestModel invoiceRequest)
        {
            string url = GetUrl();
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(invoiceRequest), this._secretKey);
            return JsonConvert.DeserializeObject<InvoiceResponseModel>(content);
        }
        /// <summary>
        /// List Invoices
        /// </summary>
        /// <returns></returns>
        public async Task<InvoiceListResponseModel> ListInvoices()
        {
            var url = GetUrl();
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<InvoiceListResponseModel>(getResult);
        }
        /// <summary>
        /// List Invoices with params
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<InvoiceListResponseModel> ListInvoices(InvoiceListRequestModel requestModel)
        {
            var url = GetUrl();
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<InvoiceListResponseModel>(getResult);
        }
        public async Task<ViewInvoiceResponseModel> ViewInvoice(string REQUEST_ID_OR_CODE)
        {
            string url = GetUrl(REQUEST_ID_OR_CODE);
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<ViewInvoiceResponseModel>(getResult);
        }
        /// <summary>
        /// Note that a key is added called pending_amount when you fetch an invoice. This is because when paying for an invoice, you can choose to pay part but not all. Whenever a successful transaction is made, the key updates to reveal what’s left of the invoice to pay.
        /// </summary>
        /// <param name="ID_OR_CODE"></param>
        /// <returns></returns>
        public async Task<VerifyInvoiceResponseModel> VerifyInvoice(string ID_OR_CODE)
        {
            var url = GetUrl($"verify/{ID_OR_CODE}");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<VerifyInvoiceResponseModel>(getResult);
        }
        /// <summary>
        /// Send Notification
        /// </summary>
        /// <param name="ID_OR_CODE"></param>
        /// <returns></returns>
        public async Task<InvoiceResponseModel> SendNotification(string ID_OR_CODE)
        {
            string url = GetUrl($"notify/{ID_OR_CODE}");
            var values = new Dictionary<string, string>
        {
           { "", "" }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<InvoiceResponseModel>(content);
        }
        /// <summary>
        /// GET Invoice Total
        /// </summary>
        /// <returns></returns>
        public async Task<InvoiceTotalsResponseModel> InvoiceTotals()
        {
            var url = GetUrl("totals");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<InvoiceTotalsResponseModel>(getResult);
        }
        /// <summary>
        /// POST Finalize Invoice
        /// </summary>
        /// <param name="ID_OR_CODE"></param>
        /// <param name="send_notification"></param>
        /// <returns></returns>
        public async Task<InvoiceResponseModel> FinalizeInvoice(string ID_OR_CODE, bool send_notification)
        {
            string url = GetUrl($"finalize/{ID_OR_CODE}");
            var values = new Dictionary<string, string>
        {
           { "send_notification", $"{send_notification}" }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<InvoiceResponseModel>(content);
        }
        /// <summary>
        /// PUT Update Invoice
        /// </summary>
        /// <param name="ID_OR_CODE"></param>
        /// <param name="invoiceRequest"></param>
        /// <returns></returns>
        public async Task<InvoiceUpdateResponseModel> UpdateInvoice(string ID_OR_CODE, InvoiceRequestModel invoiceRequest)
        {
            string url = GetUrl(ID_OR_CODE);
            var content = await BaseClient.PutEntities(url, JsonConvert.SerializeObject(invoiceRequest), this._secretKey);
            return JsonConvert.DeserializeObject<InvoiceUpdateResponseModel>(content);
        }
        /// <summary>
        /// POST Archive Invoice
        /// </summary>
        /// <param name="id_or_code"></param>
        /// <returns></returns>
        public async Task<GeneralResponseModel> ArchiveInvoice(string id_or_code)
        {
            string url = GetUrl($"archive/{id_or_code}");
            var values = new Dictionary<string, string>
        {
           { "", "" }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<GeneralResponseModel>(content);
        }        
    }
}
