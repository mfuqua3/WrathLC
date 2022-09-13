using WrathLC.Core.Utility.DataContracts.Models;
using WrathLC.Core.Utility.DataContracts.Requests;
using WrathLC.Utility.Common.DataContracts.Models;

namespace WrathLC.Core.Business.Manager.Contracts;

public interface IWishlistManager
{
    Task<WishlistModel> UpdateCharacterWishlistAsync(UpdateCharacterWishlistRequest request);
    Task<PagedListModel<ItemSummaryModel>> GetWishlistOptionsAsync(GetWishlistOptionsRequest request);

    Task<WishlistModel> GetCharacterWishlistAsync(GetCharacterWishlistRequest request);
}