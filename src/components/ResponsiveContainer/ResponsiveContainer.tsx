import React, {ReactNode} from "react";
import {useMediaQuery, useTheme} from "@mui/material";

export interface ResponsiveContainerProps {
    lower: ReactNode;
    upper: ReactNode;
}

function ResponsiveContainer({lower, upper}: ResponsiveContainerProps) {
    const theme = useTheme();
    const useUpper = useMediaQuery(theme.breakpoints.up("sm"));
    return (
        <>
            {useUpper && upper}
            {!useUpper && lower}
        </>
    );
}

export default React.memo(ResponsiveContainer);
