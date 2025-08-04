using AlManalChickens.Domain.Enums;

namespace AlManalChickens.Domain.Common.Helpers.Enums
{
    public static class EnumHelper
    {
        public static string PaymentMethodName(PaymentMethod method, string lang)
        {
            return method switch
            {
                PaymentMethod.Wallet => lang == "ar" ? "محفظة" : "Wallet",
                PaymentMethod.Card => lang == "ar" ? "بطاقة بنكية" : "Card",
                _ => string.Empty
            };
        }
    }
}
