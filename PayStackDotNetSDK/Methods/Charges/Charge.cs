using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayStackDotNetSDK.Interfaces;
using Newtonsoft.Json;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Models.Charges;

namespace PayStackDotNetSDK.Methods.Charges
{
    public class PaystackCharge : ICharges
    {
        private string _secretKey;
        public PaystackCharge(string secretKey)
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
                return "charge";
            return $"charge/{url}";
        }
        static string GetUrl()
        {
            return "charge";
        }
        /// <summary>
        /// POST Tokenize payment instrument before a charge
        /// </summary>
        /// <param name="paymentRequestModel"></param>
        /// <returns></returns>
        public async Task<TokenizePaymentResponseModel> TokenizePayment(TokenizePaymentRequestModel paymentRequestModel)
        {
            string url = GetUrl("tokenize");
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(paymentRequestModel), this._secretKey);
            return JsonConvert.DeserializeObject<TokenizePaymentResponseModel>(content);
        }
        /// <summary>
        /// POST Charge
        /// Send card details or bank details or authorization code to start a charge. Simple guide to charging cards directly 
        /// </summary>
        /// <param name="paymentRequestModel"></param>
        /// <returns></returns>
        public async Task<TokenizePaymentResponseModel> ChargePayment(ChargePaymentRequestModel paymentRequestModel)
        {
            string url = GetUrl();
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(paymentRequestModel), this._secretKey);
            return JsonConvert.DeserializeObject<TokenizePaymentResponseModel>(content);
        }
        /// <summary>
        /// pin (required) - PIN submitted by user
        /// reference (required) - reference for transaction that requested pin
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public async Task<ChargesGeneralResponseModel> SubmitPin(string pin, string reference)
        {
            string url = GetUrl("submit_pin");
            var values = new Dictionary<string, string>
        {
           { "pin", pin },
           { "reference", reference },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<ChargesGeneralResponseModel>(content);
        }

        /// <summary>
        /// otp (required) - OTP submitted by user
        /// reference (required) - reference for ongoing transaction
        /// </summary>
        /// <param name="otp"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public async Task<ChargesGeneralResponseModel> SubmitOtp(string otp, string reference)
        {
            string url = GetUrl("submit_otp");
            var values = new Dictionary<string, string>
        {
           { "otp", otp },
           { "reference", reference },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<ChargesGeneralResponseModel>(content);
        }
        /// <summary>
        /// phone (required) - Phone number submitted by user
        /// reference (required) - reference for ongoing transaction
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public async Task<ChargesGeneralResponseModel> SubmitPhone(string phone, string reference)
        {
            string url = GetUrl("submit_phone");
            var values = new Dictionary<string, string>
        {
           { "phone", phone },
           { "reference", reference },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<ChargesGeneralResponseModel>(content);
        }
        /// <summary>
        /// Please provide birthday (YYYY-MM-DD) birthday (required) - Birthday number submitted by user
        /// reference (required) - reference for ongoing transaction
        /// </summary>
        /// <param name="birthday"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public async Task<ChargesGeneralResponseModel> SubmitBirthday(string birthday, string reference)
        {
            string url = GetUrl("submit_birthday");
            var values = new Dictionary<string, string>
        {
           { "birthday", birthday },
           { "reference", reference },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<ChargesGeneralResponseModel>(content);
        }
        /// <summary>
        /// GET Check pending charge
        /// When you get "pending" as a charge status, wait 30 seconds or more, then make a check to see if its status has changed. Don't call too early as you may get a lot more pending than you should.
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public async Task<PendingChargeResponseModel> CheckPendingCharge(string reference)
        {
            var url = GetUrl(reference);
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<PendingChargeResponseModel>(getResult);
        }
    }
}
