import {Character, GuildCharacter, Paginated} from "../domain/models";
import {ChangeCharacterNameRequest, CreateCharacter} from "../domain/requests";
import axios from "axios";

interface CharactersApi {
    createCharacter(request: CreateCharacter): Promise<Character>;

    getUserCharacters(): Promise<Character[]>;

    getGuildCharacters(): Promise<Paginated<GuildCharacter>>;

    changeCharacterName(request: ChangeCharacterNameRequest): Promise<Character>;

    deleteCharacter(characterId: number): Promise<void>
}

class CharactersAccess implements CharactersApi {
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

    async changeCharacterName({characterId, ...body}: ChangeCharacterNameRequest): Promise<Character> {
        const resp = await axios.put<Character>(`${this.apiRoot}/${characterId}/name`, body);
        return resp.data;
    }

    async deleteCharacter(characterId: number): Promise<void> {
        await axios.delete(`${this.apiRoot}/${characterId}`);
    }
}

export default new CharactersAccess() as CharactersApi;