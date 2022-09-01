import React from "react";
import {Box, Divider, IconButton, ListItemText, Menu, MenuItem, Typography} from "@mui/material";
import AccountCircleIcon from "@mui/icons-material/AccountCircle";
import {useMenu} from "../../utils/menu";
import {useAuth} from "../../utils/auth";
import AuthWrapper from "../UtilityWrappers/AuthWrapper";
import {useCurrentGuild} from "../../core/guilds";
import {TopNavMenuItem} from "./TopNav.MenuItem";
import LogoutIcon from '@mui/icons-material/Logout';
import {GuildSettings, UserSettings} from "../../utils/shared";

function TopNavUserMenu(props: { dense?: boolean }) {
    const {open, close, isOpen, anchorEl} = useMenu();
    const {
        user,
        userManager,
    } = useAuth();
    const currentGuild = useCurrentGuild();

    async function signout() {
        await userManager.signoutRedirect();
    }

    return (
        <>
            <MenuItem
                onClick={(e) => {
                    open(e.currentTarget);
                }}>{!props.dense &&
                <ListItemText>
                    <Typography marginRight={1} color={"primary.contrastText"} variant={"h6"}>
                        {user?.profile.name}
                    </Typography>
                </ListItemText>}
                <IconButton
                    color={"inherit"}
                    aria-label={"menu"}
                >
                    <AccountCircleIcon className={"menu-icon"}/>
                </IconButton>
            </MenuItem>
            <Menu
                id="menu-appbar"
                anchorEl={anchorEl}
                anchorOrigin={{
                    vertical: "bottom",
                    horizontal: "center",
                }}
                keepMounted
                transformOrigin={{
                    vertical: "top",
                    horizontal: "right",
                }}
                open={isOpen}
                onClose={close}
            >
                <AuthWrapper>
                    <MenuItem>
                        <ListItemText>
                            <Box display={"flex"} flexDirection={"row"}>
                                <Typography>Signed in as&nbsp;</Typography>
                                <Typography fontWeight={"bold"}>{user?.profile.name}</Typography>
                            </Box>
                        </ListItemText>
                    </MenuItem>
                    {
                        currentGuild &&
                        <MenuItem>
                            <ListItemText>
                                <Box display={"flex"} flexDirection={"row"}>
                                    <Typography>{`${currentGuild.name} - Member`}</Typography>
                                </Box>
                            </ListItemText>
                        </MenuItem>

                    }
                    <Divider/>
                    {
                        currentGuild &&
                        <>
                            {
                                GuildSettings.map(setting =>
                                    <TopNavMenuItem key={setting.title} {...setting} textVariant={"inherit"}/>)
                            }
                            <Divider/>
                        </>
                    }
                    {
                        UserSettings.map(setting =>
                            <TopNavMenuItem key={setting.title} {...setting} textVariant={"inherit"}/>)
                    }
                    <Divider/>
                    <TopNavMenuItem title={"Sign Out"} icon={<LogoutIcon/>}
                                    textVariant={"inherit"} onClick={signout}/>
                </AuthWrapper>
            </Menu>
        </>
    );
}

export default React.memo(TopNavUserMenu);
