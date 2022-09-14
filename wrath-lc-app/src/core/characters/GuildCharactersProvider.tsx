import React, {ReactNode} from "react";
import {CreateCharacterParameters, GuildCharacterState} from "./CharactersState";
import {GuildCharacter} from "../../domain/models";
import {CharactersApi} from "../../api";
import {CreateCharacter} from "../../domain/requests";
import usePagination from "../../utils/hooks/usePagination";

export const GuildCharactersContext = React.createContext<GuildCharacterState | null>(null);

function GuildCharactersProvider({children}: { children: ReactNode }) {
    const {next, itemsRemaining, ...guildCharacters} = usePagination({
        pageSize: 500,
        loadItemsFunc: CharactersApi.getGuildCharacters,
        initialize: true
    })

    async function createNew(parameters: CreateCharacterParameters): Promise<GuildCharacter> {
        const request: CreateCharacter = {...parameters, assignToMe: false};
        const resp = await CharactersApi.createCharacter(request);
        await guildCharacters.invalidate();
        return {...resp, userId: null};
    }

    const state: GuildCharacterState = {
        characters: guildCharacters.allItems,
        createNew,
        next,
        itemsRemaining
    }
    return (
        <GuildCharactersContext.Provider value={state}>
            {children}
        </GuildCharactersContext.Provider>
    )
}

export default React.memo(GuildCharactersProvider);