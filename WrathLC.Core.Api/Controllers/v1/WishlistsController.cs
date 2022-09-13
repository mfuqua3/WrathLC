using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WrathLC.Core.Business.Manager.Contracts;
using WrathLC.Core.Utility.DataContracts.Models;
using WrathLC.Core.Utility.DataContracts.Requests;
using WrathLC.Utility.Common.DataContracts.Models;

namespace WrathLC.Core.Api.Controllers.v1;

public class WishlistsController : ApiController
{
    private readonly IWishlistManager _wishlistManager;

    public WishlistsController(IWishlistManager wishlistManager)
    {
        _wishlistManager = wishlistManager;
    }

    [HttpGet("{characterId}")]
    public async Task<ActionResult<WishlistModel>> GetCharacterWishlistAsync(int characterId)
    {
        var result = await _wishlistManager.GetCharacterWishlistAsync(ForUser(new GetCharacterWishlistRequest
            { CharacterId = characterId }));
        return Ok(result);
    }
    [HttpPut("{characterId}")]
    public async Task<ActionResult<WishlistModel>> UpdateCharacterWishlistAsync(int characterId, UpdateCharacterWishlistRequest request)
    {
        request.CharacterId = characterId;
        var result = await _wishlistManager.UpdateCharacterWishlistAsync(ForUser(request));
        return Ok(result);
    }
    [HttpGet("{characterId}/items")]
    [AllowAnonymous]
    public async Task<ActionResult<PagedListModel<ItemSummaryModel>>> GetWishlistOptionsAsync(
        [FromQuery]GetWishlistOptionsRequest request)
    {
        var result = await _wishlistManager.GetWishlistOptionsAsync(request);
        return result;
    }
}