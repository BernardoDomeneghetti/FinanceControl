using FinnanceControll.Core.Workers;
using FinnanceControll.Interfaces.Repositories;
using FinnanceControll.Interfaces.Workers;
using FinnanceControll.Repositories;

namespace FinnanceControll.Settings
{
    public static class ServiceCollectionExtensions
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