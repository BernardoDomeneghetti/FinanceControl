using FinanceControl.API.DataBase;
using FinanceControl.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;


namespace FinanceControl.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var services = builder.Services;
        services.AddControllers();

        var teste = builder.Configuration;
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        #region CustomInjection

        services.AddDbContext<DataContext>(
                options=> options.UseSqlServer(builder.Configuration.GetConnectionString("FinanceControllDataBase"))
            );
            
        services.AddWorkers();
        services.AddRepositories();

        #endregion CustomInjection

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
}