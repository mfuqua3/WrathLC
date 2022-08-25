import React from "react";
import {AppBar, Grid, Stack, Toolbar} from "@mui/material";
import "./TopNav.css";
import TopNavPopupMenu from "./TopNav.PopupMenu";
import TopNavUserMenu from "./TopNav.UserMenu";
import {useNavigate} from "react-router-dom";
import {TopNavMenuItem} from "./TopNav.MenuItem";
import HomeIcon from '@mui/icons-material/Home';
import {useAuth} from "../../utils/auth";
import LoginIcon from "@mui/icons-material/Login";

function TopNavXS() {
    const navigate = useNavigate();
    const {loading, isAuthenticated, userManager: {signinRedirect}} = useAuth();
    return (
        <AppBar position="relative">
            <Toolbar variant={"dense"}>
                <Grid container justifyContent={"space-between"} alignContent={"stretch"} alignItems={"center"}>
                    <Grid item>
                        <TopNavPopupMenu edge={"start"}/>
                    </Grid>
                    <Grid item>
                        <Stack direction={"row"}>
                            <TopNavMenuItem title={""} icon={<HomeIcon/>} onClick={() => navigate("/")}
                                            color={"primary.contrastText"}/>
                            {
                                isAuthenticated ? <TopNavUserMenu/> :
                                    <TopNavMenuItem title={"Sign In"} onClick={signinRedirect} color={"primary.contrastText"}/>
                            }
                        </Stack>
                    </Grid>
                </Grid>
            </Toolbar>
        </AppBar>
    );
}

export default React.memo(TopNavXS);
