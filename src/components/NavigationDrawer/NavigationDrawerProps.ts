import {ReactNode} from "react";

export interface NavigationDrawerProps {
    header: ReactNode | string;
    items: NavigationDrawerListItem[];
    open: boolean;
    onClose(): void;
}

export interface NavigationDrawerListItem {
    onClick(): void;
    text: string;
}