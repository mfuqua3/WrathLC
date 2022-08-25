import {DrawerProps} from "./DrawerProps";
import {ReactNode} from "react";

export interface DrawerState{
    isOpen: boolean;
    open(props: DrawerProps): void;
    close(): void;
    header: ReactNode;
    content: ReactNode |ReactNode[];
}