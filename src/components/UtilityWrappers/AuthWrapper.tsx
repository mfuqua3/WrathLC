import React, {ReactNode} from "react";
import {useAuth} from "../../utils/auth";
import {WrapperProps} from "./WrapperProps";

export interface AuthWrapperProps extends WrapperProps {
    fallback?: ReactNode;

}

function AuthWrapper({children, fallback}: AuthWrapperProps) {
    const {isAuthenticated} = useAuth();
    return <>{isAuthenticated ? children : (fallback ?? null)}</>;
}

export default React.memo(AuthWrapper);
