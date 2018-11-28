using PayStackDotNetSDK.Methods.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using PayStackDotNetSDK.Methods.TransferRecipients;
using PayStackDotNetSDK.Models.TransferRecipients;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // VerifyTransaction();
            CreateTransferRecipient();
            Console.ReadKey();
        }
        private static async void VerifyTransaction()
        {
            var paystackTransactionAPI = new PaystackTransaction("apikey/secret/key");
            var response = await paystackTransactionAPI.VerifyTransaction("reference");
            var json = new JavaScriptSerializer().Serialize(response);
            Console.WriteLine(json);
        }

        private static async void CreateTransferRecipient()
        {
            PaystackTransferRecipient transferRecipient = new PaystackTransferRecipient("apikey/secret/key");
            TransferRecipientRequestModel requestModel = new TransferRecipientRequestModel {
                 account_number = "", bank_code = "",  name="", description= "Test User",
                  currency = "NGN"
            };
            var response = await transferRecipient.CreateTransferRecipient(requestModel);
            var json = new JavaScriptSerializer().Serialize(response);
            Console.WriteLine(json);
        }
    }
}
