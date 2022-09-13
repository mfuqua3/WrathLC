using Microsoft.EntityFrameworkCore;
using WrathLC.Core.Business.Engine.Contracts;
using WrathLc.Core.ResourceAccess;
using WrathLC.Utility.Common.Validation;

namespace WrathLC.Core.Business.Engine.Components;

public class CharacterNameEngine : ICharacterNameEngine
{
    private readonly WrathLcDbContext _dbContext;

    public CharacterNameEngine(WrathLcDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<string> SanitizeCharacterNameAsync(string requestedName, int guildId)
    {
        var nameValidationResult = WowValidationUtility.ValidateCharacterName(ref requestedName);
        if (!nameValidationResult.IsValid)
        {
            throw new InvalidOperationException(string.Join(" ", nameValidationResult.InvalidReasons));
        }

        var nameTaken = await _dbContext.Characters
            .IgnoreQueryFilters()
            .Where(x => x.GuildId == guildId)
            .Where(x => x.Name == requestedName)
            .AnyAsync();
        if (nameTaken)
        {
            throw new InvalidOperationException("A character with that name has already been added to this guild.");
        }

        return requestedName;
    }
}