import React, { ReactNode, useEffect, useState } from "react";
import { ModalContext } from "./ModalContext";
import ModalRoot from "./ModalRoot";
import { ModalProps } from "./ModalProps";
import { ModalState } from "./ModalState";

function ModalProvider({ children }: { children: ReactNode }): JSX.Element {
    const initialState: ModalState = {
        component: null,
        props: { isOpen: false, size: "inherit" },
        showModal,
        hideModal,
    };
    const [modalState, setModalState] = useState<ModalState>(initialState);
    useEffect(() => {
        window.addEventListener("beforeunload", hideModal);
        return () => {
            window.removeEventListener("beforeunload", hideModal);
        };
    }, []);
    function showModal(component: JSX.Element, modalProps: ModalProps): void {
        setModalState({ ...modalState, component: component, props: modalProps });
    }
    function hideModal(): void {
        setModalState(initialState);
    }
    return (
        <ModalContext.Provider value={modalState}>
            <ModalRoot />
            {children}
        </ModalContext.Provider>
    );
}

export default React.memo(ModalProvider);
