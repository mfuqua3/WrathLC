import { ModalProps } from "./ModalProps";

export interface ModalState {
    component: JSX.Element | null;
    props: ModalProps;

    showModal(component: JSX.Element, props: ModalProps): void;

    hideModal(): void;
}
