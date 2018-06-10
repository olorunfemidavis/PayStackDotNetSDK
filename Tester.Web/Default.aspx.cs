using System;
using System.Collections.Generic;
using PayStackDotNetSDK.Methods.Transactions;
using Tester.Web.Helpers;
using PayStackDotNetSDK.Models.Transactions;
using PayStackDotNetSDK.Methods.Banks;
using PayStackDotNetSDK.Methods.Customers;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Tester.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ActionBusson_ServerClick(object sender, EventArgs e)
        {
            //InitializeTransaction2();
            //GetAllBanks();
            //VerifyTransaction();
            //TransactionListing();
           // TransactionListing2();
        }
        /// <summary>
        /// Implements simple InitializeTransaction with basic parameters
        /// </summary>
        protected async void InitializeTransaction()
        {
            var paystackTransactionAPI = new PaystackTransaction(Credential.Key);
            var response = await paystackTransactionAPI.InitializeTransaction("email@email.com", 1000000);
            if (response.status)
            {
                Response.AddHeader("Access-Control-Allow-Origin", "*");
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                Response.Redirect(response.data.authorization_url); //Redirects your browser to the secure URL
            }
            else //not successful
            {
                //Do something else with the info.
                contentDiv.InnerText = response.message;
            }
        }
        /// <summary>
        /// Implements simple InitializeTransaction with full parameters
        /// </summary>
        protected async void InitializeTransaction2()
        {
            var paystackTransactionAPI = new PaystackTransaction(Credential.Key);
            var response = await paystackTransactionAPI.InitializeTransaction(new TransactionRequestModel() { firstName = "Olorunfemi", callback_url= "http://localhost:60441/Default.aspx", lastName = "Ajibulu", amount = 1000000, currency = PayStackDotNetSDK.Helpers.Constants.Currency.Naira, email = "email@email.com", metadata = new PayStackDotNetSDK.Models.Transactions.Metadata() { referrer = "email@email.com" }, transaction_charge = 4000 });
            if (response.status)
            {
                Response.AddHeader("Access-Control-Allow-Origin", "*");
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                Response.Redirect(response.data.authorization_url); //Redirects your browser to the secure URL
            }
            else //not successful
            {
                //Do something else with the info.
            }
        }

        protected async void VerifyTransaction()
        {
            var paystackTransactionAPI = new PaystackTransaction(Credential.Key);
            var response = await paystackTransactionAPI.VerifyTransaction("stwmg8j8by");
            var json = new JavaScriptSerializer().Serialize(response);
            contentDiv.InnerText = json;
        }
        /// <summary>
        /// Implementation with basic parameters
        /// </summary>
        protected async void TransactionListing()
        {
            var paystackTransactionAPI = new PaystackTransaction(Credential.Key);
            var response = await paystackTransactionAPI.ListTransactions();
            var json = new JavaScriptSerializer().Serialize(response);
            contentDiv.InnerText = json;
        }
        /// <summary>
        /// Implementation with full parameters
        /// </summary>
        protected async void TransactionListing2()
        {
            var paystackTransactionAPI = new PaystackTransaction(Credential.Key);
            var response = await paystackTransactionAPI.ListTransactions(new TransactionListRequestModel() { from = DateTime.UtcNow.AddDays(-10), to = DateTime.UtcNow, perPage = 50, status = PayStackDotNetSDK.Helpers.Constants.Transaction.Status.Success });
            var json = new JavaScriptSerializer().Serialize(response);
            contentDiv.InnerText = json;
        }

        protected async void FetchTransaction()
        {
            var paystackTransactionAPI = new PaystackTransaction(Credential.Key);
            var response = await paystackTransactionAPI.FetchTransaction(345);
        }
        /// <summary>
        /// Implementation with basic parameters
        /// </summary>
        protected async void ChargeAuthorization()
        {
            var paystackTransactionAPI = new PaystackTransaction(Credential.Key);
            var response = await paystackTransactionAPI.ChargeAuthorization("authorization_code", "email@email.com", 7000);
        }
        /// <summary>
        /// Implementation with full parameters
        /// </summary>
        protected async void ChargeAuthorization2()
        {
            var paystackTransactionAPI = new PaystackTransaction(Credential.Key);
            var response = await paystackTransactionAPI.ChargeAuthorization(new TransactionRequestModel() { firstName = "firstname" });
        }
        protected async void ViewTransactionTimelines()
        {
            var paystackTransactionAPI = new PaystackTransaction(Credential.Key);
            var response = await paystackTransactionAPI.TransactionTimeline("referenceOrID");
        }
        /// <summary>
        /// Implementation with basic parameters
        /// </summary>
        protected async void TransactionTotals()
        {
            var paystackTransactionAPI = new PaystackTransaction(Credential.Key);
            var response = await paystackTransactionAPI.TransactionTotals();
        }
        /// <summary>
        /// Implementation with full parameters
        /// </summary>
        protected async void TransactionTotals2()
        {
            var paystackTransactionAPI = new PaystackTransaction(Credential.Key);
            var response = await paystackTransactionAPI.TransactionTotals(new TransactionTotalsRequestModel() { });
        }
        /// <summary>
        /// Implementation with basic parameters
        /// </summary>
        protected async void ExportTransactions()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.ExportTransactions();
        }
        /// <summary>
        /// Implementation with full parameters
        /// </summary>
        protected async void ExportTransactions2()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.ExportTransactions(new ExportRequestModel() { from = DateTime.UtcNow.AddDays(-15) });
        }
        /// <summary>
        /// Implementation with basic parameters
        /// </summary>
        protected async void RequestReauthorization()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.RequestReAuthorization("authorization_code", "email@email.com", 4000);
        }
        /// <summary>
        /// Implementation with full parameters
        /// </summary>
        protected async void RequestReauthorization2()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.RequestReAuthorization(new RequestReAuthorizationRequestModel() { amount = 4000, authorization_code = "authorization_code", currency = PayStackDotNetSDK.Helpers.Constants.Currency.Naira, email = "email@email.com", reference = "reference", metadata = new RequestReAuthorizationMetadata() { custom_fields = new List<RequestReAuthorizationCustomField>() { new RequestReAuthorizationCustomField() { display_name = "display_name", value = "value", variable_name = "variable_name" } } } });
        }
        /// <summary>
        /// Implementation with basic parameters
        /// </summary>
        protected async void CheckAuthorization()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.CheckAuthorization("authorization_code", "email@email.com", 4000);
        }
        /// <summary>
        ///  Implementation with optional parameters
        /// </summary>
        protected async void CheckAuthorization2()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.CheckAuthorization("authorization_code", "email@email.com", 4000, PayStackDotNetSDK.Helpers.Constants.Currency.Naira);
        }
        /// <summary>
        /// Get all Nigerian Banks on Paystack API
        /// </summary>
        protected async void GetAllBanks()
        {
            string cre = Credential.Key;
            var connectionInstance = new PaystackListedBanks(Credential.Key);
            var response = await connectionInstance.ListBanks();
            var json = new JavaScriptSerializer().Serialize(response);
            contentDiv.InnerText = json;
        }
        /// <summary>
        ///  Fetch Transaction
        /// </summary>
        protected async void FetchTransaction2()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.FetchTransaction(345);
        }
        protected async void CreateCustomer()
        {
            var connectionInstance = new PaystackCustomer(Credential.Key);
            //var response = await connectionInstance.FetchTransaction(345);
        }
     
    }

}