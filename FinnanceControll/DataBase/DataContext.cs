using FinnanceControll.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinnanceControll.DataBase;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<Receive> Receives => Set<Receive>();

}
