using OpenIddict.Abstractions;
using WrathLC.Identity.Data;
using WrathLC.Utility.Common.Constants;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace WrathLC.Identity.Idp.Extensions;

public static class OpenIddictConfigurationExtensions
{
    public static void ConfigureServer(this OpenIddictServerBuilder serverBuilder)
    {
        serverBuilder.DisableAccessTokenEncryption();
        serverBuilder
            .SetAuthorizationEndpointUris("/connect/authorize")
            .SetLogoutEndpointUris("/connect/logout")
            .SetTokenEndpointUris("/connect/token")
            .SetUserinfoEndpointUris("/connect/userinfo");

        serverBuilder.RegisterScopes(
            Scopes.Profile, 
            Scopes.Roles,
            WrathLcScopes.Api);

        serverBuilder.AllowAuthorizationCodeFlow();

        serverBuilder
            .AddDevelopmentEncryptionCertificate()
            .AddDevelopmentSigningCertificate();
        serverBuilder.UseAspNetCore()
            .DisableTransportSecurityRequirement()
            .EnableAuthorizationEndpointPassthrough()
            .EnableLogoutEndpointPassthrough()
            .EnableTokenEndpointPassthrough()
            .EnableUserinfoEndpointPassthrough()
            .EnableStatusCodePagesIntegration();
    }
    public static void ConfigureCore(this OpenIddictCoreBuilder coreBuilder)
    {
        coreBuilder.UseEntityFrameworkCore()
            .UseDbContext<WrathLcIdentityDbContext>();
        coreBuilder.UseQuartz();
    }

    public static void ConfigureValidation(this OpenIddictValidationBuilder validationBuilder)
    {
        validationBuilder.UseLocalServer();
        validationBuilder.UseAspNetCore();
    }
}