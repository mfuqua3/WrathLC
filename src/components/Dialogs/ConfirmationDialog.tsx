import React from "react";
import {
    Box,
    Button,
    Card,
    CardActionArea,
    CardActions,
    CardContent,
    CardHeader,
    Typography
} from "@mui/material";

export interface ConfirmationDialogProps {
    title?: string;
    prompt: string;
    cancel?: string;
    confirm?: string;
    confirmColor? : ButtonColor;
    cancelColor? : ButtonColor;

    onConfirmed?(): Promise<void>;

    onCancelled?(): Promise<void>;
}
export type ButtonColor = 'inherit' | 'primary' | 'secondary' | 'success' | 'error' | 'info' | 'warning';
function ConfirmationDialog(props: ConfirmationDialogProps) {
    return (
        <Card>
            <CardHeader title={props.title ?? "Please confirm"}/>
            <CardActionArea>
                <CardContent>
                    <Box p={1}>
                        <Typography>{props.prompt}</Typography>
                    </Box>
                </CardContent>
            </CardActionArea>
            <CardActions>
                <Button variant={"contained"} color={props.cancelColor ?? "secondary"}
                        onClick={props.onCancelled}>{props.cancel ?? "Cancel"}</Button>
                <Button variant={"contained"} color={props.confirmColor ?? "primary"} onClick={props.onConfirmed}>
                    {props.confirm ?? "Confirm"}
                </Button>
            </CardActions>
        </Card>
    );
}

export default React.memo(ConfirmationDialog);
