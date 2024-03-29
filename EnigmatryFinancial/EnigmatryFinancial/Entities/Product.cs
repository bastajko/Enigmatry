﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [JsonPropertyName("productCode")]
        public required string ProductCode { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }
}
