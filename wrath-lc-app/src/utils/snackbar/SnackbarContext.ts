import {SnackbarState} from "./SnackbarState";
import React from "react";

export const SnackbarContext = React.createContext<SnackbarState | null>(null);
