using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WrathLC.Core.Business.Manager.Contracts;
using WrathLC.Core.Utility.DataContracts.Models;
using WrathLC.Core.Utility.DataContracts.Requests;
using WrathLC.Utility.Common.DataContracts.Models;

namespace WrathLC.Core.Api.Controllers.v1;

public class CharactersController : ApiController
{
    private readonly ICharacterManager _characterManager;

    public CharactersController(ICharacterManager characterManager)
    {
        _characterManager = characterManager;
    }

    /// <summary>
    /// Creates a new character for the guild specified by the request header.
    /// </summary>
    /// <param name="request">Character to create</param>
    /// <param name="guildId">Guild request header</param>
    /// <returns></returns>
    /// <response code="201">The created character</response>
    /// <response code="400">If the character name is invalid or has already been taken</response>
    /// <response code="404">If the guild does not exist or if the user does not have access</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionModel))]
    public async Task<ActionResult<UserCharacterModel>> CreateCharacterAsync(
        CreateCharacterRequest request, [FromHeader] int guildId)
    {
        request.GuildId = guildId;
        var result = await _characterManager.CreateCharacterAsync(ForUser(request));
        return Created("", result);
    }

    /// <summary>
    /// Fetches all characters for the guild specified by the request header
    /// </summary>
    /// <param name="pagination">Optional pagination parameters</param>
    /// <param name="guildId">Guild request header</param>
    /// <returns></returns>
    /// <response code="200">A paginated list of characters</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedListModel<GuildCharacterModel>>> GetGuildsCharactersAsync(
        [FromQuery] PaginatedRequest pagination, [FromHeader] int guildId)
    {
        var request = new GetGuildsCharactersRequest
        {
            Page = pagination.Page,
            PageSize = pagination.PageSize,
            GuildId = guildId
        };
        var result = await _characterManager.GetGuildsCharactersAsync(ForUser(request));
        return Ok(result);
    }
}