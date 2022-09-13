import {ModalSize} from "./ModalSize";
import {ModalContext} from "./ModalContext";
import {useContext} from "react";

export function useModal(size?: ModalSize) {
    const context = useContext(ModalContext);
    if (context === null) {
        throw Error("useModal must be used within a Modal Provider.");
    }
    return {
        showModal: (component: JSX.Element) => context.showModal(component, {isOpen: true, size}),
        hideModal: () => context.hideModal(),
    };
}
