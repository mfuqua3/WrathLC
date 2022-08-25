import React from "react";
import { CircularProgress, Fade, Grid } from "@mui/material";
import { WrapperProps } from "./WrapperProps";

export interface LoadingWrapperProps extends WrapperProps {
    loading: boolean;
}

function LoadingWrapper({ children, loading }: LoadingWrapperProps) {
    const sx = {
        wrapper: {
            display: "flex",
            position: "fixed",
            flexDirection: "column",
            top: 0,
            right: 0,
            bottom: 0,
            left: 0,
            zIndex: 2147483647,
        },
        spinner: {
            margin: "auto",
        },
    };
    return (
        <React.Fragment>
            {children}
            {
                <Fade in={loading} unmountOnExit={true}>
                    <Grid container onClick={(e) => e.preventDefault()} sx={sx.wrapper}>
                        <CircularProgress size="4rem" sx={sx.spinner} />
                    </Grid>
                </Fade>
            }
        </React.Fragment>
    );
}

export default React.memo(LoadingWrapper);
