import React, {ReactNode} from "react";
import {useAuth} from "../../utils/auth";
import {WrapperProps} from "./WrapperProps";
import LoadingWrapper from "./LoadingWrapper";
import {Box} from "@mui/material";

export interface AuthWrapperProps extends WrapperProps {
    fallback?: ReactNode;

}

function AuthWrapper({children, fallback}: AuthWrapperProps) {
    const {loading, isAuthenticated} = useAuth();
    return <>{loading ? <LoadingWrapper loading><Box width={"100%"} height={"100%"}/></LoadingWrapper> :
        (isAuthenticated ? children : (fallback ?? null))}</>;
}

export default React.memo(AuthWrapper);
