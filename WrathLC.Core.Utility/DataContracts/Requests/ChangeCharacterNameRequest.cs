using System.Text.Json.Serialization;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Core.Utility.DataContracts.Requests;

public class ChangeCharacterNameRequest : IUserId, IGuildId
{
    [JsonIgnore]
    public string UserId { get; set; }
    [JsonIgnore]
    public int CharacterId { get; set; }
    [JsonIgnore]
    public int GuildId { get; set; }
    public string Name { get; set; }
}