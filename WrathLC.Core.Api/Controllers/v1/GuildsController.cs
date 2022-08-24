using Microsoft.AspNetCore.Mvc;
using WrathLC.Core.Business.Manager.Contracts;
using WrathLC.Core.Utility.DataContracts.Models;
using WrathLC.Core.Utility.DataContracts.Requests;

namespace WrathLC.Core.Api.Controllers.v1;

public class GuildsController : ApiController
{
    private readonly ITenancyManager _tenancyManager;

    public GuildsController(ITenancyManager tenancyManager)
    {
        _tenancyManager = tenancyManager;
    }

    [HttpGet]
    public async Task<ActionResult<List<GuildSummaryModel>>> GetGuildsAsync()
    {
        var result = await _tenancyManager.GetGuildsAsync(ForUser());
        return Ok(result);
    }

    [HttpGet("{GuildId}")]
    public async Task<ActionResult<GuildDetailModel>> GetGuildDetailAsync(GetGuildDetailRequest request)
    {
        var result = await _tenancyManager.GetGuildDetailAsync(ForUser(request));
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GuildDetailModel>> CreateGuildAsync(CreateGuildRequest request)
    {
        var created = await _tenancyManager.CreateGuildAsync(ForUser(request));
        return Created("", created);
    }

    [HttpPost("{GuildId}/user")]
    public async Task<IActionResult> JoinGuildAsync(JoinGuildRequest request)
    {
        await _tenancyManager.JoinGuildAsync(ForUser(request));
        return Created("", null);
    }
}