using AccountManagement.Domain.Models;
using AccountManagement.Infrastructure.dbcontext;
using Dapper;
using System.Data.SqlClient;

namespace AccountManagement.Infrastructure.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
    public class CustomerRepository : ICustomerRepository
    {

        private readonly string _connectionString;
        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {

            var command = AccountManagemetDbContext.GETALLCUSTOMERS;

            //var parameters = new { FileName = fileName, TenantId = tenantId };

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Customer>(command);

        }

        // Implement other methods for transaction repository as needed
    }
}