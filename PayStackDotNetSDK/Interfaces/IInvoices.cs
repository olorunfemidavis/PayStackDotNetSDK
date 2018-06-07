using PayStackDotNetSDK.Models;
using PayStackDotNetSDK.Models.Invoices;
using System.Threading.Tasks;

namespace PayStackDotNetSDK.Interfaces
{
    public interface IInvoices
    {
        Task<InvoiceResponseModel> CreateInvoice(string customer_id_or_code, string due_date_ISO_8601, int amount_in_kobo);

        Task<InvoiceResponseModel> CreateInvoice(InvoiceRequestModel invoiceRequest);

        Task<InvoiceListResponseModel> ListInvoices();

        Task<InvoiceListResponseModel> ListInvoices(InvoiceListRequestModel requestModel);

        Task<VerifyInvoiceResponseModel> VerifyInvoice(string ID_OR_CODE);

        Task<InvoiceResponseModel> SendNotification(string ID_OR_CODE);

        Task<InvoiceTotalsResponseModel> InvoiceTotals();

        Task<InvoiceResponseModel> FinalizeInvoice(string ID_OR_CODE, bool send_notification);

        Task<InvoiceUpdateResponseModel> UpdateInvoice(string ID_OR_CODE, InvoiceRequestModel invoiceRequest);

        Task<GeneralResponseModel> ArchiveInvoice(string id_or_code);
    }
}
