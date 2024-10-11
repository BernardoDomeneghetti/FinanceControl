using FinanceControl.API.DataBase;
using FinanceControl.DAL.Interfaces;
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
        services.AddDbContext<IDataContext, DataContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("FinanceControllDataBase"))
        );
    }
    public static void AddWorkers(this IServiceCollection services)
    {
        services.AddSingleton<IExpenseWorker, ExpenseWorker>();
        services.AddSingleton<IReceiveWorker, ReceiveWorker>();
        services.AddSingleton<ITransferWorker, TransferWorker>();
    }
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IExpenseRepository, ExpenseRepository>();
        services.AddSingleton<IReceiveRepository, ReceiveRepository>();
        services.AddSingleton<ITransferRepository, TransferRepository>();

    }
}
