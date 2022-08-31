import React, {ReactNode} from "react";
import {Badge, BadgeProps, ListItemIcon, ListItemText, MenuItem, Typography} from "@mui/material";

export interface AuthMenuItemProps {
    title: string;
    icon?: ReactNode;
    badge?: BadgeProps;
    iconPositioning?: "start" | "end";
    color?: string;
    onClick(): void | Promise<void>;
}

export function TopNavMenuItem(props: AuthMenuItemProps) {
    return (
        <>
            <MenuItem onClick={props.onClick}>
                {(props?.iconPositioning === "end") &&
                    <ListItemText>
                        <Typography marginRight={1} color={props.color}  variant={"h6"}>
                            {props.title}
                        </Typography>
                    </ListItemText>}
                {props.icon &&
                <ListItemIcon>
                    {props.badge ? (
                        <Badge {...props.badge}>
                            <Typography color={props.color}>{props.icon}</Typography>
                        </Badge>
                    ) : (
                        <Typography color={props.color}>
                            {props.icon}
                        </Typography>
                    )}
                </ListItemIcon>}
                {(!props.iconPositioning || props.iconPositioning === "start") &&
                    <ListItemText>
                        <Typography color={props.color} variant={"h6"}>
                            {props.title}
                        </Typography>
                    </ListItemText>}
            </MenuItem>
        </>
    );
}

export default React.memo(TopNavMenuItem);
