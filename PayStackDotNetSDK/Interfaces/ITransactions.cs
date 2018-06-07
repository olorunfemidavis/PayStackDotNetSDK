using PayStackDotNetSDK.Models;
using PayStackDotNetSDK.Models.Transactions;
using System.Threading.Tasks;


namespace PayStackDotNetSDK.Interfaces
{
    public interface ITransactions
    {
        Task<PaymentInitalizationResponseModel> InitializeTransaction(string email, int amount);

        Task<PaymentInitalizationResponseModel> InitializeTransaction(TransactionRequestModel transactionRequest);

        Task<TransactionResponseModel> VerifyTransaction(string reference);

        Task<TransactionListResponseModel> ListTransactions();

        Task<TransactionListResponseModel> ListTransactions(TransactionListRequestModel requestModel);

        Task<TransactionResponseModel> FetchTransaction(int id);

        Task<TransactionResponseModel> ChargeAuthorization(string authorization_code, string email, int amount);

        Task<TransactionResponseModel> ChargeAuthorization(TransactionRequestModel transactionRequest);

        Task<TransactionResponseModel> TransactionTimeline(string reference);

        Task<TransactionTotalModel> TransactionTotals();

        Task<TransactionTotalModel> TransactionTotals(TransactionTotalsRequestModel requestModel);

        Task<ExportResponseModel> ExportTransactions();

        Task<ExportResponseModel> ExportTransactions(ExportRequestModel exportRequest);

        Task<RequestReAuthorizationResponseModel> RequestReAuthorization(string authorization_code, string email, int amount);

        Task<RequestReAuthorizationResponseModel> RequestReAuthorization(RequestReAuthorizationRequestModel requestModel);

        Task<TransactionResponseModel> CheckAuthorization(string authorization_code, string email, int amount);

        Task<TransactionResponseModel> CheckAuthorization(string authorization_code, string email, int amount, string currency);

    }

}
