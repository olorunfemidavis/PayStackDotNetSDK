using PayStackDotNetSDK.Models.TransferRecipients;
using System.Threading.Tasks;



namespace PayStackDotNetSDK.Interfaces
{
    public interface ITransferRecipients
    {
        Task<TransferRecipientModel> CreateTransferRecipient(string type, string name, string account_number, string bank_code);

        Task<TransferRecipientModel> CreateTransferRecipient(TransferRecipientRequestModel recipientRequestModel);

        Task<TransferRecipientListModel> ListTransferRecipients();

        Task<TransferRecipientListModel> ListTransferRecipients(TransferRecipientListRequestModel requestModel);
    }
}
