using Newtonsoft.Json;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Models.Pages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using PayStackDotNetSDK.Interfaces;

namespace PayStackDotNetSDK.Methods.Pages
{
    public class PaystackPage : IPages
    {
        string _secretKey;
        public PaystackPage(string secretKey)
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
                return "page";
            return $"page/{url}";
        }
        static string GetUrl()
        {
            return "page";
        }
        public async Task<PageResponseModel> CreatePage(string name)
        {
            string url = GetUrl();
            var values = new Dictionary<string, string>
        {
           { "name", name }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<PageResponseModel>(content);
        }
        /// <summary>
        /// CreatePage
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        public async Task<PageResponseModel> CreatePage(PageRequestModel pageRequest)
        {
            string url = GetUrl();
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(pageRequest), this._secretKey);
            return JsonConvert.DeserializeObject<PageResponseModel>(content);
        }
        /// <summary>
        /// List Pages
        /// </summary>
        /// <returns></returns>
        public async Task<PageListModel> ListPages()
        {
            var url = GetUrl();
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<PageListModel>(getResult);
        }
        /// <summary>
        /// List Pages with Query Params
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<PageListModel> ListPages(PageListRequestModel requestModel)
        {
            var url = GetUrl("?");
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<PageListModel>(getResult);
        }

        public async Task<FetchPageModel> FetchPages(string id_or_plan_code)
        {
            var url = GetUrl(id_or_plan_code);
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<FetchPageModel>(getResult);
        }
        public async Task<PageResponseModel> UpdatePage(string id_or_plan_code, string name, string description, int amount, bool active)
        {
            string url = GetUrl(id_or_plan_code);
            var values = new Dictionary<string, string>
        {
           { "name", name },
           { "description", description },
           { "amount", $"{amount}" },
           { "active", $"{active}" }
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<PageResponseModel>(content);
        }

        /// <summary>
        /// Check Slug Availability
        /// slug (required) - URL slug to be confirmed
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        public async Task<FetchPageModel> CheckSlug(string slug_url)
        {
            var url = GetUrl(slug_url);
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<FetchPageModel>(getResult);

        }
    }
}
