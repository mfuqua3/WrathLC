using JetBrains.Annotations;

namespace WrathLc.Idp.Data;

[UsedImplicitly]
public class OidcClientsConfiguration
{
    public List<OidcClientApplication> Clients { get; set; } = new();
}