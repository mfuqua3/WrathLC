using System.Reflection;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WrathLC.Identity.Data;
using WrathLc.Idp.ResourceAccess;
using WrathLC.Utility.Common.Discord;
using WrathLC.Utility.Common.Hangfire;

namespace WrathLC.Identity.Business.DependencyInjection;

public static class CoreRegistrar
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration, Action<IdentityBuilder> configureIdentityBuilder)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddAutoMapper(cfg => { cfg.AddMaps(Assembly.GetExecutingAssembly()); });
        services.AddDiscord();
        services.AddDbContext<WrathLcIdentityDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
            options.UseOpenIddict();
        });
        // Register the Identity services.
        var builder = services.AddIdentity<WrathLcUser, IdentityRole>(cfg =>
            {
                cfg.SignIn.RequireConfirmedEmail = false;
                cfg.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<WrathLcIdentityDbContext>()
            .AddDefaultTokenProviders();
        configureIdentityBuilder(builder);
        services.AddHangfire(cfg => cfg.UseWrathLcConfiguration(connectionString));
        return services;
    }
    
    
}