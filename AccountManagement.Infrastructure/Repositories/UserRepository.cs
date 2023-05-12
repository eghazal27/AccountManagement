using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.Data.Repositories
{
    public interface IUserRepository
    {
        User GetById(string id);
        User GetByAccountId(string accountId);
        void Add(User user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AccountManagementDbContext _context;

        public UserRepository(AccountManagementDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context = context;
        }

        public User GetById(string id)
        {
            return _context.Users
                .Include(u => u.Accounts)
                    .ThenInclude(a => a.Transactions)
                .FirstOrDefault(u => u.CustomerId == id);
        }

        public User GetByAccountId(string accountId)
        {
            return _context.Users.FirstOrDefault(u => u.Accounts.Any(a => a.AccountId == accountId));
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

    }
}
