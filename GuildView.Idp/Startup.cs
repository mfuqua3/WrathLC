using GuildView.Idp.Data;
using GuildView.Idp.ResourceAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Abstractions;
using Quartz;
using Serilog;

namespace GuildView.Idp;

public class Startup
{
    public Startup(IConfiguration configuration)
        => Configuration = configuration;

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddDbContext<GuildViewIdentityDbContext>(options =>
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            options.UseOpenIddict();
        });

        // Register the Identity services.
        services.AddIdentity<GuildViewUser, IdentityRole>()
            .AddEntityFrameworkStores<GuildViewIdentityDbContext>()
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
                       .UseDbContext<GuildViewIdentityDbContext>();

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
            });
        services.AddHealthChecks();
        services.AddOptions<OidcClientsConfiguration>()
            .Bind(Configuration)
            .ValidateDataAnnotations();
        services.AddHostedService<ClientRegistrationWorker>();
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