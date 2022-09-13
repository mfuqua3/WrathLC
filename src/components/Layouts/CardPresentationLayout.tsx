import React, {ReactNode} from "react";
import {Card, CardContent, CardHeader, Stack} from "@mui/material";

export interface CardPresentationLayoutProps {
    children: ReactNode;
    title: string;
    action?: ReactNode;
    height?: string;
}

function CardPresentationLayout({children, ...props}: CardPresentationLayoutProps) {
    return (
        <Stack direction={"column"} p={1} height={"100%"}>
            <Card sx={{m: 1, height: "100%"}}>
                <CardHeader title={props.title} sx={(theme) => ({
                    backgroundColor: theme.palette.secondary.main,
                    fontSize: "8px"
                })} action={props.action}/>
                <CardContent sx={{height: props.height ?? "100%"}}>
                    {children}
                </CardContent>
            </Card>
        </Stack>
    );
}

export default React.memo(CardPresentationLayout);
