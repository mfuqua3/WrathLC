import React, { useContext } from "react";
import { Alert, AlertColor, Snackbar } from "@mui/material";
import { SnackbarContext } from "./SnackbarContext";

const SnackbarRoot = (): JSX.Element => {
    //const classes = useStyles();
    const state = useContext(SnackbarContext);
    if (state === null) {
        throw new Error("SnackbarRoot can only be declared within a SnackbarProvider");
    }
    const {
        open,
        props: { position, type, message },
        onClose,
    } = state;

    function verticalAnchor(): "bottom" | "top" {
        switch (position) {
            case "BottomCenter":
            case "BottomLeft":
            case "BottomRight":
                return "bottom";
            case "TopCenter":
            case "TopLeft":
            case "TopRight":
                return "top";
        }
        throw new Error(`Unhandled position case ${position} in SnackbarRoot`);
    }

    function horizontalAnchor(): "center" | "left" | "right" {
        switch (position) {
            case "BottomCenter":
            case "TopCenter":
                return "center";
            case "BottomLeft":
            case "TopLeft":
                return "left";
            case "BottomRight":
            case "TopRight":
                return "right";
        }
        throw new Error(`Unhandled position case ${position} in SnackbarRoot`);
    }

    function severity(): AlertColor {
        switch (type) {
            case "Information":
                return "info";
            case "Error":
                return "error";
            case "Success":
                return "success";
            case "Warning":
                return "warning";
        }
        throw new Error(`Unhandled snackbar type ${type} in SnackbarRoot`);
    }

    const sx = {
        alignSelf: "center",
        alignContent: "center",
        alignItems: "center",
    };
    return (
        <Snackbar
            open={open}
            anchorOrigin={{ vertical: verticalAnchor(), horizontal: horizontalAnchor() }}
            autoHideDuration={4000}
            onClose={onClose}
            sx={sx}
        >
            <Alert severity={severity()} elevation={6} variant={"filled"} onClose={onClose} sx={sx}>
                {message}
            </Alert>
        </Snackbar>
    );
};

export default SnackbarRoot;
