import React from "react";
import AuthProvider from "./utils/auth/AuthProvider";
import useOidcEnvironmentConfiguration from "./utils/hooks/useOidcEnvironmentConfiguration";
import AppRoutes from "./App.Routes";
import GuildsProvider from "./core/guilds/GuildsProvider";
import ServersProvider from "./core/servers/ServersProvider";
import ModalRoot from "./utils/modal/ModalRoot";
import SnackbarRoot from "./utils/snackbar/SnackbarRoot";
import DrawerRoot from "./utils/drawer/DrawerRoot";

function App() {
    const oidcEnvironmentConfig = useOidcEnvironmentConfiguration();
    return (
        <AuthProvider {...oidcEnvironmentConfig} scope={"openid profile api"} loadUserInfo>
            <ServersProvider>
                <GuildsProvider>
                    <>
                        <AppRoutes/>
                        <DrawerRoot />
                        <SnackbarRoot />
                        <ModalRoot />
                    </>
                </GuildsProvider>
            </ServersProvider>
        </AuthProvider>
    );
}

export default App;
