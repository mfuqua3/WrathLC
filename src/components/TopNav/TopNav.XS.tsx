import React from "react";
import {AppBar, Grid, IconButton, Stack, Toolbar} from "@mui/material";
import {TopNavMenuItem} from "./TopNav.MenuItem";
import {useAuth} from "../../utils/auth";
import MenuIcon from "@mui/icons-material/Menu";
import {useDrawer} from "../../utils/drawer";
import SettingsIcon from '@mui/icons-material/Settings';
import NavigationDrawer from "../NavigationDrawer/NavigationDrawer";
import AuthWrapper from "../UtilityWrappers/AuthWrapper";
import {SettingsDrawer} from "../SettingsDrawer";

function TopNavXS() {
    const {userManager} = useAuth();
    const navigationDrawer = useDrawer({content: <NavigationDrawer/>, anchor: "left"});
    const settingsDrawer = useDrawer({content: <SettingsDrawer />, anchor: "right"});

    async function handleSignIn() {
        await userManager.signinRedirect();
    }

    return (
        <AppBar position="relative">
            <Toolbar variant={"dense"}>
                <Grid container justifyContent={"space-between"} alignContent={"stretch"} alignItems={"center"}>
                    <Grid item>
                        <AuthWrapper>
                            <IconButton
                                edge={"start"}
                                color={"inherit"}
                                aria-label={"menu"}
                                onClick={() => {
                                    navigationDrawer.open();
                                }}
                            >
                                <MenuIcon className={"menu-icon"}/>
                            </IconButton>
                        </AuthWrapper>
                    </Grid>
                    <Grid item>
                        <Stack direction={"row"}>
                            <AuthWrapper fallback={
                                <TopNavMenuItem title={"Sign In"} onClick={handleSignIn}/>
                            }>
                                <TopNavMenuItem title={""} icon={<SettingsIcon/>} onClick={() => settingsDrawer.open()}
                                                color={"primary.contrastText"} iconPositioning={"end"}/>
                            </AuthWrapper>
                        </Stack>
                    </Grid>
                </Grid>
            </Toolbar>
        </AppBar>
    );
}

export default React.memo(TopNavXS);
