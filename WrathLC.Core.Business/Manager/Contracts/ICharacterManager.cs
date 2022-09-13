using WrathLC.Core.Utility.DataContracts.Models;
using WrathLC.Core.Utility.DataContracts.Requests;
using WrathLC.Utility.Common.DataContracts.Models;

namespace WrathLC.Core.Business.Manager.Contracts;

public interface ICharacterManager
{
    Task<UserCharacterModel> CreateCharacterAsync(CreateCharacterRequest request);
    Task<List<UserCharacterModel>> GetUsersCharactersAsync(GetUsersCharactersRequest request);
    Task<PagedListModel<GuildCharacterModel>> GetGuildsCharactersAsync(GetGuildsCharactersRequest request);
    Task<GuildCharacterModel> ChangeCharacterNameAsync(ChangeCharacterNameRequest request);
    Task DeleteCharacterAsync(DeleteProtectedResourceRequest request);
}