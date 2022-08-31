using OpenIddict.Abstractions;

namespace WrathLC.Utility.Common.Constants;

public static class WrathLcPermissions
{
    public static readonly string Api = Scope(WrathLcScopes.Api);

    private static string Scope(string scope) => OpenIddictConstants.Permissions.Prefixes.Scope + scope;
}