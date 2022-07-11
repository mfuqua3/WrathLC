using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GuildView.Idp.ResourceAccess;

public class GuildViewIdentityDbContext : IdentityDbContext<GuildViewUser>
{
    public GuildViewIdentityDbContext(DbContextOptions<GuildViewIdentityDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("identity");
        base.OnModelCreating(builder);
    }
}