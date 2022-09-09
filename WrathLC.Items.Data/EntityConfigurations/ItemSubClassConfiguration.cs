using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrathLC.Items.Data.Entities;

namespace WrathLC.Items.Data.EntityConfigurations;

internal class ItemSubClassConfiguration : EntityTypeConfiguration<ItemSubClass>
{
    protected override string TableName => "ItemSubClasses";
    public override void Configure(EntityTypeBuilder<ItemSubClass> builder)
    {
        base.Configure(builder);
        builder.HasOne(x => x.ItemClass)
            .WithMany(x => x.ItemSubClasses);
    }
}