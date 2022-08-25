import React from "react";
import {Stack} from "@mui/material";
import MenuProvider from "../../utils/menu/MenuProvider";
import ResponsiveContainer from "../ResponsiveContainer/ResponsiveContainer";
import TopNavXS from "../TopNav/TopNav.XS";
import TopNavLg from "../TopNav/TopNav.Lg";
import ScrollWrapper from "../UtilityWrappers/ScrollWrapper";
import {Outlet} from "react-router-dom";

function MainLayout() {
    return (
        <Stack height={"100vh"}>
            <MenuProvider>
                <ResponsiveContainer lower={<TopNavXS/>} upper={<TopNavLg/>}/>
            </MenuProvider>
            <ScrollWrapper>
                <Outlet/>
            </ScrollWrapper>
        </Stack>
    );
}

export default React.memo(MainLayout);
