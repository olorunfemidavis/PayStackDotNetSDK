using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Models.TransfersControls;
using PayStackDotNetSDK.Models;
using PayStackDotNetSDK.Interfaces;

namespace PayStackDotNetSDK.Methods.TransfersControls
{
    public class PaystackTransfersControl : ITransfersControls
    {
        private string _secretKey;
        public PaystackTransfersControl(string secretKey)
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
                return "balance";
            return $"balance/{url}";
        }
        static string GetUrl()
        {
            return "balance";
        }
        /// <summary>
        /// GET Check Balance
        /// </summary>
        /// <returns></returns>
        public async Task<BalanceResponseModel> CheckBalance()
        {
            var url = GetUrl();
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<BalanceResponseModel>(getResult);
        }
        /// <summary>
        /// GET Check Balance Ledger: Returns all activity carried out from and to the Paystack Balance
        /// </summary>
        /// <returns></returns>
        public async Task<BalanceLedgerResponseModel> CheckBalanceLedger()
        {
            var url = GetUrl("ledger");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<BalanceLedgerResponseModel>(getResult);
        }
        /// <summary>
        /// POST Resend OTP for Transfer
        /// transfer_code (required) - Transfer code
        /// reason(required) - either ['disable_otp' or 'transfer']
        /// </summary>
        /// <param name="transfer_code"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public async Task<GeneralResponseModel> ResendOTPforTransfer(string transfer_code, string reason)
        {
            string url = GetUrl("resend_otp");
            var values = new Dictionary<string, string>
        {
           { "transfer_code", transfer_code },
           { "reason", reason },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<GeneralResponseModel>(content);
        }
        /// <summary>
        /// POST Disable OTP requirement for Transfers
        /// In the event that you want to be able to complete transfers programmatically without use of OTPs, this endpoint helps disable that….with an OTP. No arguments required. An OTP is sent to you on your business phone.
        /// </summary>
        /// <returns></returns>
        public async Task<GeneralResponseModel> DisableOTP()
        {
            string url = GetUrl("disable_otp");
            var values = new Dictionary<string, string>
        {
           { "", "" }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<GeneralResponseModel>(content);
        }
        /// <summary>
        /// POST Finalize Disabling of OTP requirement for Transfers
        /// </summary>
        /// <param name="otp"></param>
        /// <returns></returns>
        public async Task<GeneralResponseModel> DisableOtpFinalize(string otp)
        {
            string url = GetUrl("disable_otp_finalize");
            var values = new Dictionary<string, string>
        {
           { "otp", otp }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<GeneralResponseModel>(content);
        }
        /// <summary>
        /// POST Enable OTP requirement for Transfers
        /// In the event that a customer wants to stop being able to complete transfers programmatically, this endpoint helps turn OTP requirement back on. No arguments required.
        /// </summary>
        /// <returns></returns>
        public async Task<GeneralResponseModel> EnableOTP()
        {
            string url = GetUrl("enable_otp");
            var values = new Dictionary<string, string>
        {
           { "", "" }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<GeneralResponseModel>(content);
        }
    }
}
