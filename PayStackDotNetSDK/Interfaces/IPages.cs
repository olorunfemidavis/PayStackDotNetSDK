using PayStackDotNetSDK.Models.Pages;
using System.Threading.Tasks;

namespace PayStackDotNetSDK.Interfaces
{
    public interface IPages
    {
        Task<PageResponseModel> CreatePage(string name);

        Task<PageResponseModel> CreatePage(PageRequestModel pageRequest);

        Task<PageListModel> ListPages();

        Task<PageListModel> ListPages(PageListRequestModel requestModel);

        Task<FetchPageModel> FetchPages(string id_or_plan_code);

        Task<PageResponseModel> UpdatePage(string id_or_plan_code, string name, string description, int amount, bool active);

        Task<FetchPageModel> CheckSlug(string slug_url);
    }
}
