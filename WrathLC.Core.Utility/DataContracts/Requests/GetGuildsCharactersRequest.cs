using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Core.Utility.DataContracts.Requests;

public class GetGuildsCharactersRequest : IGuildId, IUserId, IPaginated
{

    public string UserId { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int GuildId { get; set; }
}