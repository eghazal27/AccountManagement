using AccountManagement.Domain.Models;
using AccountManagement.Infrastructure.Data.Repositories;

namespace AccountManagement.Service.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
    }

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {

            return await _accountRepository.GetAllAccountsAsync();

        }
    }
}
