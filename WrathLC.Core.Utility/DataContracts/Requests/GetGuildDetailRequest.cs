using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Core.Utility.DataContracts.Requests;

public class GetGuildDetailRequest: IUserId
{
    [FromRoute]
    public int GuildId { get; set; }
    [JsonIgnore]
    public string UserId { get; set; }
}