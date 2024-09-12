
using FinnanceControll.DAL.DataBase;
using FinnanceControll.DAL.Repositories;
using FinnanceControll.Domain.Core.Workers;
using FinnanceControll.Domain.Interfaces.Repositories;
using FinnanceControll.Domain.Interfaces.Workers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace FinnanceControll.Startup.Settings
{
    public static class DependencyInjectionsHelper
    {
        public static void AddOrm(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<DataContext>(
                options=> options.UseSqlServer(builder.Configuration.GetConnectionString("FinanceControllDataBase"))
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
}