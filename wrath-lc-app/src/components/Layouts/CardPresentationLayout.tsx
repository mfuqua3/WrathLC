import React, {ReactNode} from "react";
import {Box, Typography} from "@mui/material";

export interface CardPresentationLayoutProps {
    children: ReactNode;
    title: string;
    action?: ReactNode;
    height?: string;
}

function CardPresentationLayout({children, ...props}: CardPresentationLayoutProps) {
    return (
        <Box display={"flex"} flexDirection={"column"} height={"100%"} p={1}>
            <Box display={"flex"} justifyContent={"space-between"} flexDirection={"row"}
                 alignItems={"center"} p={1}
                 sx={(theme) => (
                     {
                         backgroundColor: theme.palette.secondary.main
                     })
                 }>
                <Typography variant={"h6"}>{props.title}</Typography>
                <Box>{props.action}</Box>
            </Box>
            <Box flexGrow={1} p={1}>
                {children}
            </Box>
        </Box>
    );
}

export default React.memo(CardPresentationLayout);