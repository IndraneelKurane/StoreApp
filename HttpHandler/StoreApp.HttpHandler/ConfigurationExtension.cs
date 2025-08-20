using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StoreApp.HttpHandler;
public static class ConfigurationExtension
{
    public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        services.AddScoped<ItemHttpService>();
        services.AddScoped<UnitHttpService>();
        services.AddScoped<LocationHttpService>();
        services.AddScoped<LocationRowHttpService>();
        services.AddScoped<PartyHttpService>();
        services.AddScoped<BillHttpService>();
        services.AddScoped<DeliveryScheduleHttpService>();
        return services;
    }
}
