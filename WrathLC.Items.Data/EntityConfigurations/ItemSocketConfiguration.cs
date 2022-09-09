using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrathLC.Items.Data.Entities;

namespace WrathLC.Items.Data.EntityConfigurations;

internal class ItemSocketConfiguration : EntityTypeConfiguration<ItemSocket>
{
    protected override string TableName => "ItemSockets";

    public override void Configure(EntityTypeBuilder<ItemSocket> builder)
    {
        base.Configure(builder);
        builder.HasData(new ItemSocket
        {
            Id = 1,
            Name = "Meta"
        }, new ItemSocket
        {
            Id = 2,
            Name = "Red"
        }, new ItemSocket
        {
            Id = 3,
            Name = "Yellow"
        }, new ItemSocket
        {
            Id = 4,
            Name = "Blue"
        });
    }
}