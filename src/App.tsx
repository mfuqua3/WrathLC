import React from "react";
import AuthProvider from "./utils/auth/AuthProvider";
import useOidcEnvironmentConfiguration from "./utils/hooks/useOidcEnvironmentConfiguration";
import AppRoutes from "./App.Routes";

function App() {
    const oidcEnvironmentConfig = useOidcEnvironmentConfiguration();
    return (
        <AuthProvider {...oidcEnvironmentConfig} scope={"openid profile api"} loadUserInfo>
            <AppRoutes />
        </AuthProvider>
    );
}

export default App;
