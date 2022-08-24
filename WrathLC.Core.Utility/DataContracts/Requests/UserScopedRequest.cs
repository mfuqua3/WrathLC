using System.Text.Json.Serialization;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Core.Utility.DataContracts.Requests;

public class UserScopedRequest : IUserId
{
    [JsonIgnore]
    public string UserId { get; set; }
}