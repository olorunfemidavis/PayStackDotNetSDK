using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PayStackDotNetSDK.Helpers
{
    internal class BaseClient
    {
        internal static async Task<string> PostEntities(string urlLink, string content, string secretKey)
        {
            var httpClient = HttpConnection.CreateClient(secretKey);
            HttpResponseMessage httpResponse = await httpClient.PostAsync(urlLink, new StringContent(content, Encoding.UTF8, Constants.ContentTypeHeaderJson));
            return await httpResponse.Content.ReadAsStringAsync();
        }
        internal static async Task<string> GetEntities(string urlLink, string secretKey)
        {
            var client = HttpConnection.CreateClient(secretKey);
            var response = client.GetAsync(urlLink);
            return await response.Result.Content.ReadAsStringAsync();
        }
        internal static async Task<string> PutEntities(string urlLink, string content, string secretKey)
        {
            var client = HttpConnection.CreateClient(secretKey);
            var response = await client.PutAsync(urlLink, new StringContent(content, Encoding.UTF8, Constants.ContentTypeHeaderJson));
            return await response.Content.ReadAsStringAsync();
        }
    }
}
