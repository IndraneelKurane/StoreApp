using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StoreApp.Persister;
public static class ConfigurationExtensionPersister
{
    public static IServiceCollection AddConfigurationExtensionPersister(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<UnitPersister>();
        services.AddTransient<LocationRowPersister>();
        services.AddTransient<LocationPersister>();
        services.AddTransient<ItemPersister>();
        services.AddTransient<PartyPersister>();
        services.AddTransient<BillPersister>();
        services.AddTransient<BillItemPersister>();
        services.AddTransient<DeliverySchedulePersister>();

        return services;
    }
}
