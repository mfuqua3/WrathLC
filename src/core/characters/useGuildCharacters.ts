import {useContext} from "react"
import {GuildCharactersContext} from "./GuildCharactersProvider";

function useGuildCharacters() {
    const guildProviderState = useContext(GuildCharactersContext);
    if (guildProviderState === null) {
        throw Error("useGuildCharacters must be used within a GuildCharactersProvider.")
    }
    return guildProviderState;
}

export default useGuildCharacters;