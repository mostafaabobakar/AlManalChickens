namespace AlManalChickens.Domain.Constants
{
    public class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;


        public static class OrderApi
        {
            public const string ListcurrentOrderForProvider = Base + "/ListcurrentOrderForProvider";
            public const string ListAdsNewOrderForProvider = Base + "/ListAdsNewOrderForProvider";
            public const string ListEndedOrderForProvider = Base + "/ListEndedOrderForProvider";
            public const string GetOrderInfoForProvider = Base + "/GetOrderInfoForProvider";

            public const string ListcurrentOrderForUser = Base + "/ListcurrentOrderForUser";
            public const string ListNewOrderForUser = Base + "/ListNewOrderForUser";
            public const string ListEndedOrderForUser = Base + "/ListEndedOrderForUser";
            public const string GetOrderInfoForUser = Base + "/GetOrderInfoForUser";

            public const string UseCopon = Base + "/UseCopon";

        }

        public static class Identity
        {

            public const string GetDataOfProvider = Base + "/GetDataOfProvider";
            public const string UpdateAsyncDataDelegt = Base + "/UpdateAsyncDataDelegt";
            public const string RegisterClient = Base + "/RegisterClient";
            public const string RegisterDeleget = Base + "/RegisterDeleget";
            public const string RemoveNotiyByIdAsync = Base + "/RemoveNotiyByIdAsync";
            public const string RemoveAllNotify = Base + "/RemoveAllNotify";
            public const string UpdateForWebsiteAsyncDataUser = Base + "/UpdateForWebsiteAsyncDataUser";
            public const string RemoveAccount = Base + "/RemoveAccount";
            // client
            public const string ResendCode = Base + "/ResendCode";
            public const string ListOfNotifyUser = Base + "/ListOfNotifyUser";
            public const string ChangeReciveOrder = Base + "/ChangeReciveOrder";
            public const string UpdateDataUser = Base + "/UpdateDataUser";
            public const string ChangePasswordByCode = Base + "/ChangePasswordByCode";
            public const string Login = Base + "/Login";
            public const string ForgetPassword = Base + "/ForgetPassword";
            public const string Register = Base + "/Register";
            public const string ListCity = Base + "/ListCity";
            public const string ConfirmCodeRegister = Base + "/ConfirmCodeRegister";
            public const string ResetPassword = Base + "/ResetPassword";
            public const string ChangePassward = Base + "/ChangePassword";
            public const string GetDataOfUser = Base + "/GetDataOfUser";
            public const string ConvertloyaltytoWallet = Base + "/ConvertloyaltytoWallet";
            public const string ChangePhone = Base + "/ChangePhone";
            public const string ConfirmCodeForNewPhone = Base + "/ConfirmCodeForNewPhone";
            public const string ConfirmCode = Base + "/ConfirmCode";

            // addtional services from user 
            public const string ChangeLanguage = Base + "/ChangeLanguage";
            public const string ChangeNotify = Base + "/ChangeNotify";
            public const string Logout = Base + "/Logout";
            public const string VerifyName = Base + "/VerifyName";
        }

        public static class Chat
        {
            public const string ListMessagesUser = Base + "/ListMessagesUser";
            public const string UploadNewFile = Base + "/UploadNewFile";
            public const string ListUsersMyChat = Base + "/ListUsersMyChat";
        }
        public static class More
        {
            public const string AboutUs = Base + "/AboutUs";
            public const string CommonQuestions = Base + "/CommonQuestions";
            public const string TermsAndConditions = Base + "/TermsAndConditions";
            public const string ContactWithus = Base + "/ContactWithUs";
        }


    }
}
