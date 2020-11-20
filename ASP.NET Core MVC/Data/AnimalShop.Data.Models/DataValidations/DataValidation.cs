namespace AnimalShop.Data.Models.DataValidations
{
    public class DataValidation
    {
        public const int NameMaxLength = 60;
        public const int DescriptionMaxLength = 3000;

        public static class User
        {
            public const int FirstNameMaxLength = 40;
            public const int LastNameMaxLength = 40;
            public const int AddressMaxLength = 100;
        }

    }
}
