using System.Linq;
using WrathLC.Items.Data.Entities;

namespace WrathLc.Core.ResourceAccess.Extensions;

public static class ItemQueryExtensions
{

    public static IQueryable<Item> FilterByWearable(this IQueryable<Item> query, int wowClassId)
        => query.Where(x => ItemHelpers.PermittedWishlistSubClasses(wowClassId).Contains(x.ItemSubClassId));

}