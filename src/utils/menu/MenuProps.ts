export interface MenuProps {
    anchorEl: Element | ((element: Element) => Element) | null | undefined;
    isOpen: boolean;

    open(anchorEl: Element): void;

    close(): void;
}
