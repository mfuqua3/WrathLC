using GuildView.Common.Utilities.Constants;
using GuildView.Common.Utilities.Extensions;
using GuildView.Idp.Data;
using GuildView.Idp.ResourceAccess;
using Microsoft.Extensions.Options;
using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace GuildView.Idp;

public class ClientRegistrationWorker : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly OidcClientsConfiguration _clientConfiguration;

    public ClientRegistrationWorker(IOptions<OidcClientsConfiguration> options,
        IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _clientConfiguration = options.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!_clientConfiguration.Clients.Any())
        {
            return;
        }

        await using var scope = _serviceScopeFactory.CreateAsyncScope();
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<GuildViewIdentityDbContext>();
        await dbContext.Database.EnsureCreatedAsync(stoppingToken);

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