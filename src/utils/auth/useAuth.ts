import {AuthState} from "./AuthState";
import {AuthContext} from "./AuthContext";
import {useContext} from "react";

export function useAuth(): AuthState {
    const state = useContext(AuthContext);
    if (state === null) {
        throw new Error("useAuth hook may only be used with an AuthProvider");
    }
    return state;
}
