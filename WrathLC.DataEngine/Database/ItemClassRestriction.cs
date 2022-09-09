using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.DataEngine.Database;

public class ItemClassRestriction : IUnique<int>
{
    public int Id { get; set; }
    public int WowClassId { get; set; }
    public int ItemId { get; set; }
    public WowClass WowClass { get; set; }
    public Item Item { get; set; }
}