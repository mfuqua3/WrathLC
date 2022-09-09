using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Items.Data.Entities;

public class ItemSubClass : IUnique<int>, INamed
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ItemClassId { get; set; }
    public ItemClass ItemClass { get; set; }
    public List<Item> Items { get; set; }
}