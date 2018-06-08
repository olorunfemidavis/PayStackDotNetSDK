using Newtonsoft.Json;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Interfaces;
using PayStackDotNetSDK.Models;
using PayStackDotNetSDK.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PayStackDotNetSDK.Methods.Customers
{
    public class PaystackCustomer : ICustomers
    {

        private string _secretKey;
        public PaystackCustomer(string secretKey)
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
                return "customer";
            return $"customer/{url}";
        }
        static string GetUrl()
        {
            return "customer";
        }


        public async Task<CustomerCreationResponse> CreateCustomer(string email)
        {
            string url = GetUrl();
            var values = new Dictionary<string, string>
        {
           { "email", email },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<CustomerCreationResponse>(content);
        }
        public async Task<CustomerCreationResponse> CreateCustomer(CustomersModel customer)
        {
            string url = GetUrl();
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(customer), this._secretKey);
            return JsonConvert.DeserializeObject<CustomerCreationResponse>(content);
        }
        public async Task<CustomerListResponse> ListCustomers()
        {
            var url = GetUrl();
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<CustomerListResponse>(getResult);
        }
        public async Task<CustomerListResponse> ListCustomers(CustomersListRequestModel requestModel)
        {
            var url = GetUrl();
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<CustomerListResponse>(getResult);
        }
        /// <summary>
        /// Fetch Customer using id_or_customer_code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CustomerCreationResponse> FetchCustomer(int id_or_customer_code)
        {
            var url = GetUrl($"{id_or_customer_code}");
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<CustomerCreationResponse>(getResult);
        }
        public async Task<CustomerCreationResponse> FetchCustomer(int id_or_customer_code, CustomerFetchRequestModel requestModel)
        {
            var url = GetUrl($"{id_or_customer_code}");
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<CustomerCreationResponse>(getResult);
        }
        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="id_or_customer_code"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<CustomerCreationResponse> UpdateCustomer(int id_or_customer_code, CustomersModel customer)
        {
            var url = GetUrl($"{id_or_customer_code}");
            var content = await BaseClient.PutEntities(url, JsonConvert.SerializeObject(customer), this._secretKey);
            return JsonConvert.DeserializeObject<CustomerCreationResponse>(content);
        }
        /// <summary>
        /// White/blacklist Customer
        /// customer - Customer's ID, code, or email address
        /// risk_action - One of the possible risk actions.allow to whitelist. deny to blacklist.
        /// </summary>
        /// <param name="customer_email_or_id_or_code"></param>
        /// <param name="risk_action"></param>
        /// <returns></returns>
        public async Task<CustomerCreationResponse> White_BlacklistCustomer(string customer_email_or_id_or_code, string risk_action)
        {
            string url = GetUrl("set_risk_action");
            var values = new Dictionary<string, string>
        {
           { "customer", customer_email_or_id_or_code },
            { "risk_action", risk_action },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<CustomerCreationResponse>(content);
        }
        public async Task<CustomerCreationResponse> DeactivateCustomerAuthorization(string authorization_code)
        {
            string url = GetUrl("deactivate_authorization");
            var values = new Dictionary<string, string>
        {
           { "authorization_code", authorization_code },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<CustomerCreationResponse>(content);
        }
    }
}
