using Banking.data.Entitiy;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Banking.data
{
    public class BankingDbContext : IdentityDbContext<CustomUser>
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>(title =>
            {
                title.Property(t => t.Id).ValueGeneratedOnAdd();//2000000
            });
            modelBuilder.Entity<Account>(title =>
            {
                title.Property(t => t.Id).ValueGeneratedOnAdd();//1999981010001000
            });
            modelBuilder.Entity<Transaction>(title =>
            {
                title.Property(t => t.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Customer>()
                .HasMany(a => a.Accounts)
                .WithOne(c => c.Customer);

            modelBuilder.Entity<Account>()
               .HasOne(a => a.Customer)
               .WithMany(c => c.Accounts);

            modelBuilder.Entity<Transaction>()
               .HasOne(a => a.AccountFrom)
               .WithMany(t => t.TransactionsOut);
            modelBuilder.Entity<Transaction>()
              .HasOne(a => a.AccountTo)
              .WithMany(t => t.TransactionsIn);

        }
    }
}
