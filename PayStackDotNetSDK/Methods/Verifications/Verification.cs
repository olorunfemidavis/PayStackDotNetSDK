using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayStackDotNetSDK.Interfaces;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Models.Verifications;

namespace PayStackDotNetSDK.Methods.Verifications
{
    public class PaystackVerification : IVerifications
    {
        private string _secretKey;
        public PaystackVerification(string secretKey)
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
                return "bank";
            return $"bank/{url}";
        }
        static string GetUrl()
        {
            return "bank";
        }
        /// <summary>
        /// GET Resolve BVN
        /// bvn (required) - 11 digit BVN
        /// </summary>
        /// <param name="bvn"></param>
        /// <returns></returns>
        public async Task<ResolveBVNResponseModel> ResolveBVN(string bvn)
        {
            var url = GetUrl($"resolve_bvn/{bvn }");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<ResolveBVNResponseModel>(getResult);
        }
        /// <summary>
        /// GET Match BVN
        /// The Match BVN endpoint checks if the account number for a bank belongs to a user's BVN
        /// account_number (required) - Bank account number
        /// bank_code(required) - Bank code from List Bank endpoint
        /// bvn(required) - 11 digit BVN
        /// </summary>
        /// <param name="account_number"></param>
        /// <param name="bank_code"></param>
        /// <param name="bvn"></param>
        /// <returns></returns>
        public async Task<MatchBVNResponseModel> MatchBVN(string account_number, string bank_code, string bvn)
        {
            var url = GetUrl($"match_bvn?account_number={account_number}&bank_code={bank_code}&bvn={bvn}");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<MatchBVNResponseModel>(getResult);
        }
        /// <summary>
        /// GET Resolve Account Number
        /// </summary>
        /// <param name="account_number"></param>
        /// <param name="bank_code"></param>
        /// <returns></returns>
        public async Task<ResolveAccountNumberResponseModel> ResolveAccountNumber(string account_number, string bank_code)
        {
            var url = GetUrl($"resolve?account_number={account_number}&bank_code={bank_code}");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<ResolveAccountNumberResponseModel>(getResult);
        }
        /// <summary>
        /// GET Resolve Card BIN
        /// bin (required) - First 6 characters of card
        /// </summary>
        /// <param name="bin"></param>
        /// <returns></returns>
        public async Task<ResolveCardBinResponseModel> ResolveCardBin(int bin)
        {
            var url = $"decision/bin/{bin}";
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<ResolveCardBinResponseModel>(getResult);
        }

        /// <summary>
        /// Using the Truecaller API you can verify the authenticity of a customer. It returns the customer's name, phone number, email, social media handles and organization as available on their Truecaller profile.
        /// POST Resolve Phone Number
        /// phone (required) - Customer phone number starting with country code (without the + prefix)
        /// verification_type (required) : truecaller
        /// callback_url - (required) Link on server to receive the truecaller details
        /// </summary>
        /// <param name="verification_type"></param>
        /// <param name="phone"></param>
        /// <param name="callback_url"></param>
        /// <returns></returns>
        public async Task<ResolvePhoneNumberResponseModel> ResolvePhoneNumber(string phone, string callback_url, string verification_type = Constants.Verification.Type.Truecaller)
        {
            string url = "verifications";
            var values = new Dictionary<string, string>
        {
           { "verification_type", verification_type },
           { "phone", $"{phone}" },
            { "callback_url", $"{callback_url}" },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<ResolvePhoneNumberResponseModel>(content);
        }
    }
}
