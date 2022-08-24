using WrathLC.Core.Utility.DataContracts.Requests;

namespace WrathLC.Core.Business.Manager.Contracts;

public interface IDiscordManager
{
    Task SyncUserAsync(SyncUserRequest request);
}