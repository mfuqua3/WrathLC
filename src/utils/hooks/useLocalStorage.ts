import {StorageProps} from "./storageProps";

export function useLocalStorage(key: string): StorageProps {
    function setValue(value: string): void {
        localStorage.setItem(key, value);
    }

    function getValue(): string | null {
        return localStorage.getItem(key);
    }

    function clearValue(): void {
        localStorage.removeItem(key);
    }

    return {
        setValue,
        getValue,
        clearValue,
    };
}
