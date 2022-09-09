using WrathLC.Items.Data.Entities;

namespace WrathLC.Items.Data.EntityConfigurations;

internal class ItemInventorySlotConfiguration : EntityTypeConfiguration<ItemInventorySlot>
{
    protected override string TableName => "ItemInventorySlots";
}