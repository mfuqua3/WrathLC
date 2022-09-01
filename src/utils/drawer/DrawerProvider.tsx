import React, {ReactNode, useState} from "react";
import {DrawerState} from "./DrawerState";
import {DrawerProps} from "./DrawerProps";
import {DrawerContext} from "./DrawerContext";

function DrawerProvider({children}: { children: ReactNode }) {
    const [state, setState] = useState<DrawerState>({
        isOpen: false,
        anchor: "left",
        content: <></>,
        open,
        close
    })

    function open(drawerProps?: DrawerProps) {
        setState(prev => ({...prev, ...drawerProps, isOpen: true, anchor: (drawerProps?.anchor ?? prev.anchor)}));
    }

    function close() {
        setState(prev => ({...prev, isOpen: false}));
    }

    return (
        <DrawerContext.Provider value={state}>
            {children}
        </DrawerContext.Provider>
    )
}

export default React.memo(DrawerProvider);