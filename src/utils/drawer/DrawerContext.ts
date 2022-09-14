import {DrawerState} from "./DrawerState";
import React from "react";

export const DrawerContext = React.createContext<DrawerState | null>(null);