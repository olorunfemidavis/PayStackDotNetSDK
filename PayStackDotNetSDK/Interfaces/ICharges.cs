using PayStackDotNetSDK.Models.Charges;
using System.Threading.Tasks;


namespace PayStackDotNetSDK.Interfaces
{
    public interface ICharges
    {
        Task<TokenizePaymentResponseModel> TokenizePayment(TokenizePaymentRequestModel paymentRequestModel);

        Task<TokenizePaymentResponseModel> ChargePayment(ChargePaymentRequestModel paymentRequestModel);

        Task<ChargesGeneralResponseModel> SubmitPin(string pin, string reference);

        Task<ChargesGeneralResponseModel> SubmitOtp(string otp, string reference);

        Task<ChargesGeneralResponseModel> SubmitPhone(string phone, string reference);

        Task<ChargesGeneralResponseModel> SubmitBirthday(string birthday, string reference);

        Task<PendingChargeResponseModel> CheckPendingCharge(string reference);
    }
}
