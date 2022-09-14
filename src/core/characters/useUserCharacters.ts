import {useContext} from "react"
import {UserCharactersContext} from "./UserCharactersProvider";

function useUserCharacters() {
    const userProviderState = useContext(UserCharactersContext);
    if (userProviderState === null) {
        throw Error("useGuildCharacters must be used within a GuildCharactersProvider.")
    }
    return userProviderState;
}

export default useUserCharacters;