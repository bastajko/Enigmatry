using System.Security.Cryptography;
using System.Text;

namespace EnigmatryFinancial.Utils
{
    public static class Util
    {
        private static bool isDevEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
        public static bool IsDevelopmentEnvironment()
        {
            return isDevEnvironment;
        }

        public static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute hash from input string.
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string representation.
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convert each byte to a hexadecimal string.
                }
                return builder.ToString();
            }
        }
    }
}
