using PayStackDotNetSDK.Models.Settlements;
using System.Threading.Tasks;

namespace PayStackDotNetSDK.Interfaces
{
    public interface ISettlements
    {
        Task<SettlementResponseModel> FetchSettlement();

        Task<SettlementResponseModel> FetchSettlement(SettlementRequestModel requestModel);

    }
}
