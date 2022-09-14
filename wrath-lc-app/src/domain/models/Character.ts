import {WowClass} from "../utility-types";

export interface Character {
    id: number;
    name: string;
    class: WowClass;
    isPrimary: boolean;
}

