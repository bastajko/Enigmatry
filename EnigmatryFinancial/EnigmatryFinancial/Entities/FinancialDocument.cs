﻿using EnigmatryFinancial.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EnigmatryFinancial.Models
{
    public class FinancialDocument : BaseEntity
    {
        [Required]
        [JsonPropertyName("tenantId")]
        public Guid TenantId { get; set; }

        [Required]
        [JsonPropertyName("clientId")]
        public int ClientId { get; set; }

        // TODO: Revisit this
        public string Data { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; } = string.Empty;

        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonIgnore]
        [ForeignKey("TenantId")]
        public virtual required Tenant Tenant { get; set; }

        [JsonIgnore]
        [ForeignKey("ClientId")]
        public virtual required Client Client { get; set; }

        // Transactions navigation property
        public ICollection<Transaction> Transactions { get; set; }
    }
}
