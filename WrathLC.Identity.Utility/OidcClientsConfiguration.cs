using JetBrains.Annotations;

namespace WrathLC.Identity.Utility;

[UsedImplicitly]
public class OidcClientsConfiguration
{
    public List<OidcClientApplication> Clients { get; set; } = new();
}