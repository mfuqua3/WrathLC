import React from "react";
import AuthWrapper from "../UtilityWrappers/AuthWrapper";
import AccessDenied from "../Errors/AccessDenied";
import {Outlet} from "react-router-dom";

function PrivateRoute() {
    return (
        <AuthWrapper fallback={<AccessDenied />}>
            <Outlet />
        </AuthWrapper>
    )
}

export default React.memo(PrivateRoute);