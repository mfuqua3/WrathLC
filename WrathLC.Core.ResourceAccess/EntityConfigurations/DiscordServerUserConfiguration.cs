using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrathLc.Core.ResourceAccess.Entities;

namespace WrathLc.Core.ResourceAccess.EntityConfigurations;

public class DiscordServerUserConfiguration : IEntityTypeConfiguration<DiscordServerUser>
{
    public void Configure(EntityTypeBuilder<DiscordServerUser> builder)
    {
        builder.HasIndex(x => x.UserId)
            .HasMethod("hash");
    }
}