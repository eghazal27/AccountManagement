using AccountManagement.Domain.Models;
using AccountManagement.Infrastructure.dbcontext;
using Dapper;
using Npgsql;

namespace AccountManagement.Infrastructure.Data.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
    }
    public class AccountRepository : IAccountRepository
    {

        private readonly string _connectionString;
        public AccountRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            var command = AccountManagemetDbContext.GETALLACCOUNTS;

            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            return await connection.QueryAsync<Account>(command);

        }

    }
}