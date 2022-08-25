import { ModalState } from "./ModalState";
import React from "react";

export const ModalContext = React.createContext<ModalState | null>(null);
