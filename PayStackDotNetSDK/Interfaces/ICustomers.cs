using PayStackDotNetSDK.Models.Customers;
using System.Threading.Tasks;


namespace PayStackDotNetSDK.Interfaces
{
    public interface ICustomers
    {
        Task<CustomerCreationResponse> CreateCustomer(string email);
        Task<CustomerCreationResponse> CreateCustomer(CustomersModel customer);
        Task<CustomerListResponse> ListCustomers();
        Task<CustomerListResponse> ListCustomers(CustomersListRequestModel requestModel);
        Task<CustomerCreationResponse> FetchCustomer(int id_or_customer_code);
        Task<CustomerCreationResponse> FetchCustomer(int id_or_customer_code, CustomerFetchRequestModel requestModel);
        Task<CustomerCreationResponse> UpdateCustomer(int id_or_customer_code, CustomersModel customer);
        Task<CustomerCreationResponse> White_BlacklistCustomer(string customer_email_or_id_or_code, string risk_action);
        Task<CustomerCreationResponse> DeactivateCustomerAuthorization(string authorization_code);
    }
}
