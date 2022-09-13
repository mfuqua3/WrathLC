namespace WrathLC.Core.Utility.DataContracts.Models;

public class WishlistModel
{
    public DateTime LastUpdated { get; set; }
    public List<WishlistItemModel> Items { get; set; }
}