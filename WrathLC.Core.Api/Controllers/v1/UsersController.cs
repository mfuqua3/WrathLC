using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WrathLC.Core.Business.Manager.Contracts;
using WrathLC.Core.Utility.DataContracts.Models;
using WrathLC.Core.Utility.DataContracts.Requests;

namespace WrathLC.Core.Api.Controllers.v1;

public class UsersController : ApiController
{
    private readonly ICharacterManager _characterManager;

    public UsersController(ICharacterManager characterManager)
    {
        _characterManager = characterManager;
    }
    
    /// <summary>
    /// Fetches all characters for the user, scoped to the guild specified by the request header
    /// </summary>
    /// <returns></returns>
    /// <response code="200">A list of characters</response>
    [HttpGet("@me/characters")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<UserCharacterModel>>> GetUsersCharactersAsync(
        [FromHeader] int guildId)
    {
        var request = new GetUsersCharactersRequest { GuildId = guildId };
        var result = await _characterManager.GetUsersCharactersAsync(ForUser(request));
        return Ok(result);
    }
}