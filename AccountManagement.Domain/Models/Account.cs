using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AccountManagement.Domain.Models
{
    public class Account
    {
        [JsonPropertyName("AccountId")]
        public int AccountId { get; set; }

        [JsonPropertyName("CustomerId")]
        public int CustomerId { get; set; }

        [JsonPropertyName("Balance")]
        public decimal Balance { get; set; }

        // Navigation property for User
        public User User { get; set; }

        // Navigation property for AccountTransaction
        public ICollection<AccountTransaction> Transactions { get; set; }
    }
}
