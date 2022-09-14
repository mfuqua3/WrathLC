import React, {ReactNode} from "react";
import {Box} from "@mui/material";
export interface WowheadTooltipProps {
    domain: string;
    itemId: number;
}
function WowheadTooltip({children, ...props}: WowheadTooltipProps & {children: ReactNode}) {
    return (
        <Box display={"contents"} component={"a"} data-wowhead={`item=${props.itemId}&domain=${props.domain}`}>
            {children}
        </Box>
    )
}

export default React.memo(WowheadTooltip);

