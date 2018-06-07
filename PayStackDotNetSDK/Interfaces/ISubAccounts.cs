using PayStackDotNetSDK.Models.SubAccounts;
using System.Threading.Tasks;


namespace PayStackDotNetSDK.Interfaces
{
    public interface ISubAccounts
    {
        Task<SubAccountResponseModel> CreateSubAccount(string business_name, string settlement_bank, string account_number, float percentage_charge);

        Task<SubAccountResponseModel> CreateSubAccount(SubAccountModel subAccount);

        Task<SubAccountListModel> ListSubAccounts();

        Task<SubAccountListModel> ListSubAccounts(ListSubAccountsRequestModel requestModel);

        Task<SubAccountResponseModel> FetchSubAccount(string id_or_slug);

        Task<SubAccountResponseModel> UpdateSubAccount(string id_or_slug, string business_name, string settlement_bank_code, string account_number,
                                float percentage_charge);
        Task<SubAccountResponseModel> CreateSubAccount(string id_or_slug, SubAccountModel subAccount);
    }
}
