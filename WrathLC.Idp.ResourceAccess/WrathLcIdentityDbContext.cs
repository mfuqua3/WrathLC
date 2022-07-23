using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WrathLc.Common.ResourceAccess;

namespace WrathLc.Idp.ResourceAccess;

public class WrathLcIdentityDbContext : IdentityDbContext<WrathLcUser>
{
    public WrathLcIdentityDbContext(DbContextOptions<WrathLcIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("identity");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.ApplySoftDeleteQueryFilters();
        base.OnModelCreating(builder);
    }


    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new())
    {
        this.ProcessCustomInterfaces();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}