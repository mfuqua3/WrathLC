import React, {ReactNode} from "react";
import {Button, ButtonProps, IconButton, Tooltip} from "@mui/material";
import ResponsiveContainer from "../ResponsiveContainer/ResponsiveContainer";

interface IconButtonProps {
    icon: ReactNode;
    iconPosition?: "start" | "end"
    label: string;

}

export type ResponsiveIconButtonProps = Omit<ButtonProps, "startIcon" | "endIcon" | "children"> & IconButtonProps

function ResponsiveIconButton({icon, iconPosition, label, ...buttonProps}: ResponsiveIconButtonProps) {
    const position = iconPosition ?? "start";
    return <ResponsiveContainer lower={
        <Tooltip title={label}>
            <IconButton {...buttonProps}>
                {icon}
            </IconButton>
        </Tooltip>}
                                upper={
                                    <Button startIcon={position === "start" && icon}
                                            endIcon={position === "end" && icon}
                                            {...buttonProps}>
                                        {label}
                                    </Button>}/>
}

export default React.memo(ResponsiveIconButton);