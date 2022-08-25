import React from "react";
import {AppBar, Grid, Stack, Toolbar} from "@mui/material";
import "./TopNav.css";
import TopNavPopupMenu from "./TopNav.PopupMenu";
import TopNavUserMenu from "./TopNav.UserMenu";
import {useNavigate} from "react-router-dom";
import {TopNavMenuItem} from "./TopNav.MenuItem";
import HomeIcon from '@mui/icons-material/Home';

function TopNavXS() {
    const navigate = useNavigate();
    return (
        <AppBar position="relative">
            <Toolbar>
                <Grid container justifyContent={"space-between"} alignContent={"stretch"} alignItems={"center"}>
                    <Grid item>
                        <TopNavPopupMenu edge={"start"}/>
                    </Grid>
                    <Grid item>
                        <Stack direction={"row"} spacing={1}>
                            <TopNavMenuItem title={""} icon={<HomeIcon/>} onClick={() => navigate("/")}/>
                            <TopNavUserMenu/>
                        </Stack>
                    </Grid>
                </Grid>
            </Toolbar>
        </AppBar>
    );
}

export default React.memo(TopNavXS);
