import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import TopNavUserMenu from "./TopNav.UserMenu";
import {useNavigate} from "react-router-dom";
import {Stack} from "@mui/material";
import {TopNavMenuItem} from "./TopNav.MenuItem";
import {useGuilds} from "../../core/guilds";
import AuthWrapper from "../UtilityWrappers/AuthWrapper";
import {useAuth} from "../../utils/auth";
import TopNavGuildsMenu from "./TopNav.GuildsMenu";

function TopNavLg() {
    const navigate = useNavigate();
    const {userManager} = useAuth();
    const {state: {guilds, currentGuild}} = useGuilds();
    return (
        <Box sx={{flexGrow: 1}}>
            <AppBar position="relative">
                <Toolbar>
                    <Stack direction={"row"} spacing={5}>
                        <TopNavMenuItem color={"primary.contrastText"} title={"Wrath LC"}
                                        onClick={() => navigate("/")}/>
                        <AuthWrapper>
                            <TopNavMenuItem color={"primary.contrastText"} title={"Raids"}
                                            onClick={() => navigate("area1")}/>
                            <TopNavMenuItem color={"primary.contrastText"} title={"Admin"}
                                            onClick={() => navigate("area2")}/>
                        </AuthWrapper>
                    </Stack>
                    <Box display={"flex"} flexDirection={"row"} justifyContent={"end"} width={"100%"}>
                        <AuthWrapper fallback={
                            <TopNavMenuItem title={"Sign In"} onClick={()=>userManager.signinRedirect()} />
                        }>
                            <TopNavGuildsMenu />
                            <TopNavUserMenu/>
                        </AuthWrapper>
                    </Box>
                </Toolbar>
            </AppBar>
        </Box>
    );
}

export default React.memo(TopNavLg);
