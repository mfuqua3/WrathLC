import React, {ReactNode, useState} from "react";
import {ServersState} from "./ServersState";
import {DiscordServer} from "../../domain/models";
import {useApi} from "../../utils/hooks";
import {ServersApi} from "../../api";

interface ServersContextState extends Omit<ServersState, "loading"> {
    initialize: () => Promise<void>;
    initialized: boolean;
}

export const ServersContext = React.createContext<ServersContextState | null>(null);

function ServersProvider({children}: { children: ReactNode }) {
    const [initialized, setInitialized] = useState(false);
    const [servers, setServers] = useState<DiscordServer[]>([]);
    const invocator = useApi(ServersApi);

    async function initialize() {
        const servers = await invocator.invoke(api => api.getDiscordServers());
        setServers(servers ?? []);
        setInitialized(true);
    }

    const providerState: ServersContextState = {
        allServers: servers,
        initialize,
        initialized,
        joinableServers: servers.filter(x => x.guildId !== null)
    }

    return (
        <ServersContext.Provider value={providerState}>
            {children}
        </ServersContext.Provider>
    )
}

export default React.memo(ServersProvider);