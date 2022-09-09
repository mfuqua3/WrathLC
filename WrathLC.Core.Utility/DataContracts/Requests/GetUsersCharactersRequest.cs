using System.Text.Json.Serialization;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Core.Utility.DataContracts.Requests;

public class GetUsersCharactersRequest : GuildScopedRequest, IUserId
{

    [JsonIgnore]
    public string UserId { get; set; }
}