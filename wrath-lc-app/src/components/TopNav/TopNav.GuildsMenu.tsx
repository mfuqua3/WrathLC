import React from "react";
import {useGuilds} from "../../core/guilds";
import {useModal} from "../../utils/modal";
import {Divider, Menu} from "@mui/material";
import {TopNavMenuItem} from "./TopNav.MenuItem";
import AddIcon from '@mui/icons-material/Add';
import BuildIcon from '@mui/icons-material/Build';
import KeyboardArrowRightIcon from '@mui/icons-material/KeyboardArrowRight';
import FiberManualRecordIcon from '@mui/icons-material/FiberManualRecord';
import {useMenu} from "../../utils/menu";
import {CreateGuildDialog, JoinGuildDialog} from "../Dialogs";
import {GuildSummary} from "../../domain/models";

function TopNavGuildsMenu() {
    const {open, close, isOpen, anchorEl} = useMenu();
    const {state: {guilds, currentGuild}, actions: {selectGuild}} = useGuilds();
    const {showModal} = useModal("medium");
    const menuTitle = currentGuild ? `<${currentGuild.name}>` : "My Guilds";

    async function trySelectGuild(guild: GuildSummary) {
        close();
        if (currentGuild?.id === guild.id)
            return;
        await selectGuild({guildId: guild.id});
    }

    return (
        <>
            <TopNavMenuItem title={menuTitle}
                            onClick={(e) => open(e.currentTarget)}/>
            <Menu
                id="menu-appbar"
                anchorEl={anchorEl}
                anchorOrigin={{
                    vertical: "bottom",
                    horizontal: "center",
                }}
                keepMounted
                transformOrigin={{
                    vertical: "top",
                    horizontal: "right",
                }}
                open={isOpen}
                onClose={close}
            >
                {
                    guilds.length &&
                    guilds.sort(x => x.id === currentGuild?.id ? 1 : 0).map(guild =>
                        <TopNavMenuItem key={guild.id} title={guild.name}
                                        onClick={() => trySelectGuild(guild)}
                                        icon={guild.id === currentGuild?.id ?
                                            <FiberManualRecordIcon/> :
                                            <KeyboardArrowRightIcon/>}
                                        textVariant={"inherit"}/>)
                }
                <Divider/>
                <TopNavMenuItem title={"Join a Guild"} icon={<AddIcon/>}
                                onClick={() => {
                                    close();
                                    showModal(<JoinGuildDialog/>)
                                }}
                                textVariant={"inherit"}/>
                <Divider/>
                <TopNavMenuItem title={"Create a Guild"} icon={<BuildIcon/>}
                                onClick={() => {
                                    close();
                                    showModal(<CreateGuildDialog/>)
                                }} textVariant={"inherit"}/>
            </Menu>
        </>
    )
}

export default React.memo(TopNavGuildsMenu);