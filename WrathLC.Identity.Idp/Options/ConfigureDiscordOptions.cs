using Discord.OAuth2;
using Microsoft.Extensions.Options;

namespace WrathLC.Identity.Idp.Options;

public class ConfigureDiscordOptions : IConfigureOptions<DiscordOptions>
{
    private readonly IConfiguration _configuration;

    public ConfigureDiscordOptions(IConfiguration configuration)
        => _configuration = configuration;
    
    public void Configure(DiscordOptions options)
    {
        var discordConfigSection =
            _configuration.GetSection("Authentication:Discord");
        
        options.ClientId = discordConfigSection["ClientId"];
        options.ClientSecret = discordConfigSection["ClientSecret"];
        options.SaveTokens = true;
        options.Scope.Add("guilds");
    }
}