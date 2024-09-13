using FinanceControl.DAL.Interfaces;
using FinanceControl.Domain.Models.Business;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.API.DataBase;

public class DataContext : DbContext, IDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Expense> Expenses {get; set;}//=> Set<Expense>();
    public DbSet<Receive> Receives {get; set;}//=> Set<Receive>();
}
