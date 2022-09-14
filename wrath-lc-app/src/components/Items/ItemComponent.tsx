import React from "react";
import "./items.css";
import {ItemSummary} from "../../domain/models";
import {Box} from "@mui/material";

export interface ItemComponent {
    item: ItemSummary;
}

function ItemComponent({item}: ItemComponent) {
    return (
        <Box component={"div"} className={`${item.quality.toLowerCase()}`}>
            <Box component={"div"} className={"cell loot-box"}>
                <img src={`https://wow.zamimg.com/images/wow/icons/large/${item.iconName}.jpg`} alt={"?"}/>
            </Box>
            <Box className={"cell loot-summary"}>
                <Box component={"span"}>{item.name}</Box>
            </Box>
        </Box>
    )
}

export default React.memo(ItemComponent);