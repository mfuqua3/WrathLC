import React from "react";
import AuthWrapper from "../UtilityWrappers/AuthWrapper";
import AccessDenied from "../Errors/AccessDenied";
import {Outlet} from "react-router-dom";
import {useAuth} from "../../utils/auth";
import {SignIn} from "../Onboarding";

function PrivateRoute() {
    const {userManager} = useAuth();
    return (
        <AuthWrapper fallback={<SignIn/>}>
            <Outlet/>
        </AuthWrapper>
    )
}

export default React.memo(PrivateRoute);