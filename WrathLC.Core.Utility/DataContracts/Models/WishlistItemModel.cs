using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Core.Utility.DataContracts.Models;

public class WishlistItemModel : IOrdered
{
    public int OrderNumber { get; set; }
    public ItemSummaryModel Item { get; set; }
}