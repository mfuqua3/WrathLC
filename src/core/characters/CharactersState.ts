import {CreateCharacter} from "../../domain/requests";
import {Character, GuildCharacter} from "../../domain/models";
import {PaginationState} from "../../utils/hooks";

export type CreateCharacterParameters = Omit<CreateCharacter, "assignToMe">;

export interface CharactersState<T> {
    characters?: T[];

    createNew(parameters: CreateCharacterParameters): Promise<T>
}

export type GuildCharacterState = CharactersState<GuildCharacter> & Pick<PaginationState<GuildCharacter>, "next" | "itemsRemaining">;
export type UserCharacterState = CharactersState<Character>;