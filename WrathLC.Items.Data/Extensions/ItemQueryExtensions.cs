using WrathLC.Items.Data.Entities;

namespace WrathLC.Items.Data.Extensions;

public static class ItemQueryExtensions
{
    public static IQueryable<Item> FilterByInventorySlot(this IQueryable<Item> query, string slotName)
        => query.Where(x => x.ItemInventorySlot.Name.ToUpper() == slotName.ToUpper());

    public static IQueryable<Item> FilterByName(this IQueryable<Item> query, string name)
        => query.Where(x => x.Name.ToUpper().Contains(name.ToUpper()));

    public static IQueryable<Item> FilterByClassRestriction(this IQueryable<Item> query, int wowClassId)
        => query.Where(x => !x.ClassRestrictions.Any() || x.ClassRestrictions.Any(x => x.WowClassId == wowClassId));
    public static IQueryable<Item> FilterByLevelRequirement(this IQueryable<Item> query, int levelRequirement)
    {
        return query.Where(x => x.LichKingEquipmentMetadata.LevelRequirement == levelRequirement);
    }
}