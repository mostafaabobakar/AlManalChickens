namespace AlManalChickens.Domain.Constants
{
    public static class RegEx
    {
        public const string Iban = @"^SA\d{2}[0-9]{20}$";
        public const string Email = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]{2,}@[a-zA-Z0-9]+(?:[a-zA-Z0-9-]*[a-zA-Z0-9]\.)+[a-zA-Z]{2,}$";
        public const string BankAccountNo = @"^\d{18}$";
        public const string SaudiPhone = @"^(5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$";
        public const string PositiveIntegers = @"^[1-9][0-9]*$";
        public const string PositiveFloating = @"^[1-9][0-9]*([\.][0-9][0-9]{0,2})?$|^$|^\s*$";
        public const string Percentage = @"^(?:[1-9][0-9]?(?:\.\d{1,2})?|0?\.\d{1,2}|100)$";
    }
}