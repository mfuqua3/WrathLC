import React, {ReactNode} from "react";
import {Badge, BadgeProps, ListItemIcon, ListItemText, MenuItem, Typography} from "@mui/material";
import {OverridableStringUnion} from "@mui/types";
import {Variant} from "@mui/material/styles/createTypography";
import {TypographyPropsVariantOverrides} from "@mui/material/Typography/Typography";

export interface AuthMenuItemProps {
    title: string;
    icon?: ReactNode;
    badge?: BadgeProps;
    iconPositioning?: "start" | "end";
    color?: string;
    textVariant?: OverridableStringUnion<Variant | 'inherit', TypographyPropsVariantOverrides>
    onClick?: (e: React.MouseEvent<HTMLLIElement, MouseEvent>) => (void | Promise<void>);
}

export function TopNavMenuItem(props: AuthMenuItemProps) {
    return (
        <>
            <MenuItem onClick={(e) => props.onClick?.call(e.currentTarget, e)}>
                {(props?.iconPositioning === "end") &&
                    <ListItemText>
                        <Typography marginRight={1} color={props.color} variant={props.textVariant ?? "h6"}>
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
                        <Typography color={props.color} variant={props.textVariant ?? "h6"}>
                            {props.title}
                        </Typography>
                    </ListItemText>}
            </MenuItem>
        </>
    );
}

export default React.memo(TopNavMenuItem);
