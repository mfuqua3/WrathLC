using Microsoft.EntityFrameworkCore;

namespace WrathLc.Core.ResourceAccess;

public class WrathLcDbContext : DbContext
{
    public WrathLcDbContext(DbContextOptions<WrathLcDbContext> options):base(options)
    {
        
    }
}