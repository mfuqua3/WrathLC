using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using WrathLC.Core.Api.Infrastructure;

namespace WrathLC.Core.Api.Options;

public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

    public void Configure(SwaggerGenOptions options)
    {
        options.OperationFilter<SwaggerDefaultValues>();
        foreach (var description in _provider.ApiVersionDescriptions)
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }

    private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        var info = new OpenApiInfo
        {
            Title = "WrathLC API",
            Description = "An Open-Source API for Guild Administration and Infrastructure",
            Version = description.ApiVersion.ToString(),
            License = new OpenApiLicense
            {
                Name = "GNU General Public License v3.0",
                Url = new Uri("https://github.com/mfuqua3/WrathLC/blob/main/LICENSE.md")
            },
            Contact = new OpenApiContact
            {
                Email = "developer@wrathlc.com",
                Name = "Matt Fuqua",
                Url = new Uri("https://github.com/mfuqua3/WrathLC")
            }
        };
        return info;
    }
}