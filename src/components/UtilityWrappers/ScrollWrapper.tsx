import React from "react";
import {Box} from "@mui/material";
import {WrapperProps} from "./WrapperProps";

function ScrollWrapper({children}: WrapperProps) {
    return (
        <Box
            sx={{
                overflowY: "auto",
                height: "inherit",
                width: "100%",
                display: "block",
                scrollbarWidth: "initial",
            }}
        >
            {children}
        </Box>
    );
}

export default React.memo(ScrollWrapper);
