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
        // <Stack direction={"column"} p={1} height={"100%"}>
        //     <Card sx={{m: 1, height: "100%"}}>
        //         <CardHeader title={props.title} sx={(theme) => ({
        //             backgroundColor: theme.palette.secondary.main,
        //             fontSize: "8px"
        //         })} action={props.action}/>
        //         <CardContent sx={{height: props.height ?? "100%"}}>
        //             {children}
        //         </CardContent>
        //     </Card>
        // </Stack>
    );
}

export default React.memo(CardPresentationLayout);