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
    [HttpGet]
    public async Task<ActionResult<List<DiscordServerSummaryModel>>> GetAvailableGuildsAsync()
    {
        var result = await _tenancyManager.GetAvailableGuildsAsync(ForUser());
        return Ok(result);
    }
}