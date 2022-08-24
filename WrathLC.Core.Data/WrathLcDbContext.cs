using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WrathLc.Core.ResourceAccess.Entities;
using WrathLC.Data.Common;
using WrathLC.Data.Common.Extensions;

namespace WrathLc.Core.ResourceAccess;

public class WrathLcDbContext : DbContext
{
    public WrathLcDbContext(DbContextOptions<WrathLcDbContext> options):base(options)
    {
        
    }
    
    public DbSet<DiscordServer> DiscordServers { get; set; }
    public DbSet<DiscordServerUser> DiscordServerUsers { get; set; }
    public DbSet<Guild> Guilds { get; set; }
    public DbSet<GuildUser> GuildUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.RestrictForeignKeyDelete();
        modelBuilder.ApplySoftDeleteQueryFilters();
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new())
    {
        this.ProcessCustomInterfaces();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}