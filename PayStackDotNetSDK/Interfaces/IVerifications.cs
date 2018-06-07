using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Models.Verifications;
using System.Threading.Tasks;

namespace PayStackDotNetSDK.Interfaces
{
    public interface IVerifications
    {
        Task<ResolveBVNResponseModel> ResolveBVN(string bvn);

        Task<MatchBVNResponseModel> MatchBVN(string account_number, string bank_code, string bvn);

        Task<ResolveAccountNumberResponseModel> ResolveAccountNumber(string account_number, string bank_code);

        Task<ResolveCardBinResponseModel> ResolveCardBin(int bin);

        Task<ResolvePhoneNumberResponseModel> ResolvePhoneNumber(string phone, string callback_url, string verification_type = Constants.Verification.Type.Truecaller);
    }
}
