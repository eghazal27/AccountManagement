using AccountManagement.Domain.Models;
using AccountManagement.Infrastructure.Data.dbcontext;

namespace AccountManagement.Infrastructure.Data.Repositories
{
    public interface IUserRepository
    {
        User GetById(int id);
        List<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AccountManagementDBContext _context;

        public UserRepository(AccountManagementDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context = context;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
