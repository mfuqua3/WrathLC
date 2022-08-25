import React, { useEffect } from "react";
import axios from "axios";
import { useAuth } from "./useAuth";

function AxiosConfig() {
    const { userManager } = useAuth();
    useEffect(() => {
        userManager.getUser().then((user) => {
            if (user) {
                axios.defaults.headers.common = { Authorization: `Bearer ${user.access_token}` };
            }
        });
        userManager.events.addUserLoaded(SetAxiosHeader);
        return () => {
            userManager.events.removeUserLoaded(SetAxiosHeader);
        };
    }, []);

    async function SetAxiosHeader() {
        const user = await userManager.getUser();
        if (user) {
            axios.defaults.headers.common = { Authorization: `Bearer ${user.access_token}` };
        }
    }

    return null;
}

export default React.memo(AxiosConfig);
