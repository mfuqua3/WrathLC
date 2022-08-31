import React, {useState} from "react";
import {AppBar, Grid, IconButton, Stack, Toolbar} from "@mui/material";
import "./TopNav.css";
import TopNavUserMenu from "./TopNav.UserMenu";
import {useNavigate} from "react-router-dom";
import {TopNavMenuItem} from "./TopNav.MenuItem";
import HomeIcon from '@mui/icons-material/Home';
import {useAuth} from "../../utils/auth";
import NavigationDrawer from "../NavigationDrawer/NavigationDrawer";
import {NavigationDrawerListItem} from "../NavigationDrawer";
import MenuIcon from "@mui/icons-material/Menu";

function TopNavXS() {
    const navigate = useNavigate();
    const [drawerOpen, setDrawerOpen] = useState(false);
    const drawerItems: NavigationDrawerListItem[] = [
        {text: "Area1", onClick: () => navigate("area1")},
        {text: "Area2", onClick: () => navigate("area2")}
    ]
    const {loading, isAuthenticated, userManager} = useAuth();
    async function handleSignIn() {
        await userManager.signinRedirect();
    }
    return (
        <AppBar position="relative">
            <Toolbar variant={"dense"}>
                <Grid container justifyContent={"space-between"} alignContent={"stretch"} alignItems={"center"}>
                    <Grid item>
                        <IconButton
                            edge={"start"}
                            color={"inherit"}
                            aria-label={"menu"}
                            onClick={(e) => {
                                setDrawerOpen(true);
                            }}
                        >
                            <MenuIcon className={"menu-icon"}/>
                        </IconButton>
                    </Grid>
                    <Grid item>
                        <Stack direction={"row"}>
                            <TopNavMenuItem title={""} icon={<HomeIcon/>} onClick={() => navigate("/")}
                                            color={"primary.contrastText"}/>
                            {
                                isAuthenticated ? <TopNavUserMenu dense/> :
                                    <TopNavMenuItem title={"Sign In"} onClick={handleSignIn}
                                                    color={"primary.contrastText"}/>
                            }
                        </Stack>
                    </Grid>
                </Grid>
                <NavigationDrawer header={"WrathLC"} items={drawerItems} open={drawerOpen}
                                  onClose={() => setDrawerOpen(false)}/>
            </Toolbar>
        </AppBar>
    );
}

export default React.memo(TopNavXS);
