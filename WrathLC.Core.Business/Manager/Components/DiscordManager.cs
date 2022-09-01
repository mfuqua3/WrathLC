using Discord;
using Microsoft.EntityFrameworkCore;
using WrathLC.Business.Common;
using WrathLC.Core.Business.Manager.Contracts;
using WrathLc.Core.ResourceAccess;
using WrathLc.Core.ResourceAccess.Entities;
using WrathLC.Core.Utility.DataContracts.Requests;
using WrathLC.Utility.Common.DataContracts.Requests;
using WrathLC.Utility.Common.Discord;

namespace WrathLC.Core.Business.Manager.Components;

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
            .Where(x => guildIds.Contains(x.ServerId))
            .Select(x => x.ServerId)
            .ToListAsync();
        var toAdd = guilds.Where(x => !knownGuilds.Contains(x.Id));
        var servers = toAdd.Select(x => new DiscordServer
        {
            ServerId = x.Id,
            Name = x.Name
        }).ToList();
        await _dbContext.AddRangeAsync(servers);
        var existingServerUsers = await _dbContext.DiscordServerUsers
            .Where(x => x.UserId == request.UserId && guildIds.Contains(x.DiscordServer.ServerId))
            .Select(x => x.DiscordServer.ServerId)
            .ToListAsync();
        var toDeleteServerUsers = await _dbContext.DiscordServerUsers
            .Where(x => x.UserId == request.UserId && !guildIds.Contains(x.DiscordServer.ServerId)).ToListAsync();
        _dbContext.DiscordServerUsers.RemoveRange(toDeleteServerUsers);
        var toAddServerUsers = guildIds.Except(existingServerUsers).Select(x => new DiscordServerUser
        {
            DiscordServer = servers.Single(s=>s.ServerId == x),
            UserId = request.UserId
        });
        await _dbContext.AddRangeAsync(toAddServerUsers);
        await _dbContext.SaveChangesAsync();
    }
}