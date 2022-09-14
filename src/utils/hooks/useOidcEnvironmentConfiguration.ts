export interface OidcEnvironmentConfig {
    authority: string;
    client_id: string;
    client_secret?: string;
    redirect_uri: string;
}

export default function useOidcEnvironmentConfiguration(): OidcEnvironmentConfig {
    const authority = process.env["REACT_APP_OIDC_AUTHORITY"];
    const clientId = process.env["REACT_APP_OIDC_CLIENT_ID"];
    const clientSecret = process.env["REACT_APP_OIDC_CLIENT_SECRET"];
    const redirectUriPath = process.env["REACT_APP_OIDC_REDIRECT_PATH"];
    if (!authority || !clientId || !redirectUriPath) {
        throw Error("Invalid application configuration, not all OIDC fields have been provided");
    }
    return {
        authority,
        client_id: clientId,
        redirect_uri: `${window.location.origin}/${redirectUriPath}`,
        client_secret: clientSecret,
    };
}
