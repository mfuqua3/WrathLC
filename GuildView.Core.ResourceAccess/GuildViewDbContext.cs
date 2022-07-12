using Microsoft.EntityFrameworkCore;

namespace GuildView.Core.ResourceAccess;

public class GuildViewDbContext : DbContext
{
    public GuildViewDbContext(DbContextOptions<GuildViewDbContext> options):base(options)
    {
        
    }
}