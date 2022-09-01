import React, {ReactNode} from "react";
import {List, ListItem, ListItemButton, ListItemIcon, ListItemText} from "@mui/material";
import HomeIcon from '@mui/icons-material/Home';
import {useNavigate} from "react-router-dom";
import {useDrawer} from "../../utils/drawer";

interface DrawerItem {
    icon: ReactNode;
    title: string;
    navigate: string;
}

function NavigationDrawer() {
    const navigate = useNavigate();
    const {close} = useDrawer();
    const items: DrawerItem[] = [
        {icon: <HomeIcon/>, title: "Home", navigate: "dashboard"}
    ]

    function handleClick(item: DrawerItem) {
        navigate(item.navigate);
        close();
    }

    return (
        <List>
            {items.map((item) =>
                <ListItem key={item.title} disablePadding>
                    <ListItemButton onClick={() => handleClick(item)}>
                        <ListItemIcon>
                            {item.icon}
                        </ListItemIcon>
                        <ListItemText primary={item.title}/>
                    </ListItemButton>
                </ListItem>)}
        </List>
    )
}


export default React.memo(NavigationDrawer);