using FinanceControl.Domain.Models.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FinanceControl.DAL.Interfaces;

public interface IDataContext
{
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Receive> Receives { get; set; }
    DatabaseFacade Database { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
