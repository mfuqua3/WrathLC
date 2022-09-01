import {ReactNode} from "react";

export type DrawerAnchor ="left" | "right" | "top" | "bottom";

export interface DrawerProps {
    content: ReactNode;
    anchor?: DrawerAnchor
}