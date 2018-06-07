using Newtonsoft.Json;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Interfaces;
using PayStackDotNetSDK.Models.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PayStackDotNetSDK.SDK.Subscription
{
    public class Subscription : ISubscriptions
    {
      
        string _secretKey;
        public Subscription(string secretKey)
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
                return "subscription";
            return $"subscription/{url}";
        }
        static string GetUrl()
        {
            return "subscription";
        }
        /// <summary>
        /// (required) - Customer's email address or customer code
        /// (required) - Plan code
        /// </summary>
        /// <param name="customerEmail"></param>
        /// <param name="planCode"></param>
        /// <param name="authorization"></param>
        /// <param name="start_date"></param>
        /// <returns></returns>
        public async Task<SubscriptionModel> CreateSubscription(string customer_Email_or_Code, string planCode)
        {
            string url = GetUrl();
            var values = new Dictionary<string, string>
        {
           { "customer", customer_Email_or_Code },
           { "plan", planCode },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<SubscriptionModel>(content);
        }
        /// <summary>
        /// If customer has multiple authorizations, you can set the desired authorization you wish to use for this subscription here. If this is not supplied, the customer's most recent authorization would be used
        /// Set the date for the first debit. (ISO 8601 format)
        /// </summary>
        /// <param name="customer_Email_or_Code"></param>
        /// <param name="planCode"></param>
        /// <param name="authorization"></param>
        /// <param name="start_date"></param>
        /// <returns></returns>
        public async Task<SubscriptionModel> CreateSubscription(string customer_Email_or_Code, string planCode, string authorization,
           string start_date)
        {
            string url = GetUrl();
            var values = new Dictionary<string, string>
        {
           { "customer", customer_Email_or_Code },
           { "plan", planCode },
            { "authorization", authorization },
           { "start_date", start_date },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<SubscriptionModel>(content);

        }
        public async Task<SubscriptionModel> ListSubscription()
        {
            var url = GetUrl();
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<SubscriptionModel>(getResult);
        }
        public async Task<SubscriptionModel> ListSubscription(SubscriptionListRequestModel requestModel)
        {
            var url = GetUrl();
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<SubscriptionModel>(getResult);
        }
        /// <summary>
        /// code (required) - Subscription code
        /// token(required) - Email token
        /// </summary>
        /// <param name="code"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<SubscriptionModel> DisableSubscription(string code, string token)
        {
            string url = GetUrl("disable");
            var values = new Dictionary<string, string>
        {
           { "code", code },
           { "token", token }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<SubscriptionModel>(content);
        }
        public async Task<SubscriptionModel> EnableSubscription(string code, string token)
        {
            string url = GetUrl("enable");
            var values = new Dictionary<string, string>
        {
           { "code", code },
           { "token", token }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<SubscriptionModel>(content);
        }
        /// <summary>
        /// Fetch Subscription
        /// </summary>
        /// <param name="id_or_subscription_code"></param>
        /// <returns></returns>
        public async Task<SubscriptionModel> FetchSubscription(string id_or_subscription_code)
        {
            var url = GetUrl(id_or_subscription_code);
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<SubscriptionModel>(getResult);
        }
    }
}
