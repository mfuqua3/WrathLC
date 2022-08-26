import { User, UserManager, UserManagerSettings } from "oidc-client-ts";
import React, { ReactNode, useEffect, useState } from "react";
import { AuthContext } from "./AuthContext";
import SilentRefresh from "./SilentRefresh";
import AxiosConfig from "./AxiosConfig";

type AuthenticationState = "Initializing" | "Unauthenticated" | "Authenticated";

function AuthProvider({ children, ...userManagerSettings }: UserManagerSettings & { children: ReactNode }) {
    const [userManager] = useState(
        new UserManager({
            ...userManagerSettings,
            accessTokenExpiringNotificationTimeInSeconds: 600,
            automaticSilentRenew: false,
        }),
    );
    const [authenticationState, setAuthenticationState] = useState<AuthenticationState>("Initializing");
    const [user, setUser] = useState<User | null | undefined>(undefined);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState();
    useEffect(() => {
        if (user === undefined) {
            return;
        }
        setAuthenticationState(user != null && !user.expired ? "Authenticated" : "Unauthenticated");
    }, [user]);
    useEffect(() => {
        userManager
            .getUser()
            .then((user) => {
                setUser(user);
            })
            .catch((e) => setError(e))
            .finally(() => setLoading(false));
        userManager.events.addUserSignedOut(handleUserSignedOut);
        return () => {
            userManager.events.removeUserLoaded(handleUserLoaded);
        };
    }, []);

    async function handleUserLoaded() {
        const loadedUser = await userManager.getUser();
        setUser(loadedUser);
    }
    function signin(){
        userManager.signinRedirect();

    }
    // function handleUserSignedIn() {
    //     setIsAuthenticated(true);
    // }

    function handleUserSignedOut() {
        setUser(null);
    }

    const state = {
        userManager,
        user: user ?? null,
        isAuthenticated: authenticationState === "Authenticated",
        loading,
        error,
    };
    return (
        <AuthContext.Provider value={state}>
            <AxiosConfig />
            <SilentRefresh />
            {children}
        </AuthContext.Provider>
    );
}

export default React.memo(AuthProvider);
