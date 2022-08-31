import React, {useEffect} from "react";
import {NavigationDrawerListItem, NavigationDrawerProps} from "./NavigationDrawerProps";
import {useDrawer} from "../../utils/drawer";
import {List, ListItem, ListItemButton, ListItemText} from "@mui/material";

function NavigationDrawer({header, items, open, onClose}: NavigationDrawerProps) {
    const drawer = useDrawer({
        header,
        content: <NavigationDrawerContent items={items}/>
    })
    useEffect(() => {
        open ? drawer.open() : drawer.close();
    }, [open])
    useEffect(() => {
        if (!drawer.isOpen) {
            onClose();
        }
    }, [drawer.isOpen])
    return null;
}

function NavigationDrawerContent({items}: { items: NavigationDrawerListItem[] }) {
    return (
        <List>
            {items.map((item, idx) => (
                <ListItem key={`drawer-item-${idx}`} disablePadding>
                    <ListItemButton sx={{textAlign: 'center'}} onClick={item.onClick}>
                        <ListItemText primary={item.text}/>
                    </ListItemButton>
                </ListItem>
            ))}
        </List>
    )
}

export default React.memo(NavigationDrawer);