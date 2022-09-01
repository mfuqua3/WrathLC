using WrathLC.Utility.Common.DataContracts.Requests;

namespace WrathLC.Business.Common;

public interface IDiscordManager
{
    Task SyncUserAsync(SyncUserRequest request);
}