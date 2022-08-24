using Discord.OAuth2;
using Microsoft.Extensions.Options;
using WrathLC.Identity.Idp.Options;

namespace WrathLC.Identity.Idp.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddOptionsConfigurations(this IServiceCollection services)
    {
        services
            .AddTransient<IConfigureOptions<DiscordOptions>, ConfigureDiscordOptions>();
    }
}