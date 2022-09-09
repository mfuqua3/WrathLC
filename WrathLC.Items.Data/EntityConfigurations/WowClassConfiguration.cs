using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrathLC.Items.Data.Entities;

namespace WrathLC.Items.Data.EntityConfigurations;

internal class WowClassConfiguration : EntityTypeConfiguration<WowClass>
{
    protected override string TableName => "WowClasses";
    public override void Configure(EntityTypeBuilder<WowClass> builder)
    {
        base.Configure(builder);
        builder.HasData(WowClassSeed.Classes);
    }
}

internal class ItemSchemaConfiguration : IEntityTypeConfiguration<ItemSchema>
{
    public void Configure(EntityTypeBuilder<ItemSchema> builder)
    {
        builder.ToTable("schema", DataConstants.SchemaName);
        builder.HasKey(x => x.Version);
        builder.HasData(new List<ItemSchema>
        {
            new()
            {
                Version = 1,
                SeedName = SchemaVersion.Initial_1_0
            }
        });
    }
}