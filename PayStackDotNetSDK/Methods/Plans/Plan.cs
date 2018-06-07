using Newtonsoft.Json;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Interfaces;
using PayStackDotNetSDK.Models.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PayStackDotNetSDK.SDK.Plans
{
    public class Plan : IPlans
    {
        string _secretKey;
        public Plan(string secretKey)
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
                return "plan";
            return $"plan/{url}";
        }
        static string GetUrl()
        {
            return "plan";
        }
        public async Task<PlanResponseModel> CreatePlan(string name, int amount, string interval)
        {
            string url = GetUrl();
            var values = new Dictionary<string, string>
        {
           { "name", name },
           { "amount", $"{amount}" },
            { "interval", interval },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<PlanResponseModel>(content);
        }
        public async Task<PlanResponseModel> CreatePlan(PlanRequestModel planRequest)
        {
            string url = GetUrl();
            var content = await BaseClient.PostEntities(url, JsonConvert.SerializeObject(planRequest), this._secretKey);
            return JsonConvert.DeserializeObject<PlanResponseModel>(content);
        }
        public async Task<PlanListModel> ListPlans()
        {
            var url = GetUrl();
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<PlanListModel>(getResult);
        }
        /// <summary>
        /// List Plans with Query Params
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<PlanListModel> ListPlans(PlanListRequestModel requestModel)
        {
            var url = GetUrl();
            var properties = from p in requestModel.GetType().GetProperties()
                             where p.GetValue(requestModel, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + String.Join("&", properties.ToArray());
            var getResult = await BaseClient.GetEntities(queryString, this._secretKey);
            return JsonConvert.DeserializeObject<PlanListModel>(getResult);
        }

        public async Task<FetchPlanModel> FetchPlans(string id_or_plan_code)
        {
            var url = GetUrl(id_or_plan_code);
            var getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<FetchPlanModel>(getResult);

        }
        public async Task<PlanResponseModel> UpdatePlan(string id_or_plan_code, string name, int amount, string interval)
        {
            string url = GetUrl(id_or_plan_code);
            var values = new Dictionary<string, string>
        {
           { "name", name },
           { "amount", $"{amount}" },
            { "interval", interval },
        };
            var content = await BaseClient.PostEntities(url, GetContent(values), this._secretKey);
            return JsonConvert.DeserializeObject<PlanResponseModel>(content);
        }
        public async Task<PlanResponseModel> UpdatePlan(string id_or_plan_code, PlanRequestModel planRequest)
        {
            string url = GetUrl(id_or_plan_code);
            var content = await BaseClient.PutEntities(url, JsonConvert.SerializeObject(planRequest), this._secretKey);
            return JsonConvert.DeserializeObject<PlanResponseModel>(content);
        }

    }
}
