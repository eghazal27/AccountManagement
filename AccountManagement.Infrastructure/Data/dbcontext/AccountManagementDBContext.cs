using AccountManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.Data.dbcontext
{
    public class AccountManagementDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }

        public AccountManagementDBContext(DbContextOptions<AccountManagementDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SQL_Latin1_General_CP1_CI_AS added to configure postgres case insensitive

            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");


            base.OnModelCreating(modelBuilder);

            // Set default schema (optional)
            modelBuilder.HasDefaultSchema("public");

            // Apply entity configurations from assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountManagementDBContext).Assembly);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users"); // Specify table name
                entity.HasKey(u => u.CustomerId);
                entity.Property(u => u.CustomerId).HasColumnName("customerid").IsRequired().HasMaxLength(50);
                entity.Property(u => u.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
                entity.Property(u => u.Surname).HasColumnName("surname").IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts"); // Specify table name
                entity.HasKey(a => a.AccountId);
                entity.Property(a => a.AccountId).HasColumnName("accountid");
                entity.Property(a => a.CustomerId).HasColumnName("customerid").IsRequired();
                entity.Property(a => a.Balance).HasColumnName("balance").IsRequired().HasColumnType("decimal(18, 2)");

                // Example of a relationship with User
                entity.HasOne(a => a.User)
                    .WithMany(u => u.Accounts)
                    .HasForeignKey(a => a.CustomerId);
            });

            modelBuilder.Entity<AccountTransaction>(entity =>
            {
                entity.ToTable("accounttransactions"); // Specify table name
                entity.HasKey(t => t.TransactionId);
                entity.Property(t => t.TransactionId).HasColumnName("transactionid");
                entity.Property(t => t.AccountId).HasColumnName("accountid").IsRequired().HasColumnType("decimal(18, 2)");
                entity.Property(t => t.Amount).HasColumnName("ammount").IsRequired().HasColumnType("decimal(18, 2)");
                entity.Property(t => t.TransactionDate).HasColumnName("transactiondate").IsRequired();

                // Example of a relationship with Account
                entity.HasOne(t => t.Account)
                    .WithMany(a => a.Transactions)
                    .HasForeignKey(t => t.AccountId);
            });

            //SeedData.Initialize(this);
        }

    }
}
