using JetBrains.Annotations;

namespace GuildView.Idp.Data;

[UsedImplicitly]
public class OidcClientsConfiguration
{
    public List<OidcClientApplication> Clients { get; set; } = new();
}