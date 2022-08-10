using Microsoft.Extensions.DependencyInjection;
using WrathLc.Core.Managers.Manager.Components;

namespace WrathLc.Core.Managers;

public static class CoreServicesRegistrar
{
    public static void AddWrathLcCore(this IServiceCollection services)
    {
        services.AddScoped<IDiscordManager, DiscordManager>();
    }
}