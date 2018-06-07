using PayStackDotNetSDK.Models;
using PayStackDotNetSDK.Models.TransfersControls;
using System.Threading.Tasks;



namespace PayStackDotNetSDK.Interfaces
{
    public interface ITransfersControls
    {
        Task<BalanceResponseModel> CheckBalance();

        Task<BalanceLedgerResponseModel> CheckBalanceLedger();

        Task<GeneralResponseModel> ResendOTPforTransfer(string transfer_code, string reason);

        Task<GeneralResponseModel> DisableOTP();

        Task<GeneralResponseModel> DisableOtpFinalize(string otp);

        Task<GeneralResponseModel> EnableOTP();



    }
}
