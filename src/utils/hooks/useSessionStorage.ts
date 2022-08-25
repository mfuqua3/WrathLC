export interface SessionStorageProps {
    setValue(value: string): void;

    getValue(): string | null;

    clearValue(): void;
}

export function useSessionStorage(key: string): SessionStorageProps {
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
