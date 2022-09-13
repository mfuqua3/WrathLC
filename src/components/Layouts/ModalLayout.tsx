import React, {ReactNode} from "react";
import {Box, Button, DialogActions, DialogContent, DialogTitle, Paper} from "@mui/material";
import {useModal} from "../../utils/modal";
import LoadingWrapper from "../UtilityWrappers/LoadingWrapper";

export interface ModalLayoutProps {
    loading?: boolean;
    title: string;
    minHeight?: string;
    actions?: ReactNode;
}

function ModalLayout(props: ModalLayoutProps & { children: ReactNode }) {
    const {hideModal} = useModal();
    return (
        <Box minHeight={props.minHeight ?? "20vh"}>
            <DialogTitle sx={(theme) => ({
                backgroundColor: theme.palette.secondary.main,
            })}>{props.title}</DialogTitle>
            <Paper sx={{p: 1}}>
                <DialogContent>
                    <LoadingWrapper loading={props.loading ?? false}>
                        {props.children}
                    </LoadingWrapper>
                </DialogContent>
                <DialogActions>
                    {props.actions ? props.actions : <Button color={"primary"} type={"button"}
                                                             variant={"contained"} onClick={hideModal}>
                        Okay
                    </Button>}
                </DialogActions>
            </Paper>
        </Box>
    );
}

export default React.memo(ModalLayout);
