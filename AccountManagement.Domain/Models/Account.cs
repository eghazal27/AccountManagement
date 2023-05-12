using AccountManagement.Domain.Models;

public class Account
{
    public string AccountId { get; set; }
    public string CustomerId { get; set; }
    public double Balance { get; set; }
    public User User { get; set; }
    public ICollection<AccountTransaction> Transactions { get; set; }
}