import {Character, GuildCharacter, Paginated} from "../domain/models";
import {CreateCharacter} from "../domain/requests";
import axios from "axios";

interface CharactersApi {
    createCharacter(request: CreateCharacter) : Promise<Character>;
    getUserCharacters(): Promise<Character[]>;
    getGuildCharacters(): Promise<Paginated<GuildCharacter>>;
}

class CharactersAccess implements CharactersApi{
    private apiRoot = process.env.REACT_APP_API_ROOT + "/characters";

    async createCharacter(request: CreateCharacter): Promise<Character> {
        const resp = await axios.post<Character>(this.apiRoot, request);
        return resp.data;
    }

    async getUserCharacters(): Promise<Character[]> {
        const path = process.env.REACT_APP_API_ROOT + "/users/@me/characters";
        const resp = await axios.get<Character[]>(path);
        return resp.data;
    }

    async getGuildCharacters(): Promise<Paginated<GuildCharacter>> {
        const resp = await axios.get<Paginated<GuildCharacter>>(this.apiRoot);
        return resp.data;
    }
}
export default new CharactersAccess() as CharactersApi;