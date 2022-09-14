import React, {ReactNode, useEffect, useState} from "react";
import {GuildsProviderState, GuildsState} from "./GuildsState";
import {GuildsActions} from "./GuildsActions";
import {useApi, useLocalStorage} from "../../utils/hooks";
import {GuildDetail, GuildSummary} from "../../domain/models";
import {CreateGuild, JoinGuild, SelectGuild} from "../../domain/requests";
import {GuildsApi} from "../../api";
import {useAuth} from "../../utils/auth";
import GuildsAxiosInterceptor from "./GuildsAxiosInterceptor";

export interface GuildsContextState {
    state: GuildsState;
    actions: GuildsActions;
}

export const GuildsContext = React.createContext<GuildsContextState | null>(null);
const GuildStorageKey = "current-guild";

function GuildsProvider({children}: { children: ReactNode }) {
    const invocator = useApi(GuildsApi);
    const {getValue, setValue, clearValue} = useLocalStorage(GuildStorageKey)
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
                setGuilds(guilds ?? []);
                if (currentGuild && !guilds.some(g => g.id === currentGuild.id)) {
                    clearValue();
                    setCurrentGuild(guilds?.length > 0 ? guilds[0] : null);
                } else if (currentGuild === null && guilds && guilds.length > 0) {
                    setCurrentGuild(guilds[0]);
                }
                setProviderState("READY");
            })
            .catch((e) => {
                console.log(e);
                setProviderState("ERROR")
            });
    }, [user]);

    function getCurrentGuildFromStorage(): GuildDetail | null {
        const storedValue = getValue();
        if (!storedValue) {
            return null;
        }
        let stored: object | null;
        try {
            stored = JSON.parse(storedValue);
        } catch {
            clearValue();
            return null;

        }
        if (stored === null || !("id" in stored && "name" in stored)) {
            clearValue();
            stored = null;
        }
        return stored as GuildDetail;
    }

    async function createGuild(request: CreateGuild): Promise<GuildDetail> {
        setProviderState("LOADING");
        try {
            const created = await invocator.invoke((api) => api.createGuild(request));
            setGuilds((prev) => [...prev, {...created}]);
            saveCurrentGuild(created);
            setProviderState("READY");
            return created;
        } catch (e) {
            setProviderState("ERROR");
            throw e;
        }
    }

    async function joinGuild(request: JoinGuild): Promise<GuildDetail> {
        setProviderState("LOADING");
        try {
            const guild = await invocator.invoke(async api => {
                await api.joinGuild(request.guildId);
                return await api.getGuild(request.guildId);
            })
            setGuilds((prev) => [...prev, {...guild}]);
            saveCurrentGuild(guild);
            setProviderState("READY");
            return guild;
        } catch (e) {
            setProviderState("ERROR");
            throw e;
        }
    }

    async function selectGuild(request: SelectGuild): Promise<GuildDetail> {
        setProviderState("LOADING");
        try {
            const guild = await invocator.invoke(api => api.getGuild(request.guildId));
            saveCurrentGuild(guild);
            setProviderState("READY");
            return guild;
        } catch (e) {
            setProviderState("ERROR");
            throw e;
        }
    }

    function saveCurrentGuild(guild: GuildDetail) {
        setValue(JSON.stringify(guild));
        setCurrentGuild(guild);
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
            <GuildsAxiosInterceptor/>
            {children}
        </GuildsContext.Provider>
    )
}

export default React.memo(GuildsProvider);