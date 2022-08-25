import React, {ReactNode, useState} from "react";
import {DrawerState} from "./DrawerState";
import {DrawerProps} from "./DrawerProps";
import { DrawerContext } from "./DrawerContext";
import DrawerRoot from "./DrawerRoot";

function DrawerProvider({children}: {children: ReactNode}){
    const [state, setState] = useState<DrawerState>({
        isOpen: false,
        header: <></>,
        content: <></>,
        open,
        close
    })
    function open(props: DrawerProps) {
        setState(prev=>({...prev, ...props, isOpen: true}));
    }
    function close() {
        setState(prev=>({...prev, isOpen: false}));
    }
    return (
        <DrawerContext.Provider value={state}>
            <DrawerRoot />
            {children}
        </DrawerContext.Provider>
    )
}

export default React.memo(DrawerProvider);