using Discord;
using Discord.Rest;
using Microsoft.EntityFrameworkCore;
using WrathLc.Common.Utilities.Discord;
using WrathLc.Core.Data.Requests;
using WrathLc.Core.ResourceAccess;
using WrathLc.Core.ResourceAccess.Entities;

namespace WrathLc.Core.Managers.Manager.Components;

public class DiscordManager : IDiscordManager
{
    private readonly IDiscordClientFactory _discordClientFactory;
    private readonly WrathLcDbContext _dbContext;

    public DiscordManager(IDiscordClientFactory discordClientFactory, WrathLcDbContext dbContext)
    {
        _discordClientFactory = discordClientFactory;
        _dbContext = dbContext;
    }

    async Task IDiscordManager.SyncUserAsync(SyncUserRequest request)
    {
        var client = await _discordClientFactory.CreateNewAsync(new DiscordUserCredentials
            { AccessToken = request.DiscordAccessToken });
        var guilds = (await client.GetGuildSummariesAsync().ToListAsync())
            .SelectMany(x => x)
            .Cast<IUserGuild>().ToList();
        var guildIds = guilds.Select(g => g.Id).ToList();
        var knownGuilds = await _dbContext.DiscordServers
            .Where(x => guildIds.Contains(x.Id))
            .Select(x => x.Id)
            .ToListAsync();
        var toAdd = guilds.Where(x => !knownGuilds.Contains(x.Id));
        var servers = toAdd.Select(x => new DiscordServer
        {
            Id = x.Id,
            Name = x.Name
        });
        await _dbContext.AddRangeAsync(servers);
        var existingServerUsers = await _dbContext.DiscordServerUsers
            .Where(x => x.UserId == request.UserId && guildIds.Contains(x.DiscordServerId))
            .Select(x => x.DiscordServerId)
            .ToListAsync();
        var toDeleteServerUsers = await _dbContext.DiscordServerUsers
            .Where(x => x.UserId == request.UserId && !guildIds.Contains(x.DiscordServerId)).ToListAsync();
        _dbContext.DiscordServerUsers.RemoveRange(toDeleteServerUsers);
        var toAddServerUsers = guildIds.Except(existingServerUsers).Select(x => new DiscordServerUser
        {
            DiscordServerId = x,
            UserId = request.UserId
        });
        await _dbContext.AddRangeAsync(toAddServerUsers);
        await _dbContext.SaveChangesAsync();
    }
}