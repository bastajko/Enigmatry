using System.Text.Json.Serialization;
using System.Text.Json;
using EnigmatryFinancial.Entities.Enums;

namespace EnigmatryFinancial.Utils
{
    public class CompanyTypeConverter : JsonConverter<CompanyTypeEnum>
    {
        public override CompanyTypeEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            string enumValue = reader.GetString() ?? string.Empty;
            if (Enum.TryParse<CompanyTypeEnum>(enumValue, true, out var status))
            {
                return status;
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, CompanyTypeEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString().ToLower());
        }
    }

}
