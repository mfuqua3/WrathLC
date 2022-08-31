import React from "react";
import {IconButton, ListItemText, Menu, MenuItem, Typography} from "@mui/material";
import LogoutIcon from "@mui/icons-material/Logout";
import LoginIcon from "@mui/icons-material/Login";
import PersonIcon from "@mui/icons-material/Person";
import AccountCircleIcon from "@mui/icons-material/AccountCircle";
import {useMenu} from "../../utils/menu";
import {useAuth} from "../../utils/auth";
import AuthWrapper from "../UtilityWrappers/AuthWrapper";
import {TopNavMenuItem} from "./TopNav.MenuItem";

function TopNavUserMenu(props: { dense?: boolean }) {
    const {open, close, isOpen, anchorEl} = useMenu();
    const {
        user,
        loading,
        userManager,
    } = useAuth();

    async function signin() {
        await userManager.signinRedirect();
    }

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
                    vertical: "top",
                    horizontal: "right",
                }}
                keepMounted
                transformOrigin={{
                    vertical: "top",
                    horizontal: "right",
                }}
                open={isOpen}
                onClose={close}
            >
                {user && (
                    <TopNavMenuItem title={"User Settings"} onClick={() => console.log("user settings")} icon={
                        <PersonIcon/>}/>
                )}
                <AuthWrapper>
                    <TopNavMenuItem onClick={signout} icon={<LogoutIcon/>} title={"Sign Out"}/>
                </AuthWrapper>
                {!user && !loading && (
                    <TopNavMenuItem onClick={signin} icon={<LoginIcon/>} title={"Sign In"}/>
                )}
            </Menu>
        </>
    );
}

export default React.memo(TopNavUserMenu);
