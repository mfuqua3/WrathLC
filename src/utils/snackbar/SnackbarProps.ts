import { SnackbarPosition } from "./SnackbarPosition";
import { SnackbarType } from "./SnackbarType";

export interface SnackbarProps {
    type?: SnackbarType;
    position?: SnackbarPosition;
    message: string;
}
