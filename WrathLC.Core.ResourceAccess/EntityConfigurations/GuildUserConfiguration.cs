using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrathLc.Core.ResourceAccess.Entities;

namespace WrathLc.Core.ResourceAccess.EntityConfigurations;

public class GuildUserConfiguration : IEntityTypeConfiguration<GuildUser>
{
    public void Configure(EntityTypeBuilder<GuildUser> builder)
    {
        builder.HasIndex(x => x.UserId)
            .HasMethod("hash");
    }
}