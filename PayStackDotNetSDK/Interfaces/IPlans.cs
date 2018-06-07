using PayStackDotNetSDK.Models.Plans;
using System.Threading.Tasks;

namespace PayStackDotNetSDK.Interfaces
{
    public interface IPlans
    {
        Task<PlanResponseModel> CreatePlan(string name, int amount, string interval);

        Task<PlanResponseModel> CreatePlan(PlanRequestModel planRequest);

        Task<PlanListModel> ListPlans();

        Task<PlanListModel> ListPlans(PlanListRequestModel requestModel);

        Task<FetchPlanModel> FetchPlans(string id_or_plan_code);

        Task<PlanResponseModel> UpdatePlan(string id_or_plan_code, string name, int amount, string interval);

        Task<PlanResponseModel> UpdatePlan(string id_or_plan_code, PlanRequestModel planRequest);
    }
}
