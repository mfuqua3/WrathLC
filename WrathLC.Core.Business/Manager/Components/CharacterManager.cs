using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WrathLC.Core.Business.Engine.Contracts;
using WrathLC.Core.Business.Manager.Contracts;
using WrathLc.Core.ResourceAccess;
using WrathLc.Core.ResourceAccess.Entities;
using WrathLC.Core.Utility.DataContracts.Models;
using WrathLC.Core.Utility.DataContracts.Requests;
using WrathLC.Data.Common.Extensions;
using WrathLC.Utility.Common.DataContracts.Models;
using WrathLC.Utility.Common.Validation;

namespace WrathLC.Core.Business.Manager.Components;

public class CharacterManager : ICharacterManager
{
    private readonly WrathLcDbContext _dbContext;
    private readonly IConfigurationProvider _configurationProvider;
    private readonly ICharacterNameEngine _characterNameEngine;

    public CharacterManager(
        WrathLcDbContext dbContext, 
        IConfigurationProvider configurationProvider,
        ICharacterNameEngine characterNameEngine)
    {
        _dbContext = dbContext;
        _configurationProvider = configurationProvider;
        _characterNameEngine = characterNameEngine;
    }

    async Task<UserCharacterModel> ICharacterManager.CreateCharacterAsync(CreateCharacterRequest request)
    {
        var guildUser = await _dbContext.GuildUsers
            .Where(x => x.GuildId == request.GuildId && x.UserId == request.UserId)
            .Include(x => x.Guild)
            .SingleOrNotFoundAsync();
        var characterName = await _characterNameEngine.SanitizeCharacterNameAsync(request.Name, request.GuildId);
        var character = new Character
        {
            Name = characterName,
            GuildId = request.GuildId,
            GuildUserId = request.AssignToMe ? guildUser.Id : null,
            WowClassId = request.ClassId,
            IsPrimary = request.AssignToMe &&
                        !await _dbContext.Characters.Where(x => x.GuildUserId == guildUser.Id).AnyAsync()
        };
        await _dbContext.Characters.AddAsync(character);
        await _dbContext.SaveChangesAsync();
        return await _dbContext.Characters
            .Where(x => x.Id == character.Id)
            .ProjectTo<UserCharacterModel>(_configurationProvider)
            .SingleAsync();
    }

    async Task<List<UserCharacterModel>> ICharacterManager.GetUsersCharactersAsync(GetUsersCharactersRequest request)
        => await _dbContext.GuildUsers
            .Where(x => x.GuildId == request.GuildId && x.UserId == request.UserId)
            .SelectMany(x => x.Characters)
            .ProjectTo<UserCharacterModel>(_configurationProvider)
            .ToListAsync();

    async Task<PagedListModel<GuildCharacterModel>> ICharacterManager.GetGuildsCharactersAsync(
        GetGuildsCharactersRequest request)
        => await _dbContext.GuildUsers
            .Where(x => x.GuildId == request.GuildId && x.UserId == request.UserId)
            .Select(x => x.Guild)
            .SelectMany(x => x.Characters)
            .Page(request, out var itemCount)
            .ProjectTo<GuildCharacterModel>(_configurationProvider)
            .ToPagedListAsync(request, itemCount);

    async Task<GuildCharacterModel> ICharacterManager.ChangeCharacterNameAsync(ChangeCharacterNameRequest request)
    {
        
        var characterName = await _characterNameEngine.SanitizeCharacterNameAsync(request.Name, request.GuildId);
        var character = await _dbContext.Characters
            .Where(x => x.Id == request.CharacterId)
            .Where(x => x.GuildUser.UserId == request.UserId)
            .SingleOrNotFoundAsync();
        character.Name = characterName;
        await _dbContext.SaveChangesAsync();
        return await _dbContext.Characters.Where(x => x.Id == character.Id)
            .ProjectTo<GuildCharacterModel>(_configurationProvider)
            .SingleAsync();
    }

    async Task ICharacterManager.DeleteCharacterAsync(DeleteProtectedResourceRequest request)
    {
        var character = await _dbContext.Characters
            .Where(x => x.Id == request.ResourceId)
            .SingleOrNotFoundAsync();
        var authorizedDelete = character.GuildUserId.HasValue
            ? await _dbContext.GuildUsers.AnyAsync(x => x.Id == character.GuildUserId)
            : character.GuildId == request.GuildId;
        if (!authorizedDelete)
            throw new UnauthorizedAccessException();
        _dbContext.Remove(character);
        await _dbContext.SaveChangesAsync();
    }
}