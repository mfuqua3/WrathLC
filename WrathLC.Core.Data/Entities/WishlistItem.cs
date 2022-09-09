using System;
using WrathLC.Items.Data.Entities;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLc.Core.ResourceAccess.Entities;

public class WishlistItem : IUnique<int>, ITracked, IOrdered
{
    public int Id { get; set; }
    public int OrderNumber { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public int WishlistId { get; set; }
    public Wishlist Wishlist { get; set;}
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}