using Hangfire;
using Microsoft.EntityFrameworkCore;
using WrathLc.Core.ResourceAccess;

namespace WrathLC.Core.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
        => _configuration = configuration;

    private readonly IConfiguration _configuration;

    public void ConfigureServices(IServiceCollection services)
    {
       
        services.AddControllers();
        services.AddHealthChecks();
        services.AddSwaggerGen();
        services.AddAuthentication();
        services.AddAuthorization();
        services.AddHangfireServer();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WrathLcDbContext dbContext)
    {
        if (env.IsDevelopment())
        {
            dbContext.Database.Migrate();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
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
            endpoints.MapHealthChecks("/health");
            if (env.IsDevelopment())
            {
                endpoints.MapHangfireDashboard();
                endpoints.MapSwagger();
            }
            
        });
    }
}