import React, { ReactNode, useState } from "react";
import { MenuContext } from "./MenuContext";
import { MenuRef } from "./MenuRef";
import { MenuState } from "./MenuState";

function MenuProvider({ children }: { children: ReactNode }) {
    const [menu, setMenu] = useState<MenuRef | null>(null);

    function open(anchorElement: Element): string {
        if (menu?.anchorEl === anchorElement) {
            return menu.id;
        }
        const id = "id" + Math.random().toString(16).slice(2);
        setMenu({
            id,
            anchorEl: anchorElement,
        });
        return id;
    }

    const state: MenuState = {
        open,
        anchorEl: menu?.anchorEl,
        menuId: menu?.id ?? "",
    };
    return <MenuContext.Provider value={state}>{children}</MenuContext.Provider>;
}

export default React.memo(MenuProvider);
