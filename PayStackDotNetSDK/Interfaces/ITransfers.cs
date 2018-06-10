using PayStackDotNetSDK.Models;
using PayStackDotNetSDK.Models.Transfers;
using System.Threading.Tasks;


namespace PayStackDotNetSDK.Interfaces
{
    public interface ITransfers
    {

        Task<TransferInitiationResponseModel> InitiateTransfer(int amount, string recipient_code, string source = "balance");

        Task<TransferInitiationResponseModel> InitiateTransfer(TransferInitiationRequestModel requestModel);

        Task<TransferListResponseModel> ListTransfers();

        Task<TransferListResponseModel> ListTransfers(GeneralListRequestModel requestModel);

        Task<TransferModel> FetchTransfer(string transfer_code);

        Task<FinalizeTransferResponseModel> FinalizeTransfer(string transfer_code, string otp);
    }
}
