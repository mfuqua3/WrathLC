using WrathLc.Core.Data.Requests;

namespace WrathLc.Core.Managers.Manager.Contracts;

public interface IDiscordManager
{
    Task SyncUserAsync(SyncUserRequest request);
}