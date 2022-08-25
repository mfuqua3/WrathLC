import React, { ReactNode } from "react";
import { Badge, BadgeProps, ListItemIcon, ListItemText, MenuItem, Typography } from "@mui/material";

export interface AuthMenuItemProps {
    title: string;
    icon: ReactNode;
    badge?: BadgeProps;

    onClick(): void | Promise<void>;
}

export function TopNavMenuItem(props: AuthMenuItemProps) {
    return (
        <>
            <MenuItem onClick={props.onClick}>
                <ListItemIcon>
                    {props.badge ? (
                        <Badge {...props.badge}>
                            <Typography>{props.icon}</Typography>
                        </Badge>
                    ) : (
                        props.icon
                    )}
                </ListItemIcon>
                <ListItemText>{props.title}</ListItemText>
            </MenuItem>
        </>
    );
}

export default React.memo(TopNavMenuItem);
