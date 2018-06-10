namespace PayStackDotNetSDK.Helpers
{
    public class Constants
    {
        public const string PaystackBaseURL = "https://api.paystack.co/";
        public const string ContentTypeHeaderJson = "application/json";
        public const string AuthorizationHeaderType = "Bearer";

        public class Transaction
        {
            public class Status
            {
                public const string Failed = "failed";
                public const string Success = "success";
                public const string Abandoned = "abandoned";
            }
        }
        public class Transfer
        {
            public class Source
            {
                public const string Balance = "balance";
            }
        }
        public class Verification
        {
            public class Type
            {
                public const string Truecaller = "truecaller";
            }
        }
        
        public class TransferControl
        {
            public class ResendOTPforTransfer
            {
                public class Reasons
                {
                    public const string Disable_otp = "disable_otp";
                    public const string Transfer = "transfer";
                }
            }
        }
        public class Invoice
        {
            public class Status
            {
                public const string Failed = "failed";
                public const string Success = "success";
                public const string Abandoned = "abandoned";
            }
        }
        public class Currency
        {
            public const string Naira = "NGN";
        }
        public class BankType
        {
            public const string Nuban = "nuban";
        }
        
        public class CustomerActions
        {
            public const string Allow = "allow";
            public const string Deny = "deny";
        }
        public class SubAccount
        {
            /// <summary>
            /// Any of auto, weekly, monthly, manual. Auto means payout is T+1 and manual means payout to the subaccount should only be made when requested.
            /// </summary>
            public class AccountSchedule
            {
                public const string Auto = "auto";
                public const string Weekly = "weekly";
                public const string Monthly = "monthly";
                public const string Manual = "manual";
            }
        }
    }
}
