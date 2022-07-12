using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WrathLc.Core.ResourceAccess;

namespace WrathLc.Api;

[UsedImplicitly]
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WrathLcDbContext>
{

    public WrathLcDbContext CreateDbContext(string[] args)
    {
        // IDesignTimeDbContextFactory is used usually when you execute EF Core commands like Add-Migration, Update-Database, and so on
        // So it is usually your local development machine environment
        var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var environmentDeclarationIndex =
            args.ToList().FindIndex(x => x.Contains("environment", StringComparison.OrdinalIgnoreCase));
        if (environmentDeclarationIndex >= 0 && args.Length >= environmentDeclarationIndex)
        {
            envName = args[environmentDeclarationIndex + 1];
        }

        // Prepare configuration builder
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{envName}.json", optional: true)
            .Build();
        var config = configuration.GetConnectionString("DefaultConnection");
        var builder = new DbContextOptionsBuilder<WrathLcDbContext>().UseNpgsql(config);
        return new WrathLcDbContext(builder.Options);
    }
}