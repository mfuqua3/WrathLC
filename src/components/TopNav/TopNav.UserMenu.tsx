import React from "react";
import { IconButton, ListItemIcon, ListItemText, Menu, MenuItem } from "@mui/material";
import LogoutIcon from "@mui/icons-material/Logout";
import LoginIcon from "@mui/icons-material/Login";
import PersonIcon from "@mui/icons-material/Person";
import AccountCircleIcon from "@mui/icons-material/AccountCircle";
import { useMenu } from "../../utils/menu";
import { useAuth } from "../../utils/auth";
import AuthWrapper from "../UtilityWrappers/AuthWrapper";
import { TopNavMenuItem } from "./TopNav.MenuItem";

function TopNavUserMenu() {
    const { open, close, isOpen, anchorEl } = useMenu();
    const {
        user,
        loading,
        userManager: { signoutRedirect, signinRedirect },
    } = useAuth();
    return (
        <>
            <IconButton
                color={"inherit"}
                aria-label={"menu"}
                onClick={(e) => {
                    open(e.currentTarget);
                }}
            >
                <AccountCircleIcon className={"menu-icon"} />
            </IconButton>
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
                    <MenuItem>
                        <ListItemIcon>
                            <PersonIcon />
                        </ListItemIcon>
                        <ListItemText>{user.profile.name}</ListItemText>
                    </MenuItem>
                )}
                <AuthWrapper>
                    <TopNavMenuItem onClick={signoutRedirect} icon={<LogoutIcon />} title={"Sign Out"} />
                </AuthWrapper>
                {!user && !loading && (
                    <TopNavMenuItem onClick={signinRedirect} icon={<LoginIcon />} title={"Sign In"} />
                )}
            </Menu>
        </>
    );
}

export default React.memo(TopNavUserMenu);
