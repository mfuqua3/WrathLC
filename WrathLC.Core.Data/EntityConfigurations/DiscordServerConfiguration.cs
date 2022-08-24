using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrathLc.Core.ResourceAccess.Entities;

namespace WrathLc.Core.ResourceAccess.EntityConfigurations;

public class DiscordServerConfiguration : IEntityTypeConfiguration<DiscordServer>
{
    public void Configure(EntityTypeBuilder<DiscordServer> builder)
    {
        builder.HasIndex(x => x.ServerId)
            .IsUnique();
    }
}