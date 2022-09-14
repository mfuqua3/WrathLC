import React, {ReactNode, useState} from "react";
import {SnackbarContext} from "./SnackbarContext";
import {SnackbarProps} from "./SnackbarProps";
import {SnackbarState} from "./SnackbarState";

export const SnackbarProvider = ({children}: { children: ReactNode }) => {
    const initialProps: SnackbarProps = {
        position: "BottomCenter",
        type: "Information",
        message: "",
    };
    const [snackbarProps, setSnackbarProps] = useState(initialProps);
    const [open, setOpen] = useState(false);

    function onClose(): void {
        setOpen(false);
    }

    function showMessage(messageProps: SnackbarProps) {
        if (messageProps.type === undefined) {
            messageProps.type = "Information";
        }
        if (!messageProps.position) {
            messageProps.position = "BottomCenter";
        }
        setSnackbarProps(messageProps);
        setOpen(true);
    }

    const snackbarState: SnackbarState = {
        open,
        props: snackbarProps,
        onClose,
        showMessage,
    };
    return (
        <SnackbarContext.Provider value={snackbarState}>
            {children}
        </SnackbarContext.Provider>
    );
};
