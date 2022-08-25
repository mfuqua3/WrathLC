import React from "react";
import { IconButton, Menu } from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import { useNavigate } from "react-router-dom";
import QuestionMarkIcon from "@mui/icons-material/QuestionMark";
import { TopNavMenuItem } from "./TopNav.MenuItem";
import { useMenu } from "../../utils/menu";

export interface TopNavPopupMenuProps {
    edge?: false | "start" | "end" | undefined;
}

function TopNavPopupMenu({ edge }: TopNavPopupMenuProps) {
    const { open, close, isOpen, anchorEl } = useMenu();
    const navigate = useNavigate();

    function handleClick(target: string) {
        close();
        navigate(target);
    }

    return (
        <>
            <IconButton
                edge={edge}
                color={"inherit"}
                aria-label={"menu"}
                onClick={(e) => {
                    open(e.currentTarget);
                }}
            >
                <MenuIcon className={"menu-icon"} />
            </IconButton>
            <Menu
                id="menu-appbar"
                anchorEl={anchorEl}
                anchorOrigin={{
                    vertical: "top",
                    horizontal: "right",
                }}
                keepMounted
                transformOrigin={{
                    vertical: "top",
                    horizontal: "right",
                }}
                open={isOpen}
                onClose={close}
            >
                <TopNavMenuItem onClick={() => handleClick("area1")} icon={<QuestionMarkIcon />} title={"Area1"} />
                <TopNavMenuItem onClick={() => handleClick("area2")} icon={<QuestionMarkIcon />} title={"Area2"} />
            </Menu>
        </>
    );
}

export default React.memo(TopNavPopupMenu);
