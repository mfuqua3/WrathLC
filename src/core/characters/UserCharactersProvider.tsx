import React, {ReactNode, useEffect, useState} from "react";
import {CreateCharacterParameters, UserCharacterState} from "./CharactersState";
import {Character} from "../../domain/models";
import {ChangeCharacterNameRequest, CreateCharacter} from "../../domain/requests";
import {CharactersApi} from "../../api";
import {useCurrentGuild} from "../guilds";
import {useApi} from "../../utils/hooks";

export const UserCharactersContext = React.createContext<UserCharacterState | null>(null);

function UserCharactersProvider({children}: { children: ReactNode }) {
    const [characters, setCharacters] = useState<Character[]>()
    const api = useApi(CharactersApi)
    const currentGuild = useCurrentGuild();
    useEffect(() => {
        if (currentGuild !== null) {
            CharactersApi.getUserCharacters()
                .then(resp => setCharacters(resp));
        }
    }, [currentGuild]);
    async function reinitialize(){
        const characters = await api.invoke(api=>api.getUserCharacters());
        setCharacters(characters);
    }
    async function createNew(parameters: CreateCharacterParameters): Promise<Character> {
        const request: CreateCharacter = {...parameters, assignToMe: true};
        const result = await api.invoke(api => api.createCharacter(request), `${parameters.name} added successfully!`);
        setCharacters(prev => [...(prev ?? []), result]);
        return result;
    }

    async function deleteCharacter(characterId: number): Promise<void> {
        const characterIndex = characters?.findIndex(x => x.id === characterId);
        await api.invoke(api => api.deleteCharacter(characterId),
            `${characters && characterIndex && characterIndex >= 0 ?
                characters[characterIndex].name : "Character"} deleted successfully.`);
        if (characters && characterIndex && characterIndex >= 0) {
            setCharacters([...characters.slice(0, characterIndex), ...characters.slice(characterIndex + 1)]);
        }
    }

    async function changeCharacterName(changeNameParams: ChangeCharacterNameRequest): Promise<void>{
        const characterIndex = characters?.findIndex(x => x.id === changeNameParams.characterId);
        const result = await api.invoke(api => api.changeCharacterName(changeNameParams), "Character updated!");
        if(characters && characterIndex && characterIndex >= 0){
            setCharacters([...characters.slice(0, characterIndex), result, ...characters.slice(characterIndex + 1)]);
        }
        else{
            await reinitialize();
        }
    }

    const state: UserCharacterState = {
        characters,
        createNew,
        deleteCharacter,
        changeCharacterName
    }
    return (
        <UserCharactersContext.Provider value={state}>
            {children}
        </UserCharactersContext.Provider>
    )
}

export default React.memo(UserCharactersProvider);