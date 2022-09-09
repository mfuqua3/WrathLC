using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrathLC.Items.Data.Entities;

namespace WrathLC.Items.Data.EntityConfigurations;

internal class LichKingEquipmentMetadataConfiguration : IEntityTypeConfiguration<LichKingEquipmentMetadata>
{
    public void Configure(EntityTypeBuilder<LichKingEquipmentMetadata> builder)
    {
        builder.ToTable("LichKingEquipmentMetadata", DataConstants.SchemaName);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.HasOne(x => x.Socket1)
            .WithMany()
            .HasForeignKey(x => x.Socket1Id);
        builder.HasOne(x => x.Socket2)
            .WithMany()
            .HasForeignKey(x => x.Socket2Id);
        builder.HasOne(x => x.Socket3)
            .WithMany()
            .HasForeignKey(x => x.Socket3Id);
    }
}