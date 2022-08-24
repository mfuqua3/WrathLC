using System.Reflection;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WrathLc.Common.Utilities.Hangfire;
using WrathLc.Core.Managers.Manager.Components;
using WrathLc.Core.Managers.Manager.Contracts;
using WrathLc.Core.ResourceAccess;

namespace WrathLc.Core.Managers.DependencyInjection;

public static class CoreRegistrar
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(cfg => { cfg.AddMaps(Assembly.GetExecutingAssembly()); });
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<WrathLcDbContext>(opt => { opt.UseNpgsql(connectionString); });
        services.AddHangfire(cfg => cfg.UseWrathLcConfiguration(connectionString));
        
        services.AddScoped<IDiscordManager, DiscordManager>();
        return services;
    }
}