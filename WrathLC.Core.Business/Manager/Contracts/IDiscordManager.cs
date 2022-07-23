using WrathLc.Core.Data.Requests;

namespace WrathLc.Core.Managers.Manager.Components;

public interface IDiscordManager
{
    Task SyncUserAsync(SyncUserRequest request);
}