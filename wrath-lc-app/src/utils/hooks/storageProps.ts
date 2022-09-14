export interface StorageProps {
    setValue(value: string): void;

    getValue(): string | null;

    clearValue(): void;
}