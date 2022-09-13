using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Core.Utility.DataContracts.Requests;

public class WishlistItemRequest : IOrdered
{
    public int ItemId { get; set; }
    public int OrderNumber { get; set; }
}