using PayStackDotNetSDK.Models.Refunds;
using System.Threading.Tasks;


namespace PayStackDotNetSDK.Interfaces
{
    public interface IRefunds
    {
        Task<CreateRefundResponseModel> CreateRefund(string transaction);

        Task<CreateRefundResponseModel> CreateRefund(CreateRefundRequestModel transactionRequest);

        Task<ListRefundResponseModel> ListRefund();

        Task<ListRefundResponseModel> ListRefund(ListRefundRequestModel requestModel);

        Task<FetchRefundResponseModel> FetchRefund(string id);
    }
}
