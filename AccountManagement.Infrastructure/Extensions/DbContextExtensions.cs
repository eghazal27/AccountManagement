using AccountManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.Extensions
{
    internal static class DbContextExtensions
    {
        internal static  void SeedData(this DbContext dbContext)
        {
            dbContext.Set<User>().AddRange(
                new User
                {
                    CustomerId = "1",
                    Name = "John",
                    LastName = "Doe",
                    Address = "123 Main St",
                    PhoneNumber = "555-1234"
                },
                new User
                {
                    CustomerId = "2",
                    Name = "Jane",
                    LastName = "Smith",
                    Address = "456 Elm St",
                    PhoneNumber = "555-5678"
                }
            );

            dbContext.Set<Account>().AddRange(
                new Account
                {
                    AccountId = "1",
                    CustomerId = "1",
                    Balance = 1000
                },
                new Account
                {
                    AccountId = "2",
                    CustomerId = "2",
                    Balance = 500
                }
            );

            dbContext.Set<AccountTransaction>().AddRange(
                new AccountTransaction
                {
                    TransactionId = "1",
                    AccountId = "1",
                    Amount = 100,
                    TransactionDate = DateTime.Now,
                    TransactionType = TransactionType.Deposit
                },
                new AccountTransaction
                {
                    TransactionId = "2",
                    AccountId = "1",
                    Amount = -50,
                    TransactionDate = DateTime.Now,
                    TransactionType = TransactionType.Withdrawal
                },
                new AccountTransaction
                {
                    TransactionId = "3",
                    AccountId = "2",
                    Amount = 200,
                    TransactionDate = DateTime.Now,
                    TransactionType = TransactionType.Deposit
                }
            );
            dbContext.SaveChanges();
        }
    }
}
