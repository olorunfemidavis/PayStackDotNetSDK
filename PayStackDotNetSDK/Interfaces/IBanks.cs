using PayStackDotNetSDK.Models.Banks;
using System.Threading.Tasks;
namespace PayStackDotNetSDK.Interfaces
{
    public interface IBanks
    {
        Task<BankListResponseModel> ListBanks();
    }
}
