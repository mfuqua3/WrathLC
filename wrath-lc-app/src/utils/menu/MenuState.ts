export interface MenuState {
    menuId: string;
    anchorEl: Element | ((element: Element) => Element) | null | undefined;

    open(anchorElement: Element): string;
}
