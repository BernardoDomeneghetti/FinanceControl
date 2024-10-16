using FinanceControl.DAL.Entities;
using FinanceControl.Domain.Models.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FinanceControl.DAL.Interfaces;

public interface IDataContext
{
    DbSet<TransactionEntity> Transactions { get; set; }
    DbSet<ExpenseEntity> Expenses { get; set; }
    DbSet<ReceiveEntity> Receives { get; set; }
    DbSet<TransferEntity> Transfers { get; set; }
    DbSet<AccountEntity> Accounts { get; set; }
    DbSet<CategoryEntity> Categories { get; set; }
    DatabaseFacade Database { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
