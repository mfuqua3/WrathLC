using GuildView.Core.ResourceAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GuildView.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
        => _configuration = configuration;

    private readonly IConfiguration _configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<GuildViewDbContext>(opt => { opt.UseNpgsql(connectionString); });
        services.AddControllers();
        services.AddHealthChecks();
        services.AddSwaggerGen();
        services.AddAuthentication();
        services.AddAuthorization();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GuildViewDbContext dbContext)
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