using AccountManagement.Models;

namespace AccountManagement.Service.Services
{
    public interface IAccountService
    {
        Account GenerateAccount(UserCreationDto userCreationDto, string accountId);
    }

    public class AccountService : IAccountService
    {
        private readonly ITransactionServices _transactionServices;
        public AccountService(ITransactionServices transactionServices)
        {
            _transactionServices = transactionServices;
        }
        public Account GenerateAccount(UserCreationDto userCreationDto, string accountId)
        {
            return new Account()
            {
                CustomerId = userCreationDto.CustomerId,
                AccountId = accountId,
                //Balance set as initial credit for now. 
                //It can be updated to be an aggregation of transactions for data integrity
                Balance = userCreationDto.InitialCredit,
                Transactions = _transactionServices.GenerateTransactions(userCreationDto.InitialCredit, accountId)
            };
        }
    }
}
