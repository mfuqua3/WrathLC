using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WrathLC.Core.Business.Manager.Contracts;
using WrathLc.Core.ResourceAccess;
using WrathLc.Core.ResourceAccess.Entities;
using WrathLC.Core.Utility.DataContracts.Models;
using WrathLC.Core.Utility.DataContracts.Requests;
using WrathLC.Core.Utility.Exceptions;
using WrathLC.Data.Common.Extensions;

namespace WrathLC.Core.Business.Manager.Components;

public class TenancyManager : ITenancyManager
{
    private readonly WrathLcDbContext _dbContext;
    private readonly IConfigurationProvider _configurationProvider;

    public TenancyManager(WrathLcDbContext dbContext, IConfigurationProvider configurationProvider)
    {
        _dbContext = dbContext;
        _configurationProvider = configurationProvider;
    }

    async Task<List<GuildSummaryModel>> ITenancyManager.GetGuildsAsync(UserScopedRequest request)
        => await _dbContext.GuildUsers
            .Where(x => x.UserId == request.UserId)
            .Select(x => x.Guild)
            .ProjectTo<GuildSummaryModel>(_configurationProvider)
            .ToListAsync();

    async Task<GuildDetailModel> ITenancyManager.GetGuildDetailAsync(GetGuildDetailRequest request)
        => await _dbContext.GuildUsers
            .Where(x => x.GuildId == request.GuildId && x.UserId == request.UserId)
            .Select(x => x.Guild)
            .ProjectTo<GuildDetailModel>(_configurationProvider)
            .SingleOrNotFoundAsync();

    async Task<List<DiscordServerSummaryModel>> ITenancyManager.GetAvailableGuildsAsync(UserScopedRequest request)
        => await _dbContext.DiscordServerUsers
            .Where(x => x.UserId == request.UserId)
            .Select(x => x.DiscordServer)
            .Where(x => x.Guild == null || x.Guild.GuildUsers.All(g => g.UserId != request.UserId))
            .ProjectTo<DiscordServerSummaryModel>(_configurationProvider)
            .ToListAsync();

    async Task<GuildDetailModel> ITenancyManager.CreateGuildAsync(CreateGuildRequest request)
    {
        var server = await _dbContext
            .DiscordServers
            .Include(x => x.Guild)
            .SingleOrDefaultAsync(x => x.Id == request.ServerId);
        if (server == null)
            throw new ArgumentException("No server with that ID exists.", nameof(request.ServerId));
        if (server.Guild != null)
            throw new ResourceConflictException("A guild has already been created for that Discord Server.");
        var guild = new Guild
        {
            DiscordServer = server,
            Name = string.IsNullOrWhiteSpace(request.Name) ? server.Name : request.Name,
            GuildUsers = new List<GuildUser>
            {
                new() { UserId = request.UserId }
            }
        };
        await _dbContext.Guilds.AddAsync(guild);
        await _dbContext.SaveChangesAsync();
        return await _dbContext.Guilds
            .Where(x => x.Id == guild.Id)
            .ProjectTo<GuildDetailModel>(_configurationProvider)
            .SingleAsync();
    }

    async Task ITenancyManager.JoinGuildAsync(JoinGuildRequest request)
    {
        var serverId = await _dbContext.Guilds
            .Where(x => x.Id == request.GuildId)
            .Select(x => x.DiscordServerId)
            .SingleOrNotFoundAsync();
        var authorizedToJoin = await _dbContext.DiscordServerUsers.AnyAsync(x =>
            x.UserId == request.UserId && x.DiscordServerId == serverId);
        if (!authorizedToJoin)
            throw new UnauthorizedAccessException();
        var alreadyJoined = await _dbContext.GuildUsers
            .AnyAsync(x => x.GuildId == request.GuildId && x.UserId == request.UserId);
        if (alreadyJoined)
            throw new InvalidOperationException("User is already a member of that guild.");
        await _dbContext.GuildUsers.AddAsync(new GuildUser
        {
            GuildId = request.GuildId,
            UserId = request.UserId
        });
        await _dbContext.SaveChangesAsync();
    }
}
