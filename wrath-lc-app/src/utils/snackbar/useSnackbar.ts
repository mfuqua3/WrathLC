import React from "react";
import {SnackbarContext} from "./SnackbarContext";
import {SnackbarProps} from "./SnackbarProps";

export const useSnackbar = (): ((props: SnackbarProps) => void) => {
    const state = React.useContext(SnackbarContext);
    if (state === null) {
        throw new Error("useSnackbar must be used within a Snackbar Provider");
    }
    return state.showMessage;
};
