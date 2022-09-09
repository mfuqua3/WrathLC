using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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

    public CharacterManager(WrathLcDbContext dbContext, IConfigurationProvider configurationProvider)
    {
        _dbContext = dbContext;
        _configurationProvider = configurationProvider;
    }

    async Task<UserCharacterModel> ICharacterManager.CreateCharacterAsync(CreateCharacterRequest request)
    {
        var guildUser = await _dbContext.GuildUsers
            .Where(x => x.GuildId == request.GuildId && x.UserId == request.UserId)
            .Include(x => x.Guild)
            .SingleOrNotFoundAsync();
        var characterName = request.Name;
        var nameValidationResult = WowValidationUtility.ValidateCharacterName(ref characterName);
        if (!nameValidationResult.IsValid)
        {
            throw new InvalidOperationException(string.Join(" ", nameValidationResult.InvalidReasons));
        }

        var nameTaken = await _dbContext.Characters
            .IgnoreQueryFilters()
            .Where(x => x.GuildId == request.GuildId)
            .Where(x => x.Name == characterName)
            .AnyAsync();
        if (nameTaken)
        {
            throw new InvalidOperationException("A character with that name has already been added to this guild.");
        }

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
}