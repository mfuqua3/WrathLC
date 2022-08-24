using Discord;
using Discord.Rest;
using Microsoft.Extensions.DependencyInjection;

namespace WrathLc.Common.Utilities.Discord;

public static class DiscordServicesRegistrar
{
    public static void AddDiscord(this IServiceCollection services)
    {
        services.AddSingleton<IDiscordClientFactory, DiscordClientFactory>();
        services.AddScoped<IDiscordClient, DiscordRestClient>();
    }
}