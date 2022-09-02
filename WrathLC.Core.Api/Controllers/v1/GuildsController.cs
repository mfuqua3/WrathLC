using Microsoft.AspNetCore.Mvc;
using WrathLC.Core.Business.Manager.Contracts;
using WrathLC.Core.Utility.DataContracts.Models;
using WrathLC.Core.Utility.DataContracts.Requests;
using WrathLC.Utility.Common.DataContracts.Models;

namespace WrathLC.Core.Api.Controllers.v1;

public class GuildsController : ApiController
{
    private readonly ITenancyManager _tenancyManager;

    public GuildsController(ITenancyManager tenancyManager)
    {
        _tenancyManager = tenancyManager;
    }
    /// <summary>
    /// Fetches all guild memberships for the authenticated user
    /// </summary>
    /// <returns>Guild summary items, or an empty array if no guild enrollments exist</returns>
    /// <response code="200">An array of guild summary items</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GuildSummaryModel>>> GetGuildsAsync()
    {
        var result = await _tenancyManager.GetGuildsAsync(ForUser());
        return Ok(result);
    }

    /// <summary>
    /// Fetches the details of a specific guild for the authenticated user
    /// </summary>
    /// <param name="guildId">The ID of the requested guild</param>
    /// <returns>A requested guild detail.</returns>
    /// <response code="200">The requested guild detail item</response>
    /// <response code="404">If the guild does not exist, or if the user is not a member to the requested guild</response>
    [HttpGet("{guildId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExceptionModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionModel))]
    public async Task<ActionResult<GuildDetailModel>> GetGuildDetailAsync(int guildId)
    {
        var result = await _tenancyManager.GetGuildDetailAsync(ForUser(new GetGuildDetailRequest
        {
            GuildId = guildId
        }));
        return Ok(result);
    }
    /// <summary>
    /// Creates a new Guild and associates it with a user's Discord Server
    /// </summary>
    /// <param name="request"></param>
    /// <returns>A newly created guild</returns>
    /// <response code="201">The requested guild detail item</response>
    /// <response code="400">If the discord server does not exist, or the user does not have access.</response>
    /// <response code="409">If a guild has already been created for the requested server.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionModel))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ExceptionModel))]
    public async Task<ActionResult<GuildDetailModel>> CreateGuildAsync(CreateGuildRequest request)
    {
        var created = await _tenancyManager.CreateGuildAsync(ForUser(request));
        return Created("", created);
    }
    /// <summary>
    /// Enrolls the authenticated user into the requested guild
    /// </summary>
    /// <param name="guildId"></param>
    /// <returns></returns>
    /// <response code="201">Guild enrollment success.</response>
    /// <response code="400">If the user has already enrolled in the specified guild.</response>
    /// <response code="403">If the user is not a member of the guild's associated server.</response>
    /// <response code="404">If the guild does not exist.</response>
    [HttpPost("{guildId}/user")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionModel))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ExceptionModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionModel))]
    public async Task<IActionResult> JoinGuildAsync(int guildId)
    {
        await _tenancyManager.JoinGuildAsync(ForUser(new JoinGuildRequest{GuildId = guildId}));
        return Created("", null);
    }
}