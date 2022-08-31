import {useContext} from "react";
import {GuildsContext, GuildsContextState} from "./GuildsProvider";

export function useGuilds(): GuildsContextState {
    const state = useContext(GuildsContext);
    if (state === null) {
        throw Error("useGuilds must be used within a GuildsProvider");
    }
    return state;
}