using WrathLC.Items.Data.Entities;

namespace WrathLC.Items.Data.EntityConfigurations;

internal class ItemQualityConfiguration : EntityTypeConfiguration<ItemQuality>
{
    protected override string TableName => "ItemQualities";
}