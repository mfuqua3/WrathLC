import {useContext} from "react";
import {ServersContext} from "./ServersProvider";
import {ServersState} from "./ServersState";

export function useServers(): ServersState {
    const contextState = useContext(ServersContext);
    if (contextState === null) {
        throw Error("useServers must be used within a ServersProvider");
    }
    if (!contextState.initialized) {
        contextState.initialize();
    }
    return {
        allServers: contextState.allServers,
        joinableServers: contextState.joinableServers,
        loading: !contextState.initialized
    }
}