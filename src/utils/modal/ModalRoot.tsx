import React from "react";
import { ModalSize } from "./ModalSize";
import { Box, Modal } from "@mui/material";
import { ModalConsumer } from "./ModalConsumer";

const modalSize = (size: ModalSize) => {
    switch (size) {
        case "small":
            return "25%";
        case "medium":
            return "50%";
        case "large":
            return "75%";
        case "fullscreen":
            return "100%";
        default:
            return "inherit";
    }
};

function style(size: ModalSize) {
    return {
        position: "absolute",
        top: "50%",
        left: "50%",
        transform: "translate(-50%, -50%)",
        width: modalSize(size),
        maxHeight: "85vh",
        bgcolor: "background.paper",
        overflowY: "auto",
        border: "2px solid #000",
        boxShadow: 24,
    };
}

function ModalRoot() {
    return (
        <ModalConsumer>
            {(state) =>
                state?.component && (
                    <Modal open={state.props.isOpen} onClose={state.hideModal}>
                        <Box sx={style(state.props.size)}>{state.component}</Box>
                    </Modal>
                )
            }
        </ModalConsumer>
    );
}

export default React.memo(ModalRoot);
