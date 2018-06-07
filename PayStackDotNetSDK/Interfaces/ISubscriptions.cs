using PayStackDotNetSDK.Models.Subscription;
using System.Threading.Tasks;


namespace PayStackDotNetSDK.Interfaces
{
    public interface ISubscriptions
    {
        Task<SubscriptionModel> CreateSubscription(string customerEmail, string planCode);
        Task<SubscriptionModel> CreateSubscription(string customerEmail, string planCode, string authorization, string start_date);
        Task<SubscriptionModel> ListSubscription();
        Task<SubscriptionModel> ListSubscription(SubscriptionListRequestModel requestModel);
        Task<SubscriptionModel> DisableSubscription(string code, string token);
        Task<SubscriptionModel> EnableSubscription(string code, string token);
        Task<SubscriptionModel> FetchSubscription(string id_or_subscription_code);
    }
}
