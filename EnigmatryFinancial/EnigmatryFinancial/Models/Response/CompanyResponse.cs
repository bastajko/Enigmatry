using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Models.Response
{
    public class CompanyResponse
    {
        [JsonPropertyName("registrationNumber")]
        public string RegistrationNumber { get; set; } = string.Empty;

        [JsonPropertyName("companyType")]
        public string CompanyType { get; set; } = string.Empty;
    }
}
