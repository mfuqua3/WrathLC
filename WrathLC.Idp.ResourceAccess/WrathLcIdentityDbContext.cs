using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WrathLc.Idp.ResourceAccess;

public class WrathLcIdentityDbContext : IdentityDbContext<WrathLcUser>
{
    public WrathLcIdentityDbContext(DbContextOptions<WrathLcIdentityDbContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("identity");
        base.OnModelCreating(builder);
    }
}