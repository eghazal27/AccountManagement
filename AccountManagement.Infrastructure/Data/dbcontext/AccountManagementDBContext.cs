using AccountManagement.Domain.Models;
using AccountManagement.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

public class AccountManagementDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountTransaction> AccountTransactions { get; set; }

    public AccountManagementDbContext(DbContextOptions<AccountManagementDbContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("AccountManagement");

    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Set default schema (optional)
        modelBuilder.HasDefaultSchema("public");

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
            entity.HasKey(u => u.CustomerId);
            entity.Property(u => u.Name).IsRequired().HasMaxLength(255);
            entity.Property(u => u.LastName).IsRequired().HasMaxLength(255);
            entity.Property(u => u.Address).IsRequired().HasMaxLength(255);
            entity.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(255);
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(a => a.AccountId);
            entity.Property(a => a.CustomerId).IsRequired().HasMaxLength(255);
            entity.Property(a => a.Balance).IsRequired().HasColumnType("numeric(18, 2)");

            // Example of a relationship with User
            entity.HasOne(a => a.User)
                .WithMany(u => u.Accounts)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<AccountTransaction>(entity =>
        {
            entity.HasKey(t => t.TransactionId);
            entity.Property(t => t.AccountId).IsRequired().HasMaxLength(255);
            entity.Property(t => t.Amount).IsRequired().HasColumnType("numeric(18, 2)");
            entity.Property(t => t.TransactionDate).IsRequired();
            entity.Property(t => t.TransactionType).IsRequired();

            // Example of a relationship with Account
            entity.HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        

    }
}
