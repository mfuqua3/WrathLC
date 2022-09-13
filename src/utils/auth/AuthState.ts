import {User, UserManager} from "oidc-client-ts";

export interface AuthState {
    userManager: UserManager;
    user: User | null;
    isAuthenticated: boolean;
    loading: boolean;
    error?: unknown;
}
