namespace WrathLC.Core.Business.Engine.Contracts;

public interface ICharacterNameEngine
{
    Task<string> SanitizeCharacterNameAsync(string requestedName, int guildId);
}