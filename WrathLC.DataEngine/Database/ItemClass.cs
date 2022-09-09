using System.Collections.Generic;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.DataEngine.Database;

public class ItemClass : IUnique<int>, INamed
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ItemSubClass> ItemSubClasses { get; set; }
}