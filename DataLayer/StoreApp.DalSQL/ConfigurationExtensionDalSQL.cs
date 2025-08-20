using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StoreApp.Dal.Context;
using StoreApp.Dal.Repositories;

namespace StoreApp.DalSQL;
public static class ConfigurationExtensionDalSQL
{
    public static IServiceCollection AddConfigurationDalSQL(this IServiceCollection services, IConfiguration configuration)
    {
        string? migrationAssembly = typeof(ConfigurationExtensionDalSQL).Assembly.GetName().Name;
        if (string.IsNullOrEmpty(migrationAssembly))
        {
            throw new ArgumentException("Migration assembly name is not configured.");
        }
        string? connectionString = configuration.GetConnectionString("SQLServer");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException("Connection string 'SQLServer' is not configured.");
        }

        services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(
                connectionString,
                options =>
                {
                    options.MigrationsAssembly(migrationAssembly);
                }
            ).EnableSensitiveDataLogging()   // shows parameter values
           .LogTo(Console.WriteLine, LogLevel.Information)
        );
        services.AddTransient<ItemRepository>();
        services.AddTransient<UnitRepository>();
        services.AddTransient<LocationRepository>();
        services.AddTransient<LocationRowRepository>();
        services.AddTransient<PartyRepository>();
        services.AddTransient<BillRepository>();
        services.AddTransient<BillItemRepository>();
        services.AddTransient<DeliveryScheduleRepository>();

        return services;
    }
}
