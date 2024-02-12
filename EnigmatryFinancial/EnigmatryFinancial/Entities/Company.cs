using EnigmatryFinancial.Utils;
using System.Data;
using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Entities
{
    public class Company : BaseEntity
    {
        public string RegistrationNumber { get; set; }

        [JsonConverter(typeof(CompanyTypeConverter))]
        public CompanyTypeEnum CompanyType { get; set; }
        public string Industry { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
    }
}
