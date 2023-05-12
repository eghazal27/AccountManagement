using AccountManagement.Domain.Models;
using AccountManagement.Infrastructure.Data.dbcontext;

namespace AccountManagement.Infrastructure.Data.Repositories
{
    public interface IAccountTransactionRepository
    {
        AccountTransaction GetById(int id);
        List<AccountTransaction> GetAll();
        void Add(AccountTransaction transaction);
        void Update(AccountTransaction transaction);
    }

    public class AccountTransactionRepository : IAccountTransactionRepository
    {
        private readonly AccountManagementDBContext _context;

        public AccountTransactionRepository(AccountManagementDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context = context;
        }

        public AccountTransaction GetById(int id)
        {
            return _context.AccountTransactions.Find(id);
        }

        public List<AccountTransaction> GetAll()
        {
            return _context.AccountTransactions.ToList();
        }

        public void Add(AccountTransaction transaction)
        {
            _context.AccountTransactions.Add(transaction);
            _context.SaveChanges();
        }

        public void Update(AccountTransaction transaction)
        {
            _context.AccountTransactions.Update(transaction);
            _context.SaveChanges();
        }
    }
}
