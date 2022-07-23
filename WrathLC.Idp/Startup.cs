using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Abstractions;
using Quartz;
using Serilog;
using WrathLc.Common.Utilities.Discord;
using WrathLc.Common.Utilities.Hangfire;
using WrathLc.Core.Managers;
using WrathLc.Core.ResourceAccess;
using WrathLc.Idp.Data;
using WrathLc.Idp.ResourceAccess;

namespace WrathLc.Idp;

public class Startup
{
    public Startup(IConfiguration configuration)
        => Configuration = configuration;

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddDbContext<WrathLcIdentityDbContext>(options =>
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            options.UseOpenIddict();
        });
        services.AddDbContext<WrathLcDbContext>(options =>
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        });

        // Register the Identity services.
        services.AddIdentity<WrathLcUser, IdentityRole>(cfg =>
            {
                cfg.SignIn.RequireConfirmedEmail = false;
                cfg.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<WrathLcIdentityDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

        services.AddQuartz(options =>
        {
            options.UseMicrosoftDependencyInjectionJobFactory();
            options.UseSimpleTypeLoader();
            options.UseInMemoryStore();
        });

        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        services.AddOpenIddict()
            .AddCore(options =>
            {
                options.UseEntityFrameworkCore()
                       .UseDbContext<WrathLcIdentityDbContext>();

                options.UseQuartz();
            })

            .AddServer(options =>
            {
                options.DisableAccessTokenEncryption();
                options.SetAuthorizationEndpointUris("/connect/authorize")
                    .SetLogoutEndpointUris("/connect/logout")
                    .SetTokenEndpointUris("/connect/token")
                    .SetUserinfoEndpointUris("/connect/userinfo");

                options.RegisterScopes(
                    OpenIddictConstants.Permissions.Scopes.Email, 
                    OpenIddictConstants.Permissions.Scopes.Profile, 
                    OpenIddictConstants.Permissions.Scopes.Roles);

                options.AllowAuthorizationCodeFlow();

                options.AddDevelopmentEncryptionCertificate()
                       .AddDevelopmentSigningCertificate();
                options.UseAspNetCore()
                       .EnableAuthorizationEndpointPassthrough()
                       .EnableLogoutEndpointPassthrough()
                       .EnableTokenEndpointPassthrough()
                       .EnableUserinfoEndpointPassthrough()
                       .EnableStatusCodePagesIntegration();
            })
            .AddValidation(options =>
            {
                options.UseLocalServer();
                options.UseAspNetCore();
            });
        services.AddAuthentication()
            .AddDiscord(options =>
            {
                var discordConfigSection =
                    Configuration.GetSection("Authentication:Discord");
                options.ClientId = discordConfigSection["ClientId"];
                options.ClientSecret = discordConfigSection["ClientSecret"];
                options.SaveTokens = true;
                options.Scope.Add("guilds");
            });
        
        services.AddHangfire(cfg => cfg.UseWrathLcConfiguration(Configuration.GetConnectionString("DefaultConnection")));
        services.AddHangfireServer();
        services.AddDiscord();
        services.AddHealthChecks();
        services.AddWrathLcCore();
        services.AddOptions<OidcClientsConfiguration>()
            .Bind(Configuration)
            .ValidateDataAnnotations();
        services.AddHostedService<IdentitySeedWorker>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseStatusCodePagesWithReExecute("~/error");
        }
        app.UseHttpsRedirection();
        app.UseSerilogRequestLogging();
        app.UseStaticFiles();
        app.UseCors(opt =>
        {
            opt.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
        });
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapDefaultControllerRoute();
            endpoints.MapRazorPages();
            endpoints.MapHealthChecks("/health");
        });
    }
}