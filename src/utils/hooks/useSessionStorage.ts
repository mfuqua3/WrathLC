import {StorageProps} from "./storageProps";

export function useSessionStorage(key: string): StorageProps {
    function setValue(value: string): void {
        sessionStorage.setItem(key, value);
    }

    function getValue(): string | null {
        return sessionStorage.getItem(key);
    }

    function clearValue(): void {
        sessionStorage.removeItem(key);
    }

    return {
        setValue,
        getValue,
        clearValue,
    };
}
