import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import TopNavUserMenu from "./TopNav.UserMenu";
import {useNavigate} from "react-router-dom";
import {ListItemText, MenuItem, Stack, Typography} from "@mui/material";
import {TopNavMenuItem} from "./TopNav.MenuItem";
import {useAuth} from "../../utils/auth";

function TopNavLg() {
    const navigate = useNavigate();
    const {userManager} = useAuth();
    return (
        <Box sx={{flexGrow: 1}}>
            <AppBar position="relative">
                <Toolbar>
                    <Stack direction={"row"} spacing={5}>
                        <TopNavMenuItem color={"primary.contrastText"} title={"Wrath LC"}
                                        onClick={() => navigate("/")}/>
                        <TopNavMenuItem color={"primary.contrastText"} title={"Area 1"}
                                        onClick={() => navigate("area1")}/>
                        <TopNavMenuItem color={"primary.contrastText"} title={"Area 2"}
                                        onClick={() => navigate("area2")}/>
                    </Stack>
                    <Box display={"flex"} flexDirection={"row"} justifyContent={"end"} width={"100%"}>
                            <TopNavUserMenu/>
                    </Box>
                </Toolbar>
            </AppBar>
        </Box>
    );
}

export default React.memo(TopNavLg);
