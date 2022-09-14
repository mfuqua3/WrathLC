import {WowClassModel} from "../../domain/models";

export function useWowClasses(): WowClassModel[] {
    const wowClasses: WowClassModel[] = [
        {id: 1, name: "Warrior"},
        {id: 2, name: "Paladin"},
        {id: 3, name: "Hunter"},
        {id: 4, name: "Rogue"},
        {id: 5, name: "Priest"},
        {id: 6, name: "Death Knight"},
        {id: 7, name: "Shaman"},
        {id: 8, name: "Mage"},
        {id: 9, name: "Warlock"},
        {id: 10, name: "Druid"}
    ]
    return wowClasses;
}