using System.Text.Json.Serialization;

namespace AccountManagement.Domain.Models
{
    public class AccountTransaction
    {
        [JsonPropertyName("TransactionId")]
        public int TransactionId { get; set; }

        [JsonPropertyName("AccountId")]
        public int AccountId { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("TransactionDate")]
        public DateTime TransactionDate { get; set; }

        // Navigation property for Account
        public Account Account { get; set; }
    }
}
