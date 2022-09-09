using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace WrathLC.Identity.Utility;

[UsedImplicitly]
public class OidcClientApplication
{
    public OidcClientApplication()
    {
        ClientSecret = Guid.NewGuid().ToString();
        FirstParty = false;
    }
    [Required]
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public bool FirstParty { get; set; }
    public string DisplayName { get; set; }
    [Required]
    [MinLength(1)]
    public List<string> RedirectUris { get; set; }
    [Required]
    [MinLength(1)]
    public List<string> PostLogoutRedirectUris { get; set; }
}