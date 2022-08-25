import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import Button from "@mui/material/Button";
import TopNavUserMenu from "./TopNav.UserMenu";
import { useNavigate } from "react-router-dom";
import { Stack } from "@mui/material";
import {TopNavMenuItem} from "./TopNav.MenuItem";
import HomeIcon from "@mui/icons-material/Home";

function TopNavLg() {
    const navigate = useNavigate();
    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="relative">
                <Toolbar>
                    <Stack direction={"row"} spacing={5}>
                        <TopNavMenuItem color={"primary.contrastText"} title={"Wrath LC"}  onClick={() => navigate("/")}/>
                        <TopNavMenuItem color={"primary.contrastText"} title={"Area 1"}   onClick={() => navigate("area1")}/>
                        <TopNavMenuItem color={"primary.contrastText"} title={"Area 2"}  onClick={() => navigate("area2")}/>
                    </Stack>
                    <Box display={"flex"} flexDirection={"row"} justifyContent={"end"} width={"100%"}>
                        <TopNavUserMenu />
                    </Box>
                </Toolbar>
            </AppBar>
        </Box>
    );
}

export default React.memo(TopNavLg);
