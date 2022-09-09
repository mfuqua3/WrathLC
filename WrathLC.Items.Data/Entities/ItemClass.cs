using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Items.Data.Entities;

public class ItemClass : IUnique<int>, INamed
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ItemSubClass> ItemSubClasses { get; set; }
}