using Microsoft.Extensions.DependencyInjection;
using StoreApp.WPF.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Index = StoreApp.WPF.UserControls.Index;

namespace StoreApp.WPF.ViewModels;
public static class ConfigurationExtensionViewModels
{
    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        // Register ViewModels here
        services.AddTransient<ItemIndexViewModel>();
        // Register UserControls
        services.AddTransient<Index>();
        //services.AddTransient<ItemViewModel>();
        //services.AddTransient<MainViewModel>();
        //services.AddTransient<SettingsViewModel>();
        // Add other ViewModels as needed
        return services;
    }
}
