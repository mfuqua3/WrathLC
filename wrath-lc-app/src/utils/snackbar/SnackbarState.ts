import {SnackbarProps} from "./SnackbarProps";

export interface SnackbarState {
    props: SnackbarProps;
    open: boolean;

    onClose(): void;

    showMessage(props: SnackbarProps): void;
}
