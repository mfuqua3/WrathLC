using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Core.Utility.DataContracts.Requests;

public class DeleteProtectedResourceRequest : IGuildId, IUserId
{
    public int ResourceId { get; set; }
    public int GuildId { get; set; }
    public string UserId { get; set; }
}