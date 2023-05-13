using AccountManagement.Domain.DTOs;
using AccountManagement.Domain.Models;
using AccountManagement.Infrastructure.Data.Repositories;
using AccountManagement.Service.Excpetions;

namespace AccountManagement.Service.Services
{
    public interface ITransactionServices
    {
        User AddTransaction(string accountId, TransactionDto transactionDto);
        ICollection<AccountTransaction> GenerateTransactions(double ammount, string accountId);
    }

    public class TransactionService : ITransactionServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly IAccountRepository _accountRepository;
        public TransactionService(IUserRepository userRepository, 
                                    IAccountTransactionRepository accountTransactionRepository,
                                    IAccountRepository accountRepository)
        {
            _userRepository= userRepository;
            _accountTransactionRepository = accountTransactionRepository;
            _accountRepository = accountRepository;
        }

        public User AddTransaction(string accountId, TransactionDto transactionDto)
        {
            var user = _userRepository.GetByAccountId(accountId) ?? throw new AccountManagementException($"No user having account #{accountId}.");
            var account = user.Accounts.FirstOrDefault(a => a.AccountId == accountId) ?? throw new AccountManagementException($"Account #{accountId} not found.");
            var transaction = new AccountTransaction()
            {
                Amount = transactionDto.Amount,
                TransactionDate = DateTime.Now.ToUniversalTime(),
                TransactionId = Guid.NewGuid().ToString(),
                TransactionType = transactionDto.TransactionType,
                AccountId = accountId
            };

            account.Transactions.Add(transaction);

            // Update the account balance based on the transaction type
            if (transactionDto.TransactionType == TransactionType.Deposit)
            {
                account.Balance += transactionDto.Amount;
            }
            else if (transactionDto.TransactionType == TransactionType.Withdrawal)
            {
                account.Balance -= transactionDto.Amount;
            }

            _accountTransactionRepository.Add(transaction);
            _accountRepository.Update(account);

            return user;
        }

        public ICollection<AccountTransaction> GenerateTransactions(double ammount, string accountId)
        {
            return new List<AccountTransaction>()
                    {
                        new AccountTransaction() {
                            Amount = ammount,
                            TransactionDate =    DateTime.Now.ToUniversalTime(),
                            TransactionId    =   Guid.NewGuid().ToString(),
                            TransactionType = TransactionType.Deposit,
                            AccountId = accountId
                        }
                    };
        }
    }
}
