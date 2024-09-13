
using FinnanceControll.DAL.Repositories;
using FinnanceControll.Domain.Core.Workers;
using FinnanceControll.Domain.Interfaces.Repositories;
using FinnanceControll.Domain.Interfaces.Workers;
using Microsoft.Extensions.DependencyInjection;


namespace FinnanceControll.Infrastructure.Settings
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