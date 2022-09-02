using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WrathLC.Core.Api.Extensions;
using WrathLC.Core.Business.DependencyInjection;
using WrathLc.Core.ResourceAccess;

namespace WrathLC.Core.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
        => _configuration = configuration;

    private readonly IConfiguration _configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();
        var jwtBearerOptions = _configuration
            .GetSection("JwtBearer")
            .Get<JwtBearerOptions>();
        services.AddOptionsConfigurations();
        services.AddControllers();
        services.AddHealthChecks();
        services.AddSwaggerGen();
        services.AddApiVersioning();
        services.AddVersionedApiExplorer();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.Authority = jwtBearerOptions.Authority;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });
        services.AddAuthorization();
        services.AddHangfireServer();
        services.AddExceptionHandling();
        services.AddCore(_configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseExceptionHandling();
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors(opt =>
        {
            opt
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks("/health");
            endpoints.MapControllers();
            endpoints.MapHangfireDashboard();
        });
    }
}