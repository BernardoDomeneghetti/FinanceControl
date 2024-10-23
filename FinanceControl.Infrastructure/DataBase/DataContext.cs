using FinanceControl.DAL.Interfaces;
using FinanceControl.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Infrastrutcture.DataBase
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<ExpenseEntity> Expenses { get; set; }
        public DbSet<ReceiveEntity> Receives { get; set; }
        public DbSet<TransferEntity> Transfers { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionEntity>()
                .HasOne(t => t.OriginAccount)
                .WithMany()
                .HasForeignKey(t => t.OriginAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExpenseEntity>()
                .HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<ReceiveEntity>()
                .HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<TransferEntity>()
                .HasOne(e => e.TargetAccount)
                .WithMany()
                .HasForeignKey(e => e.TargetAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
}