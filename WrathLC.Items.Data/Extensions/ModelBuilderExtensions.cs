using Microsoft.EntityFrameworkCore;
using WrathLC.Items.Data.Entities;
using WrathLC.Items.Data.EntityConfigurations;

namespace WrathLC.Items.Data.Extensions;

public static class ModelBuilderExtensions
{
    public static void UseItems(this ModelBuilder builder)
    {
        builder.ApplyConfiguration(new IconConfiguration());
        builder.ApplyConfiguration(new ItemClassConfiguration());
        builder.ApplyConfiguration(new ItemClassRestrictionConfiguration());
        builder.ApplyConfiguration(new ItemConfiguration());
        builder.ApplyConfiguration(new ItemInventorySlotConfiguration());
        builder.ApplyConfiguration(new ItemSocketConfiguration());
        builder.ApplyConfiguration(new ItemQualityConfiguration());
        builder.ApplyConfiguration(new ItemSubClassConfiguration());
        builder.ApplyConfiguration(new LichKingEquipmentMetadataConfiguration());
        builder.ApplyConfiguration(new WowClassConfiguration());
        builder.ApplyConfiguration(new ItemSchemaConfiguration());
    }
}