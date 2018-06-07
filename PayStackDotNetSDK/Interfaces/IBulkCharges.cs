using PayStackDotNetSDK.Models;
using PayStackDotNetSDK.Models.BulkCharges;
using PayStackDotNetSDK.Models.Charges;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PayStackDotNetSDK.Interfaces
{
    public interface IBulkCharges
    {
        Task<InitiateBulkChargeResponseModel> InitiateBulkCharge(List<ChargePaymentRequestModel> chargePayments);

        Task<ListBulkChargeBatchesResponseModel> ListBulkChargeBatches();

        Task<ListBulkChargeBatchesResponseModel> ListBulkChargeBatches(GeneralListRequestModel requestModel);

        Task<FetchBulkChargeBatchResponseModel> FetchBulkChargeBatch(string id_or_code);

        Task<FetchChargesInBatchResponseModel> FetchChargesInBatch(string id_or_code);

        Task<FetchChargesInBatchResponseModel> FetchChargesInBatch(string id_or_code, FetchChargesInBatchRequestModel requestModel);

        Task<GeneralResponseModel> PauseBulkCharge(string batch_code);

        Task<GeneralResponseModel> ResumeBulkCharge(string batch_code);
    }
}
