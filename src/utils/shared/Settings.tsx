import React, {ReactNode} from "react";
import ViewListIcon from '@mui/icons-material/ViewList';
import EventIcon from '@mui/icons-material/Event';
import EmojiEventsIcon from '@mui/icons-material/EmojiEvents';
import PeopleIcon from '@mui/icons-material/People';
import SettingsIcon from '@mui/icons-material/Settings';

export interface SettingsItem {
    title: string;
    icon: ReactNode;
    onClick?: ()=>(void | Promise<void>)
}
export const GuildSettings: SettingsItem[] = [
    {title: "Your Characters", icon: <PeopleIcon />},
    {title: "Your Wishlist", icon: <ViewListIcon />},
    {title: "Your Raids", icon: <EventIcon />},
    {title: "Your Loot History", icon: <EmojiEventsIcon />},
]
export const UserSettings: SettingsItem[] = [
    {title: "Account Settings", icon: <SettingsIcon />}
]