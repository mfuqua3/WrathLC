using Discord.Rest;

namespace WrathLC.Utility.Common.Discord;

public interface IDiscordClientFactory
{
    Task<DiscordRestClient> CreateNewAsync(DiscordUserCredentials credentials);
}