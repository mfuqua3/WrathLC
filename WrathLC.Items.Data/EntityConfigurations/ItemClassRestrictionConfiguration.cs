using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrathLC.Items.Data.Entities;

namespace WrathLC.Items.Data.EntityConfigurations;

internal class ItemClassRestrictionConfiguration : IEntityTypeConfiguration<ItemClassRestriction>
{
    public void Configure(EntityTypeBuilder<ItemClassRestriction> builder)
    {
        builder.ToTable("ItemClassRestrictions", DataConstants.SchemaName);
        builder.HasKey(x => x.Id);
    }
}