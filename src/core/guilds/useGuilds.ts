import {useContext} from "react";
import {GuildsContext, GuildsContextState} from "./GuildsProvider";
import {GuildDetail} from "../../domain/models";

export function useGuilds(): GuildsContextState {
    const state = useContext(GuildsContext);
    if (state === null) {
        throw Error("useGuilds must be used within a GuildsProvider");
    }
    return state;
}

export function useCurrentGuild(): GuildDetail | null{
    const {state: {currentGuild}} = useGuilds();
    return currentGuild;
}