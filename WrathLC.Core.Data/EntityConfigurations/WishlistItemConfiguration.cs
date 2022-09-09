using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrathLc.Core.ResourceAccess.Entities;

namespace WrathLc.Core.ResourceAccess.EntityConfigurations;

public class WishlistItemConfiguration : IEntityTypeConfiguration<WishlistItem>
{
    public void Configure(EntityTypeBuilder<WishlistItem> builder)
    {
        builder.HasOne(x => x.Item)
            .WithMany()
            .HasForeignKey(x => x.ItemId);
        builder.HasOne(x => x.Wishlist)
            .WithMany(x => x.WishlistItems)
            .HasForeignKey(x => x.WishlistId);
    }
}