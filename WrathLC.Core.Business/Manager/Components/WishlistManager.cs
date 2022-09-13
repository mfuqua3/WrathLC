using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WrathLC.Core.Business.Manager.Contracts;
using WrathLc.Core.ResourceAccess;
using WrathLc.Core.ResourceAccess.Entities;
using WrathLc.Core.ResourceAccess.Extensions;
using WrathLC.Core.Utility.DataContracts.Models;
using WrathLC.Core.Utility.DataContracts.Requests;
using WrathLC.Data.Common.Extensions;
using WrathLC.Items.Data.Extensions;
using WrathLC.Utility.Common.DataContracts.Models;
using static System.String;
using static WrathLC.Items.Data.ItemQualities;

namespace WrathLC.Core.Business.Manager.Components;

public class WishlistManager : IWishlistManager
{
    private readonly WrathLcDbContext _dbContext;
    private readonly IConfigurationProvider _configurationProvider;

    public WishlistManager(WrathLcDbContext dbContext, IConfigurationProvider configurationProvider)
    {
        _dbContext = dbContext;
        _configurationProvider = configurationProvider;
    }

    public async Task<WishlistModel> UpdateCharacterWishlistAsync(UpdateCharacterWishlistRequest request)
    {
        var authorized = await _dbContext.Characters.Where(x => x.Id == request.CharacterId)
            .AnyAsync(x => x.GuildUser.UserId == request.UserId);
        if (!authorized)
            throw new UnauthorizedAccessException();
        var characterWishlist =
            await _dbContext.Wishlists
                .Include(x => x.WishlistItems)
                .Where(x => x.CharacterId == request.CharacterId)
                .SingleOrDefaultAsync() ??
            new Wishlist
            {
                CharacterId = request.CharacterId,
                WishlistItems = new List<WishlistItem>()
            };
        if (characterWishlist.WishlistItems.Any())
        {
            _dbContext.RemoveRange(characterWishlist.WishlistItems);
        }

        characterWishlist.WishlistItems = request.Items
            .OrderBy(x => x.OrderNumber)
            .Select((item, idx) =>
                new WishlistItem
                {
                    OrderNumber = idx + 1,
                    ItemId = item.ItemId
                }).ToList();
        _dbContext.Update(characterWishlist);
        await _dbContext.SaveChangesAsync();
        return await _dbContext.Wishlists
            .Where(x => x.Id == characterWishlist.Id)
            .ProjectTo<WishlistModel>(_configurationProvider)
            .SingleAsync();
    }

    public async Task<PagedListModel<ItemSummaryModel>> GetWishlistOptionsAsync(GetWishlistOptionsRequest request)
    {
        if (IsNullOrWhiteSpace(request.Filter) || request.Filter.Length < 2)
        {
            throw new ArgumentException("Request must provide at least two characters for a valid search.");
        }

        var characterClass = await _dbContext.Characters
            .Where(x => x.Id == request.CharacterId)
            .Select(x => x.WowClassId)
            .SingleOrNotFoundAsync();
        var isInventorySlotQuery = await _dbContext.ItemInventorySlots.AnyAsync(x =>
            x.Name.ToUpper() == request.Filter.ToUpper());
        var query = _dbContext.Items
            .FilterByLevelRequirement(80)
            .FilterByWearable(characterClass)
            .FilterByClassRestriction(characterClass);
        query = isInventorySlotQuery ? 
            query.FilterByInventorySlot(request.Filter) : 
            query.FilterByName(request.Filter);
        
        return await query
            .OrderByDescending(x=>x.ItemQualityId == Legendary)
            .ThenByDescending(x=>x.ItemQualityId == Epic)
            .Page(request, out var count)
            .ProjectTo<ItemSummaryModel>(_configurationProvider)
            .ToPagedListAsync(request, count);
    }

    public async Task<WishlistModel> GetCharacterWishlistAsync(GetCharacterWishlistRequest request)
    {
        var authorized = await _dbContext.Characters.Where(x => x.Id == request.CharacterId)
            .AnyAsync(x => x.GuildUser.UserId == request.UserId);
        if (!authorized)
            throw new UnauthorizedAccessException();
        return (await _dbContext.Wishlists.Where(x => x.CharacterId == request.CharacterId)
                    .ProjectTo<WishlistModel>(_configurationProvider)
                    .SingleOrDefaultAsync() ??
                new WishlistModel
                {
                    Items = new List<WishlistItemModel>(),
                    LastUpdated = DateTime.UtcNow
                });
    }
}