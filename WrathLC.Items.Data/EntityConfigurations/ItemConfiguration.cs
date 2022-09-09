using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrathLC.Items.Data.Entities;

namespace WrathLC.Items.Data.EntityConfigurations;

internal class ItemConfiguration : EntityTypeConfiguration<Item>
{
    protected override string TableName => "Items";

    public override void Configure(EntityTypeBuilder<Item> builder)
    {
        base.Configure(builder);
        builder.HasOne(x => x.ItemSubClass)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.ItemSubClassId);
        builder.HasOne(x => x.ItemQuality)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.ItemQualityId);
        builder.HasOne(x => x.ItemInventorySlot)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.ItemInventorySlotId);
        builder.HasOne(x => x.Icon)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.IconId);
        builder
            .HasOne(x => x.LichKingEquipmentMetadata)
            .WithOne()
            .IsRequired(false);
        builder
            .HasMany(x => x.ClassRestrictions)
            .WithOne(x => x.Item)
            .HasForeignKey(x => x.ItemId);
    }
}