using FinanceControl.DAL.Interfaces;
using FinanceControl.Infrastrutcture.DataBase;
using Microsoft.EntityFrameworkCore;
using FinanceControl.DAL.Repositories;
using FinanceControl.Domain.Interfaces.Workers;
using FinanceControl.Domain.Interfaces.Repositories;
using FinanceControl.Domain.Core.Workers;
using FinanceControl.DAL.Entities;
using FinanceControl.API.ControllerDtos;

namespace FinanceControl.Configuration;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var services = builder.Services;
        
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper(typeof(ControllerDtosMappingProfile));

        ConfigureServices(services, builder);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
    public static void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {

        #region DataAccess
        services.AddDbContext<IDataContext, DataContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("FinanceControllDataBase"))
        );

        services.AddScoped<IDataContext, DataContext>();
        #endregion

        #region Workers
        services.AddScoped<IExpenseWorker, ExpenseWorker>();
        services.AddScoped<IReceiveWorker, ReceiveWorker>();
        services.AddScoped<ITransferWorker, TransferWorker>();
        #endregion

        #region Repositories
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IReceiveRepository, ReceiveRepository>();
        services.AddScoped<ITransferRepository, TransferRepository>();
        #endregion

        #region Mapper
        services.AddAutoMapper(typeof(DomainToEntityMappingProfile));
        #endregion
    }
}