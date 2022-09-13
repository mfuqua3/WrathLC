import {ChangeCharacterNameRequest, CreateCharacter} from "../../domain/requests";
import {Character, GuildCharacter} from "../../domain/models";
import {PaginationState} from "../../utils/hooks";

export type CreateCharacterParameters = Omit<CreateCharacter, "assignToMe">;

export interface CharactersState<T> {
    characters?: T[];

    createNew(parameters: CreateCharacterParameters): Promise<T>;
    deleteCharacter(characterId: number): Promise<void>;
    changeCharacterName(changeNameParams: ChangeCharacterNameRequest): Promise<void>;
}

export type GuildCharacterState =
    Omit<CharactersState<GuildCharacter>, "deleteCharacter" | "changeCharacterName">
    & Pick<PaginationState<GuildCharacter>, "next" | "itemsRemaining">;
export type UserCharacterState = CharactersState<Character>;