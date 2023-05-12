using AccountManagement.Infrastructure.Data.Repositories;
using AccountManagement.Service.Services;

namespace AccountManagement.API.Application.Infrastructure
{
    public static class CustomExtensions
    {
        public static IServiceCollection RegisterRepos(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["ConnectionStrings:DomainDatabase"];
            services.AddSingleton<ICustomerRepository>(provider => new CustomerRepository(connectionString));
            services.AddSingleton<IAccountRepository>(provider => new AccountRepository(connectionString));
            services.AddSingleton<ITransactionRepository>(provider => new TransactionRepository(connectionString));

            return services;

        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();

            return services;

        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Account Management API v1");
            });
        }

    }
}
