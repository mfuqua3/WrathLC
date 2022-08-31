using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WrathLC.Core.Business.Manager.Contracts;
using WrathLC.Core.Utility.DataContracts.Models;

namespace WrathLC.Core.Api.Controllers.v1;

public class ServersController : ApiController
{
    private readonly ITenancyManager _tenancyManager;

    public ServersController(ITenancyManager tenancyManager)
    {
        _tenancyManager = tenancyManager;
    }
    /// <summary>
    /// Fetches all discord servers from which the authenticated user may join/create a guild
    /// </summary>
    /// <returns>The requested servers, or an empty array if no eligible items exist</returns>
    /// <response code="200">The eligible discord servers</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DiscordServerSummaryModel>>> GetAvailableGuildsAsync()
    {
        var result = await _tenancyManager.GetAvailableGuildsAsync(ForUser());
        return Ok(result);
    }
}