import {WowClass} from "../utility-types";

export interface GuildCharacter {
    id: number;
    name: string;
    class: WowClass;
    isPrimary: boolean;
    userId: string | null;

}