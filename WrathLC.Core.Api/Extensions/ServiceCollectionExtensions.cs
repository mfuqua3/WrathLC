using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using WrathLC.Core.Api.Middleware;
using WrathLC.Core.Api.Options;

namespace WrathLC.Core.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddExceptionHandling(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlingMiddleware>();
        services.AddTransient<IConfigureOptions<ApiBehaviorOptions>, ConfigureExceptionHandlingApiBehavior>();
    }

    public static void AddOptionsConfigurations(this IServiceCollection services)
    {
        services
            .AddTransient<IConfigureOptions<ApiExplorerOptions>, ConfigureApiExplorerOptions>()
            .AddTransient<IConfigureOptions<ApiVersioningOptions>, ConfigureApiVersioningOptions>()
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();
    }
}