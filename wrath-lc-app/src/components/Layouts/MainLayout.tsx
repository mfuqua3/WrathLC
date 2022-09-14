import React from "react";
import {Stack} from "@mui/material";
import MenuProvider from "../../utils/menu/MenuProvider";
import ResponsiveContainer from "../ResponsiveContainer/ResponsiveContainer";
import TopNavXS from "../TopNav/TopNav.XS";
import TopNavLg from "../TopNav/TopNav.Lg";
import ScrollWrapper from "../UtilityWrappers/ScrollWrapper";
import {Outlet} from "react-router-dom";
import {useGuilds} from "../../core/guilds";
import LoadingWrapper from "../UtilityWrappers/LoadingWrapper";

function MainLayout() {
    const {state} = useGuilds();
    return (
        <Stack height={"100vh"}>
            <MenuProvider>
                <ResponsiveContainer lower={<TopNavXS/>} upper={<TopNavLg/>}/>
            </MenuProvider>
            <ScrollWrapper>
                <LoadingWrapper loading={state.state === "LOADING"}>
                    <Outlet/>
                </LoadingWrapper>
            </ScrollWrapper>
        </Stack>
    );
}

export default React.memo(MainLayout);
