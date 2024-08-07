using FinnanceControll.Core.Workers;
using FinnanceControll.Interfaces.Workers;

namespace FinnanceControll.Settings
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWorkers(this IServiceCollection services)
        {
            services.AddSingleton<IExpenseWorker, ExpenseWorker>();
        }
    }
}