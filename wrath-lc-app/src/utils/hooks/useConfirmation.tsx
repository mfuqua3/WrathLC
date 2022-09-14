import React from "react";
import {ConfirmationDialog, ConfirmationDialogProps} from "../../components/Dialogs";
import {useModal} from "../modal";

export function useConfirmation(): (props: ConfirmationDialogProps) => void {
    const {showModal, hideModal} = useModal("large");

    function showDialog(props: ConfirmationDialogProps) {
        const {onCancelled, onConfirmed, ...rest} = props;
        showModal(<ConfirmationDialog
            onConfirmed={
                async () => {
                    if (onConfirmed) {
                        await onConfirmed();
                    }
                    hideModal();
                }
            } onCancelled={
            async () => {
                hideModal();
                if (onCancelled) {
                    await onCancelled();
                }
            }
        } {...rest}/>);
    }

    return showDialog;
}
