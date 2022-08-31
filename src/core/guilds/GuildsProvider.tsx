import React, {ReactNode, useEffect, useState} from "react";
import {GuildsProviderState, GuildsState} from "./GuildsState";
import {GuildsActions} from "./GuildsActions";
import {useApi, useSessionStorage} from "../../utils/hooks";
import {GuildDetail, GuildSummary} from "../../domain/models";
import {CreateGuild, JoinGuild, SelectGuild} from "../../domain/requests";
import {GuildsApi} from "../../api";
import {useAuth} from "../../utils/auth";

export interface GuildsContextState {
    state: GuildsState;
    actions: GuildsActions;
}

export const GuildsContext = React.createContext<GuildsContextState | null>(null);
const GuildStorageKey = "current-guild";

function GuildsProvider({children}: { children: ReactNode }) {
    const invocator = useApi(GuildsApi);
    const {getValue, setValue, clearValue} = useSessionStorage(GuildStorageKey)
    const [currentGuild, setCurrentGuild] = useState<GuildDetail | null>(getCurrentGuildFromStorage());
    const [guilds, setGuilds] = useState<GuildSummary[]>([]);
    const [providerState, setProviderState] = useState<GuildsProviderState>("UNINITIALIZED");
    const {user} = useAuth();

    useEffect(() => {
        if (user === null) {
            setProviderState("UNINITIALIZED");
            return;
        }
        setProviderState("LOADING");
        invocator
            .invoke(api => api.getGuilds())
            .then((guilds) => {
                setGuilds(guilds);
                if (currentGuild && !guilds.some(g => g.id === currentGuild.id)) {
                    clearValue();
                    setCurrentGuild(null);
                }
                setProviderState("READY");
            })
            .catch(() => setProviderState("ERROR"));
    }, [user]);

    function getCurrentGuildFromStorage(): GuildDetail | null {
        const storedValue = getValue();
        if (!storedValue) return null;
        return JSON.parse(storedValue);
    }

    async function createGuild(request: CreateGuild): Promise<GuildDetail> {
        const created = await invocator.invoke((api) => api.createGuild(request));
        setGuilds((prev) => [...prev, {...created}]);
        return created;
    }

    async function joinGuild(request: JoinGuild): Promise<GuildDetail> {
        return await invocator.invoke(async api => {
            await api.joinGuild(request.guildId);
            return await api.getGuild(request.guildId);
        })
    }

    async function selectGuild(request: SelectGuild): Promise<GuildDetail> {
        const guild = await invocator.invoke(api => api.getGuild(request.guildId));
        setValue(JSON.stringify(guild));
        setCurrentGuild(guild);
        return guild;
    }

    const state: GuildsState = {
        currentGuild,
        guilds,
        state: providerState
    }
    const actions: GuildsActions = {
        createGuild,
        joinGuild,
        selectGuild
    }
    return (
        <GuildsContext.Provider value={{state, actions}}>
            {children}
        </GuildsContext.Provider>
    )
}

export default React.memo(GuildsProvider);