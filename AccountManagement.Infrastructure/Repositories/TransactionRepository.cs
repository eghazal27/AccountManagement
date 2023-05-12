using AccountManagement.Domain.Models;
using AccountManagement.Infrastructure.dbcontext;
using Dapper;
using System.Data.SqlClient;

namespace AccountManagement.Infrastructure.Data.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
    }
    public class TransactionRepository : ITransactionRepository
    {

        private readonly string _connectionString;
        public TransactionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {

            var command = AccountManagemetDbContext.GETALLTRANSACTIONS;

            //var parameters = new { FileName = fileName, TenantId = tenantId };

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Transaction>(command);

        }

        // Implement other methods for transaction repository as needed
    }
}