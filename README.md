# PayStackDotNetSDK
PayStackDotNetSDK API is a collection of all PayStack endpoints that C# developers can take advantage of to build financial solutions in Nigeria. 
Visit [Paystack](https://paystack.com) for Setup.

### Prerequisites

This Library require .Net framework 4.6 or higher


### Installing
Install this library from [Nuget](https://www.nuget.org/packages/PayStackDotNetSDK)



## Author

* **Olorunfemi Ajibulu** -  [Booksrite](https://www.booksrite.com/)

## Contributors

* **Oluwasayo Babalola** -  [LinkedIn](https://www.linkedin.com/in/sayob)

### Reference
Some parts of this project were taken from Paystack.Net.SDK. 
* Mark Adesina -  [Github](https://github.com/developerslearnit/Paystack.Net.SDK)

## Sample Project
This project[alpha stage] showcases some uses of PayStackDotNetSDK methods.  [Github](https://github.com/fzany/PaystackTester)

## License

This project is licensed under the MIT License

## Upcoming: 
* More precise intellisense
* More Documentation in this README file


## SDK Usage
Add namespaces: 
using PayStackDotNetSDK;
using PayStackDotNetSDK.Helpers;

#### We suggest you go through the detailed documentation:
* **Read Documentation Here** -  [PAYSTACK API Documentation](https://documenter.getpostman.com/view/2770716/paystack-api/7187aMn?_ga=2.249786758.1833761717.1528120005-928457610.1525102051#intro)


### Transactions
add namespaces: 
using PayStackDotNetSDK.Methods.Transactions;
using PayStackDotNetSDK.Models.Transactions;


#### Transaction Initialization

		/// <summary>
        /// Implements simple InitializeTransaction with basic parameters
        /// </summary>
        protected async void InitializeTransaction()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.InitializeTransaction("email@email.com", 1000000);
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
        /// <summary>
        /// Implements simple InitializeTransaction with full parameters
		/// If callback url is given, the url will be called upon completion. For example http://localhost:60441/Default.aspx?trxref=4dsnq70qtd&reference=4dsnq70qtd
        /// </summary>
        protected async void InitializeTransaction()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.InitializeTransaction(new TransactionRequestModel() { firstName="firstname", lastName="lastname", amount=1000000, currency = PayStackDotNetSDK.Helpers.Constants.Currency.Naira, email="email@email.com", metadata = new PaystackMetadata() { referrer="email@email.com" }, transaction_charge=4000 });
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


#### Transaction Verification
    protected async void VerifyTransaction()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.VerifyTransaction("reference_code");
        }

#### Transaction Listings
		/// <summary>
        /// Implementation with basic parameters
        /// </summary>
        protected async void TransactionListing()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.ListTransactions();
        }
        /// <summary>
        /// Implementation with full parameters
        /// </summary>
        protected async void TransactionListing()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.ListTransactions(new TransactionListRequestModel() {amount=40000, from= DateTime.UtcNow.AddDays(-10), to=DateTime.UtcNow, page=2, perPage=50, status= PayStackDotNetSDK.Helpers.Constants.Transaction.Status.Success, customer =4 });
        }

#### Fetch Transaction

		/// <summary>
        ///  Fetch Transaction
        /// </summary>
        protected async void FetchTransaction()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.FetchTransaction(345);
        }

#### Charge Authorization

		/// <summary>
        /// Implementation with basic parameters
        /// </summary>
        protected async void ChargeAuthorization()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.ChargeAuthorization("authorization_code", "email@email.com", 7000);
        }
        /// <summary>
        /// Implementation with full parameters
        /// </summary>
        protected async void ChargeAuthorization()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.ChargeAuthorization(new TransactionRequestModel() { firstName="firstname" });
        }

#### View Transaction Timeline

     protected async void ViewTransactionTimelines()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.TransactionTimeline("referenceOrID");
        }


#### Transaction Totals

		/// <summary>
        /// Implementation with basic parameters
        /// </summary>
        protected async void TransactionTotals()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.TransactionTotals();
        }
        /// <summary>
        /// Implementation with full parameters
        /// </summary>
        protected async void TransactionTotals()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.TransactionTotals(new TransactionTotalsRequestModel() { });
        }
 
 
#### View  Export Transactions

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
        protected async void ExportTransactions()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.ExportTransactions(new ExportRequestModel() { from= DateTime.UtcNow.AddDays(-15) });
        }

#### Request Reauthorization

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
        protected async void RequestReauthorization()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.RequestReAuthorization(new RequestReAuthorizationRequestModel() { amount = 4000, authorization_code = "authorization_code", currency = PayStackDotNetSDK.Helpers.Constants.Currency.Naira, email = "email@email.com", reference = "reference", metadata = new PaystackRequestReAuthorizationMetadata() { custom_fields = new PaystackList<RequestReAuthorizationCustomField>() { new PaystackRequestReAuthorizationCustomField() { display_name = "display_name", value = "value", variable_name = "variable_name" } } } });
        }
 
 
#### Check Authorization

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
        protected async void CheckAuthorization()
        {
            var connectionInstance = new PaystackTransaction(Credential.Key);
            var response = await connectionInstance.CheckAuthorization("authorization_code", "email@email.com", 4000, PayStackDotNetSDK.Helpers.Constants.Currency.Naira);
        }
    


### Customers
add namespaces: 
using PayStackDotNetSDK.Methods.Customers;
using PayStackDotNetSDK.Models.Customers;

### Subaccounts
add namespaces: 
using PayStackDotNetSDK.Methods.Subaccounts;
using PayStackDotNetSDK.Models.SubAccounts;

### Plans
add namespaces: 
using PayStackDotNetSDK.Methods.Plans;
using PayStackDotNetSDK.Models.Plans;

### Subscriptions
add namespaces: 
using PayStackDotNetSDK.Methods.Subscriptions;
using PayStackDotNetSDK.Models.Subscriptions;

### Payment Pages
add namespaces: 
using PayStackDotNetSDK.Methods.Pages;
using PayStackDotNetSDK.Models.Pages;

### Invoices
add namespaces: 
using PayStackDotNetSDK.Methods.Invoices;
using PayStackDotNetSDK.Models.Invoices;

### Settlements
add namespaces: 
using PayStackDotNetSDK.Methods.Settlements;
using PayStackDotNetSDK.Models.Settlements;

### Transfers Recipients
add namespaces: 
using PayStackDotNetSDK.Methods.TransferRecipients;
using PayStackDotNetSDK.Models.TransferRecipients;

### Transfers
add namespaces: 
using PayStackDotNetSDK.Methods.Transfers;
using PayStackDotNetSDK.Models.Transfers;

### Transfers Control
add namespaces: 
using PayStackDotNetSDK.Methods.TransfersControls;
using PayStackDotNetSDK.Models.TransfersControls;

### Charge
add namespaces: 
using PayStackDotNetSDK.Methods.Charges;
using PayStackDotNetSDK.Models.Charges;

### Bulk Charges
add namespaces: 
using PayStackDotNetSDK.Methods.BulkCharges;
using PayStackDotNetSDK.Models.BulkCharges;

### Refunds
add namespaces: 
using PayStackDotNetSDK.Methods.Refunds;
using PayStackDotNetSDK.Models.Refunds;

### Control Panel
add namespaces: 
using PayStackDotNetSDK.Methods.ControlPanels;
using PayStackDotNetSDK.Models.ControlPanels;

### Verification
add namespaces: 
using PayStackDotNetSDK.Methods.Verifications;
using PayStackDotNetSDK.Models.Verifications;

### Banks
add namespaces: 
using PayStackDotNetSDK.Methods.Banks;
using PayStackDotNetSDK.Models.Banks;

		/// <summary>
        /// Get all Nigerian Banks on Paystack API
        /// </summary>
        protected async void GetAllBanks()
        {
            var connectionInstance = new PaystackListedBanks(Credential.Key);
            var response = await connectionInstance.ListBanks();
        }




