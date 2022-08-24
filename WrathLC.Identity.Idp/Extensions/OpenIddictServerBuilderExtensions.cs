using OpenIddict.Abstractions;
using WrathLc.Idp.ResourceAccess;

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
            OpenIddictConstants.Permissions.Scopes.Email, 
            OpenIddictConstants.Permissions.Scopes.Profile, 
            OpenIddictConstants.Permissions.Scopes.Roles);

        serverBuilder.AllowAuthorizationCodeFlow();

        serverBuilder.AddDevelopmentEncryptionCertificate()
            .AddDevelopmentSigningCertificate();
        serverBuilder.UseAspNetCore()
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