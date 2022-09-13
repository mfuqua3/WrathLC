namespace WrathLC.Core.Utility.DataContracts.Models;

public class ItemSummaryModel
{
    public int ItemId { get; set; }
    public string Domain { get; set; }
    public string Name { get; set; }
    public string Quality { get; set; }
    public string InventorySlot { get; set; }
    public string Descriptor { get; set; }
    public int IconId { get; set; }
    public string IconName { get; set; }
}