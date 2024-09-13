using FinanceControl.API.DataBase;
using FinanceControl.DAL.Repositories;
using FinanceControl.Domain.Core.Workers;
using FinanceControl.Domain.Interfaces.Repositories;
using FinanceControl.Domain.Interfaces.Workers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceControl.Bootstrapper;

public static class Startup
{
    public static void AddDataAccess(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<DataContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("FinanceControllDataBase"))
        );
    }
    public static void AddWorkers(this IServiceCollection services)
    {
        services.AddSingleton<IExpenseWorker, ExpenseWorker>();
    }
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IExpenseRepository, ExpenseRepository>();
    }
}
