using Microsoft.Extensions.Options;
using OpenIddict.Abstractions;
using WrathLc.Common.Utilities.Constants;
using WrathLc.Common.Utilities.Extensions;
using WrathLc.Idp.Data;
using WrathLc.Idp.ResourceAccess;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace WrathLc.Idp;

public class IdentitySeedWorker : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly OidcClientsConfiguration _clientConfiguration;

    public IdentitySeedWorker(IOptions<OidcClientsConfiguration> options,
        IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _clientConfiguration = options.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await using var scope = _serviceScopeFactory.CreateAsyncScope();
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<WrathLcIdentityDbContext>();
        await dbContext.Database.EnsureCreatedAsync(stoppingToken);
        if (!_clientConfiguration.Clients.Any())
        {
            return;
        }
        var manager = services.GetRequiredService<IOpenIddictApplicationManager>();
        foreach (var client in _clientConfiguration.Clients)
        {
            var clientDescriptor = new OpenIddictApplicationDescriptor
            {
                ClientId = client.ClientId,
                ClientSecret = client.ClientSecret,
                ConsentType = client.FirstParty ? ConsentTypes.Implicit : ConsentTypes.Explicit,
                DisplayName = client.DisplayName ?? client.ClientId,
                Permissions =
                {
                    Permissions.Endpoints.Authorization,
                    Permissions.Endpoints.Logout,
                    Permissions.Endpoints.Token,
                    Permissions.GrantTypes.AuthorizationCode,
                    Permissions.GrantTypes.RefreshToken,
                    Permissions.ResponseTypes.Code,
                    Permissions.Scopes.Email,
                    Permissions.Scopes.Profile,
                    Permissions.Scopes.Roles
                },
                Requirements = { Requirements.Features.ProofKeyForCodeExchange }
            };
            clientDescriptor.Permissions.AddRange(GuildViewScopes.AllScopes);
            clientDescriptor.RedirectUris.AddRange(client.RedirectUris.Select(x => new Uri(x)));

            var existing = await manager.FindByClientIdAsync(client.ClientId, stoppingToken);
            if (existing == null)
            {
                await manager.CreateAsync(clientDescriptor, stoppingToken);
            }
        }
    }
}