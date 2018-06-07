using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayStackDotNetSDK.Interfaces;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Models.ControlPanels;

namespace PayStackDotNetSDK.Methods.ControlPanels
{
    public class ControlPanel: IControlPanels
    {
        private string _secretKey;
        public ControlPanel(string secretKey)
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
                return "integration";
            return $"integration/{url}";
        }
        static string GetUrl()
        {
            return "integration";
        }
        /// <summary>
        /// GET Fetch Payment Session Timeout
        /// </summary>
        /// <returns></returns>
        public async Task<PaymentSessionTimeoutResponseModel> FetchPaymentSessionTimeout()
        {
            var url = GetUrl("payment_session_timeout");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<PaymentSessionTimeoutResponseModel>(getResult);
        }
        /// <summary>
        /// PUT Update Payment Session Timeout
        /// timeout - Time before stopping session (in seconds). Set to 0 to cancel session timeouts
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public async Task<PaymentSessionTimeoutResponseModel> UpdatePaymentSessionTimeout(int timeout)
        {
            string url = GetUrl("payment_session_timeout");
            var values = new Dictionary<string, string>
        {
           { "timeout", $"{timeout}" }
        };
            var content = await BaseClient.PutEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<PaymentSessionTimeoutResponseModel>(content);
        }
    }
}
