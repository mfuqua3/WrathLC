import React from "react";
import {Route, Routes} from "react-router-dom";
import MainLayout from "./components/Layouts/MainLayout";
import NotFound from "./components/Errors/NotFound";
import Area1Routes from "./areas/Area1-Example/Area1.Routes";
import Area2Routes from "./areas/Area2-Example/Area2.Routes";
import SignInCallback from "./components/Oidc/SignInCallback";

function AppRoutes() {
    return (
        <Routes>
            <Route element={<MainLayout/>}>
                <Route path={"/signin-oidc/*"} element={<SignInCallback/>}/>
                <Route path={"area1"} element={<Area1Routes/>}/>
                <Route path={"area2"} element={<Area2Routes/>}/>
                <Route path={"/"}>
                    <Route index element={<>Hello, World!</>}/>
                </Route>
                <Route path={"*"} element={<NotFound/>}/>
            </Route>
        </Routes>
    );
}

export default React.memo(AppRoutes);
