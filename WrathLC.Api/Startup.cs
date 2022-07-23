using Hangfire;
using Microsoft.EntityFrameworkCore;
using WrathLc.Common.Utilities.Hangfire;
using WrathLc.Core.ResourceAccess;

namespace WrathLc.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
        => _configuration = configuration;

    private readonly IConfiguration _configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<WrathLcDbContext>(opt => { opt.UseNpgsql(connectionString); });
        services.AddControllers();
        services.AddHealthChecks();
        services.AddSwaggerGen();
        services.AddAuthentication();
        services.AddAuthorization();
        services.AddHangfire(cfg => cfg.UseWrathLcConfiguration(connectionString));
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
        });
    }
}