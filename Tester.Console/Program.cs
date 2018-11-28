using PayStackDotNetSDK.Methods.Transactions;
using System.Web.Script.Serialization;

namespace Tester.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("");


        }
        private static async void VerifyTransaction()
        {
            var paystackTransactionAPI = new PaystackTransaction("apikey/secret/key");
            var response = await paystackTransactionAPI.VerifyTransaction("T262788937392358");
            var json = new JavaScriptSerializer().Serialize(response);
            //contentDiv.InnerText = json;
        }
    }
}
