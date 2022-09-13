using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace WrathLC.Core.Utility.DataContracts.Requests;

public class GetWishlistOptionsRequest : PaginatedRequest
{
    [FromQuery]
    public string Filter { get; set; }

    [FromRoute(Name = "characterId")]
    public int CharacterId { get; set; }
}