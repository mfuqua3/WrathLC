import {DrawerAnchor, DrawerProps} from "./DrawerProps";
import {ReactNode} from "react";

export interface DrawerState {
    isOpen: boolean;
    content: ReactNode;
    anchor: DrawerAnchor

    open(props?: DrawerProps): void;

    close(): void;
}