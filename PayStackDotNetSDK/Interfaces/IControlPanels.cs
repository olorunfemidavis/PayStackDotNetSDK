using PayStackDotNetSDK.Models.ControlPanels;
using System.Threading.Tasks;


namespace PayStackDotNetSDK.Interfaces
{
    public interface IControlPanels
    {
        Task<PaymentSessionTimeoutResponseModel> FetchPaymentSessionTimeout();

        Task<PaymentSessionTimeoutResponseModel> UpdatePaymentSessionTimeout(int timeout);
    }
}
