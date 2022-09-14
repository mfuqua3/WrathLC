import React from "react";
import {MenuState} from "./MenuState";

export const MenuContext = React.createContext<MenuState | null>(null);
