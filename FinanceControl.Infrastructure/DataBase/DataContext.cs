using FinanceControl.DAL.Interfaces;
using FinanceControl.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using FinanceControl.Domain.Models.Business;

namespace FinanceControl.API.DataBase
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
    }
}