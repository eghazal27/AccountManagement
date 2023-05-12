using System.Text.Json.Serialization;

namespace AccountManagement.Domain.Models
{
    public class AccountTransaction
    {
        public string TransactionId { get; set; }
        public string AccountId { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public Account Account { get; set; }
    }

    public enum TransactionType
    {
        Credit,
        Debit
    }
}
