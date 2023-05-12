using AccountManagement.Domain.Models;

public class User
{
    public string CustomerId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Account> Accounts { get; set; }
}