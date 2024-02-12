﻿using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Models.Response
{
    public class FinancialDocumentResponse
    {
        [JsonPropertyName("data")]
        public FinancialDocumentData Data { get; set; }

        [JsonPropertyName("company")]
        public CompanyResponse Company { get; set; }
    }
}