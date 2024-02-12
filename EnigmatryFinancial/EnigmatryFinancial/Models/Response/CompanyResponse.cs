using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Models.Response
{
    public class CompanyResponse
    {
        [JsonPropertyName("registrationNumber")]
        public string RegistrationNumber { get; set; }

        [JsonPropertyName("companyType")]
        public string CompanyType { get; set; }
    }
}
