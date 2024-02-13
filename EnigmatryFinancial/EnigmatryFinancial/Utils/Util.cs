namespace EnigmatryFinancial.Utils
{
    public static class Util
    {
        private static bool isDevEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
        public static bool IsDevelopmentEnvironment()
        {
            return isDevEnvironment;
        }
    }
}
