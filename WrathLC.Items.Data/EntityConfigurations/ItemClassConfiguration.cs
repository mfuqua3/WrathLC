using WrathLC.Items.Data.Entities;

namespace WrathLC.Items.Data.EntityConfigurations;

internal class ItemClassConfiguration : EntityTypeConfiguration<ItemClass>
{
    protected override string TableName => "ItemClasses";
}