import React, {ReactNode, useEffect, useState} from "react";
import {CreateCharacterParameters, UserCharacterState} from "./CharactersState";
import {Character} from "../../domain/models";
import {CreateCharacter} from "../../domain/requests";
import {CharactersApi} from "../../api";
import {useCurrentGuild} from "../guilds";

export const UserCharactersContext = React.createContext<UserCharacterState | null>(null);

function UserCharactersProvider({children}: { children: ReactNode }) {
    const [characters, setCharacters] = useState<Character[]>()
    const currentGuild = useCurrentGuild();
    useEffect(()=>{
        CharactersApi.getUserCharacters()
            .then(resp => setCharacters(resp));
    },[currentGuild]);
    async function createNew(paramaters: CreateCharacterParameters): Promise<Character>{
        const request: CreateCharacter = {...paramaters, assignToMe: true};
        const result =  await CharactersApi.createCharacter(request);
        setCharacters(prev=>[...(prev ?? []), result]);
        return result;
    }
    const state: UserCharacterState ={
        characters,
        createNew
    }
    return (
        <UserCharactersContext.Provider value={state}>
            {children}
        </UserCharactersContext.Provider>
    )
}

export default React.memo(UserCharactersProvider);