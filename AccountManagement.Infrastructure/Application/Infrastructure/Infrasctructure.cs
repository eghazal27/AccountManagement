using AccountManagement.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DbContextExtensions
{
    /// <summary>
    /// Register RegisterDBContext and UserRepository So Main application doesn't know about entity framework.
    /// Following repository design pattern
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection RegisterDBContextAndRepos(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<AccountManagementDbContext>(options =>
        //options.UseNpgsql(configuration["ConnectionStrings:DomainDatabase"]));

        services.AddDbContext<AccountManagementDbContext>(options =>
            options.UseInMemoryDatabase("AccountManagement"));


        // Register repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IAccountTransactionRepository, AccountTransactionRepository>();

        return services;
    }

    public static void MigrateDBDContext(this IApplicationBuilder app)
    {
        // Apply pending migrations and update the database schema
        using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetService<AccountManagementDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
