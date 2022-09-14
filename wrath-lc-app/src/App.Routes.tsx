import React from "react";
import {Navigate, Outlet, Route, Routes} from "react-router-dom";
import MainLayout from "./components/Layouts/MainLayout";
import NotFound from "./components/Errors/NotFound";
import Area1Routes from "./areas/Area1-Example/Area1.Routes";
import Area2Routes from "./areas/Area2-Example/Area2.Routes";
import SignInCallback from "./components/Oidc/SignInCallback";
import {Dashboard} from "./areas/Dashboard";
import PrivateRoute from "./components/Routes/PrivateRoute";
import UserCharactersProvider from "./core/characters/UserCharactersProvider";
import UserRoutes from "./areas/User/User.Routes";

export const WrathLcRoutes = {
    dashboard: "dashboard",
    raids: "raids",
    admin: "admin",
    user: "user"
}

function AppRoutes() {
    return (
        <Routes>
            <Route element={<MainLayout/>}>
                <Route path={"/signin-oidc/*"} element={<SignInCallback/>}/>
                <Route path={"/"}>
                    <Route index element={<Navigate to={"/dashboard"}/>}/>
                </Route>
                <Route element={<PrivateRoute/>}>
                    <Route element={<UserCharactersProvider><Outlet/></UserCharactersProvider>}>
                        <Route path={WrathLcRoutes.dashboard} element={<Dashboard/>}/>
                        <Route path={`${WrathLcRoutes.raids}/*`} element={<Area1Routes/>}/>
                        <Route path={`${WrathLcRoutes.admin}/*`} element={<Area2Routes/>}/>
                        <Route path={`${WrathLcRoutes.user}/*`} element={<UserRoutes/>}/>
                    </Route>
                </Route>
                <Route path={"*"} element={<NotFound/>}/>
            </Route>
        </Routes>
    );
}

export default React.memo(AppRoutes);
