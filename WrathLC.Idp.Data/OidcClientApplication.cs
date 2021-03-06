using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace WrathLc.Idp.Data;

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
    public string? DisplayName { get; set; }
    [Required]
    [MinLength(1)]
    public List<string> RedirectUris { get; set; }
}