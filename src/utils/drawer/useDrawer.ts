import {useContext} from "react";
import {DrawerProps} from "./DrawerProps";
import {DrawerContext} from "./DrawerContext";

export interface DrawerController {
    isOpen: boolean;

    open(): void;

    close(): void;
}

export function useDrawer(props?: DrawerProps): DrawerController {
    const drawerState = useContext(DrawerContext);
    if (drawerState === null) {
        throw Error("useDrawer hook must be used within a DrawerProvider");
    }
    return {
        isOpen: drawerState.isOpen,
        close: drawerState.close,
        open: () => drawerState.open(props)
    }
}