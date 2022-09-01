import React from "react";
import {DrawerConsumer} from "./DrawerConsumer";
import {Box, Drawer} from "@mui/material";
import ScrollWrapper from "../../components/UtilityWrappers/ScrollWrapper";

const container = window !== undefined ? () => window.document.body : undefined;
const drawerWidth = 240;

function DrawerRoot() {
    return (
        <DrawerConsumer>{(state) =>
            state && (
                <Drawer
                    anchor={state.anchor}
                    container={container}
                    variant={"temporary"}
                    open={state.isOpen}
                    onClose={state.close}
                    ModalProps={{
                        keepMounted: true, // Better open performance on mobile.
                    }}
                    sx={{
                        display: {xs: 'block', sm: 'none'},
                        '& .MuiDrawer-paper': {boxSizing: 'border-box', width: drawerWidth},
                    }}>
                    <Box onClick={() => {
                        if (state?.isOpen) {
                            state.close()
                        }
                    }} sx={(theme)=>(
                        {
                            textAlign: 'center',
                            height: "100%",
                            width: "100%",
                            background: theme.palette.secondary.light
                        })}>
                            {state.content}
                    </Box>
                </Drawer>
            )
        }
        </DrawerConsumer>
    )
}

export default React.memo(DrawerRoot);