import {ReactNode} from "react";

export interface DrawerProps {
    header: ReactNode;
    content: ReactNode | ReactNode[];
}