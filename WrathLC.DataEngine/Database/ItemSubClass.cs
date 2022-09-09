﻿using System.Collections.Generic;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.DataEngine.Database;

public class ItemSubClass : IUnique<int>, INamed
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ItemClassId { get; set; }
    public ItemClass ItemClass { get; set; }
    public List<Item> Items { get; set; }
}