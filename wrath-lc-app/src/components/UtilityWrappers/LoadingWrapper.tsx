import React from "react";
import {Box, CircularProgress, Fade, Grid, Stack, Typography} from "@mui/material";
import {WrapperProps} from "./WrapperProps";

export interface LoadingWrapperProps extends WrapperProps {
    loading: boolean;
    text?: string;
    renderChildren?: boolean;
}

function LoadingWrapper({children, loading, ...props}: LoadingWrapperProps) {
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
        <>
            {(!loading || props.renderChildren) && children}
            {
                <Fade in={loading} unmountOnExit={true}>
                    <Box display={"flex"} alignItems={"center"} justifyContent={"center"} flexDirection={"column"}
                         height={"100%"} width={"100%"} onClick={(e) => e.preventDefault()}>
                        <Stack spacing={1} alignItems={"center"}>
                            {props.text && <Typography variant={"h6"}>{props.text}</Typography>}
                            <CircularProgress size="3rem"/>
                        </Stack>
                    </Box>
                </Fade>
            }
        </>
    );
}

export default React.memo(LoadingWrapper);
