import React from "react";
import {
    Box,
    Divider,
    List,
    ListItem,
    ListItemButton,
    ListItemIcon,
    ListItemText,
    MenuItem,
    Select,
    Typography
} from "@mui/material";
import {useAuth} from "../../utils/auth";
import AuthWrapper from "../UtilityWrappers/AuthWrapper";
import {useGuilds} from "../../core/guilds";
import {GuildSettings, SettingsItem, UserSettings} from "../../utils/shared";
import LogoutIcon from '@mui/icons-material/Logout';
import AddIcon from '@mui/icons-material/Add';
import BuildIcon from '@mui/icons-material/Build';
import {useModal} from "../../utils/modal";
import {CreateGuildDialog, JoinGuildDialog} from "../Dialogs";
import {useNavigate} from "react-router-dom";

function SettingsDrawer() {
    const {user, userManager} = useAuth();
    const {state: {guilds, currentGuild}, actions} = useGuilds();
    const {showModal} = useModal("medium");
    const navigate = useNavigate();

    function handleSettingItemClicked(setting: SettingsItem) {
        if (!setting.navigate) {
            return;
        }
        navigate(setting.navigate);
    }

    return (
        <AuthWrapper>
            <List>
                <ListItem>
                    <ListItemText>
                        <Box display={"flex"} flexDirection={"row"}>
                            <Typography>Signed in as&nbsp;</Typography>
                            <Typography fontWeight={"bold"}>{user?.profile.name}</Typography>
                        </Box>
                    </ListItemText>
                </ListItem>
            </List>
            <Divider/>
            <List>
                <ListItem disablePadding>
                    <Select value={currentGuild?.id} displayEmpty fullWidth
                            sx={{m: 1}} disabled={guilds.length <= 1}
                            onChange={e => actions.selectGuild({guildId: +e.target.value})}>
                        {guilds.map(guild =>
                            <MenuItem key={guild.id} value={guild.id}>{guild.name}</MenuItem>)}
                    </Select>
                </ListItem>
            </List>
            <Divider/>
            {
                currentGuild &&
                <>
                    <List>
                        {GuildSettings.map(setting =>
                            <ListItem key={setting.title} disablePadding>
                                <ListItemButton
                                    onClick={() => handleSettingItemClicked(setting)}>
                                    <ListItemIcon>
                                        {setting.icon}
                                    </ListItemIcon>
                                    <ListItemText primary={setting.title}/>
                                </ListItemButton>
                            </ListItem>)}
                    </List>
                    <Divider/>
                </>
            }
            <List>
                {UserSettings.map(setting =>
                    <ListItem key={setting.title} disablePadding>
                        <ListItemButton
                            onClick={() => handleSettingItemClicked(setting)}>
                            <ListItemIcon>
                                {setting.icon}
                            </ListItemIcon>
                            <ListItemText primary={setting.title}/>
                        </ListItemButton>
                    </ListItem>)}
            </List>
            <Divider/>
            <List>

                <ListItem disablePadding>
                    <ListItemButton onClick={() => showModal(<JoinGuildDialog/>)}>
                        <ListItemIcon>
                            {<AddIcon/>}
                        </ListItemIcon>
                        <ListItemText primary={"Join a Guild"}/>
                    </ListItemButton>
                </ListItem>
                <ListItem disablePadding>
                    <ListItemButton onClick={() => showModal(<CreateGuildDialog/>)}>
                        <ListItemIcon>
                            {<BuildIcon/>}
                        </ListItemIcon>
                        <ListItemText primary={"Create a Guild"}/>
                    </ListItemButton>
                </ListItem>
                <Divider/>
            </List>
            <List>
                <ListItem disablePadding>
                    <ListItemButton onClick={() => userManager.signoutRedirect()}>
                        <ListItemIcon>
                            <LogoutIcon/>
                        </ListItemIcon>
                        <ListItemText primary={"Sign Out"}/>
                    </ListItemButton>
                </ListItem>
            </List>
        </AuthWrapper>
    );
}

export default React.memo(SettingsDrawer);