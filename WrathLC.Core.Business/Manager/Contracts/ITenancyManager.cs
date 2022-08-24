using WrathLC.Core.Utility.DataContracts.Models;
using WrathLC.Core.Utility.DataContracts.Requests;

namespace WrathLC.Core.Business.Manager.Contracts;

public interface ITenancyManager
{
    Task<List<GuildSummaryModel>> GetGuildsAsync(UserScopedRequest request);
    Task<GuildDetailModel> GetGuildDetailAsync(GetGuildDetailRequest request);
    Task<List<DiscordServerSummaryModel>> GetAvailableGuildsAsync(UserScopedRequest request);
    Task<GuildDetailModel> CreateGuildAsync(CreateGuildRequest request);
    Task JoinGuildAsync(JoinGuildRequest request);
}