using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Core.Utility.DataContracts.Requests;

public class GuildScopedRequest : IGuildId
{
    [FromHeader, Required]
    public int GuildId { get; set; }
}