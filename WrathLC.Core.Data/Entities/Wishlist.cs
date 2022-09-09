using System;
using System.Collections.Generic;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLc.Core.ResourceAccess.Entities;

public class Wishlist : IUnique<int>, ITracked
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public Character Character { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<WishlistItem> WishlistItems { get; set; }
}