using System.Threading.Tasks;
using Newtonsoft.Json;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Interfaces;
using PayStackDotNetSDK.Models.Banks;

namespace PayStackDotNetSDK.SDK.Banks
{
    public class PayStackListedBanks : IBanks
    {
        private string _secretKey;
        public PayStackListedBanks(string secretKey)
        {
            this._secretKey = secretKey;
        }

        public async Task<BankListResponseModel> ListBanks()
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            var response = await client.GetAsync("https://api.paystack.co/bank");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BankListResponseModel>(json);
        }
    }
}
