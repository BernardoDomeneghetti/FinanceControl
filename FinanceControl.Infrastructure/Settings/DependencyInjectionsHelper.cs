
using FinanceControl.DAL.Repositories;
using FinanceControl.Domain.Core.Workers;
using FinanceControl.Domain.Interfaces.Repositories;
using FinanceControl.Domain.Interfaces.Workers;
using Microsoft.Extensions.DependencyInjection;


namespace FinanceControl.Infrastructure.Settings
{
    public static class DependencyInjectionsHelper
    {
        public static void AddWorkers(this IServiceCollection services)
        {
            services.AddSingleton<IExpenseWorker, ExpenseWorker>();
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IExpenseRepository, ExpenseRepository>();
        }
    }
}