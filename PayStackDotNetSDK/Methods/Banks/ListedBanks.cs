using System.Threading.Tasks;
using Newtonsoft.Json;
using PayStackDotNetSDK.Helpers;
using PayStackDotNetSDK.Interfaces;
using PayStackDotNetSDK.Models.Banks;

namespace PayStackDotNetSDK.Methods.Banks
{
    public class ListedBanks : IBanks
    {
        private string _secretKey;
        public ListedBanks(string secretKey)
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
