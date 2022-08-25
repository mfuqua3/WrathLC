import { MenuProps } from "./MenuProps";
import { MenuContext } from "./MenuContext";
import { useContext, useState } from "react";

export function useMenu(): MenuProps {
    const state = useContext(MenuContext);
    if (state === null) {
        throw new Error("useMenu must be used within a Menu provider");
    }
    const [id, setId] = useState<string | null>(null);

    function open(anchorEl: Element): void {
        if (state === null) {
            return;
        }
        const menuId = state.open(anchorEl);
        setId(menuId);
    }

    function close(): void {
        setId(null);
    }

    return {
        open,
        close,
        anchorEl: state.anchorEl,
        isOpen: id === state.menuId,
    };
}
