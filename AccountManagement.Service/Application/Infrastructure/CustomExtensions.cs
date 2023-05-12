using AccountManagement.Service.Services;
using AccountManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Service.Application.Infrastructure
{
    public static class CustomExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITransactionServices, TransactionService>();

            return services;

        }
    }
}
