import React, {ReactNode} from "react";
import ViewListIcon from '@mui/icons-material/ViewList';
import EventIcon from '@mui/icons-material/Event';
import EmojiEventsIcon from '@mui/icons-material/EmojiEvents';
import PeopleIcon from '@mui/icons-material/People';
import SettingsIcon from '@mui/icons-material/Settings';

export interface SettingsItem {
    title: string;
    icon: ReactNode;
    navigate?: string;
}

export const GuildSettings: SettingsItem[] = [
    {title: "Your Characters", icon: <PeopleIcon/>, navigate: "user/characters"},
    {title: "Your Wishlist", icon: <ViewListIcon/>, navigate: "user/wishlists"},
    {title: "Your Raids", icon: <EventIcon/>},
    {title: "Your Loot History", icon: <EmojiEventsIcon/>},
]
export const UserSettings: SettingsItem[] = [
    {title: "Account Settings", icon: <SettingsIcon/>}
]