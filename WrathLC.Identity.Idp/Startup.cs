using Hangfire;
using Microsoft.AspNetCore.Identity;
using Quartz;
using Serilog;
using WrathLC.Identity.Business.DependencyInjection;
using WrathLC.Identity.Idp.Extensions;
using WrathLC.Identity.Utility;

namespace WrathLC.Identity.Idp;

public class Startup
{
    public Startup(IConfiguration configuration)
        => _configuration = configuration;

    private readonly IConfiguration _configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();
        services.AddQuartz(options =>
        {
            options.UseMicrosoftDependencyInjectionJobFactory();
            options.UseSimpleTypeLoader();
            options.UseInMemoryStore();
        });
        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);
        services.AddOpenIddict()
            .AddCore(OpenIddictConfigurationExtensions.ConfigureCore)
            .AddServer(OpenIddictConfigurationExtensions.ConfigureServer)
            .AddValidation(OpenIddictConfigurationExtensions.ConfigureValidation);
        services
            .AddAuthentication()
            .AddDiscord(options =>
            {
                var discordConfigSection =
                    _configuration.GetSection("Authentication:Discord");
        
                options.ClientId = discordConfigSection["ClientId"];
                options.ClientSecret = discordConfigSection["ClientSecret"];
                options.SaveTokens = true;
                options.Scope.Add("guilds");
            });
        services.AddIdentity(_configuration, identity =>
        {
            identity.AddDefaultUI();
        });
        services.AddHealthChecks();
        services.AddOptions<OidcClientsConfiguration>()
            .Bind(_configuration)
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