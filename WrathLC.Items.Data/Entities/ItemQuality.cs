using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Items.Data.Entities;

public class ItemQuality : IUnique<int>, INamed
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Item> Items { get; set; }
}