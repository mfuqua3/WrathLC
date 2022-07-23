using Discord;
using Discord.Rest;

namespace WrathLc.Common.Utilities.Discord;

public interface IDiscordClientFactory
{
    Task<DiscordRestClient> CreateNewAsync(DiscordUserCredentials credentials);
}