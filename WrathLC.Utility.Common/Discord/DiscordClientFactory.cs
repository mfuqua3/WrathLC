﻿using Discord;
using Discord.Rest;

namespace WrathLC.Utility.Common.Discord;

internal class DiscordClientFactory : IDiscordClientFactory
{
    public async Task<DiscordRestClient> CreateNewAsync(DiscordUserCredentials credentials)
    {
        var restClient = new DiscordRestClient();
        await restClient.LoginAsync(TokenType.Bearer, credentials.AccessToken);
        return restClient;
    }
}