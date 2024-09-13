

using FinnanceControll.Domain.Models.Business;
using Microsoft.EntityFrameworkCore;

namespace FinnanceControll.API.DataBase;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<Receive> Receives => Set<Receive>();

}
