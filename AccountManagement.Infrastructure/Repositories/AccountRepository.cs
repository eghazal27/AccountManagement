using AccountManagement.Domain.Models;
using AccountManagement.Infrastructure.Data.dbcontext;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.Data.Repositories
{
    public interface IAccountRepository
    {
        void Add(Account account);
        void Delete(Account account);
        List<Account> GetAll();
        Task<List<Account>> GetAllAccountsAsync();
        Account GetById(int id);
        Task<Account> GetUserByIdAsync(int id);
        void Update(Account account);
    }

    public class AccountRepository : IAccountRepository
    {
        private readonly AccountManagementDBContext _context;

        public AccountRepository(AccountManagementDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context = context;
        }

        public Account GetById(int id)
        {
            return _context.Accounts
                .Include(a => a.User)
                .Include(a => a.Transactions)
                .FirstOrDefault(a => a.AccountId == id);
        }
        public async Task<Account> GetUserByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }
        public List<Account> GetAll()
        {
            return _context.Accounts
                .Include(a => a.User)
                .Include(a => a.Transactions)

                .ToList();
        }

        public void Add(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public void Update(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
        }

        public void Delete(Account account)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }
    }
}
