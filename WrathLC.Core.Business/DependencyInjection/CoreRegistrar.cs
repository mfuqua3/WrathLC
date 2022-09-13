using System.Reflection;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WrathLC.Business.Common;
using WrathLC.Core.Business.Engine.Components;
using WrathLC.Core.Business.Engine.Contracts;
using WrathLC.Core.Business.Manager.Components;
using WrathLC.Core.Business.Manager.Contracts;
using WrathLc.Core.ResourceAccess;
using WrathLC.Items.Data.Extensions;
using WrathLC.Utility.Common.Discord;
using WrathLC.Utility.Common.Hangfire;

namespace WrathLC.Core.Business.DependencyInjection;

public static class CoreRegistrar
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(cfg => { cfg.AddMaps(Assembly.GetExecutingAssembly()); });
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<WrathLcDbContext>(opt =>
        {
            opt.UseNpgsql(connectionString);
        });
        services.AddHangfire(cfg => cfg.UseWrathLcConfiguration(connectionString));
        services.AddDiscord();
        services
            .AddScoped<IDiscordManager, DiscordManager>()
            .AddScoped<ICharacterManager, CharacterManager>()
            .AddScoped<ITenancyManager, TenancyManager>();
        services
            .AddScoped<ICharacterNameEngine, CharacterNameEngine>();
        return services;
    }
}