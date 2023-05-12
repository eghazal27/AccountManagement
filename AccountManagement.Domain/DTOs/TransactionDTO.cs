using AccountManagement.Domain.Models;

namespace AccountManagement.Domain.DTOs
{
    public class TransactionDto
    {
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
    }

}
