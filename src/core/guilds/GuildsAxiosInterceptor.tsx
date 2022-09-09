import React, {useEffect} from "react";
import axios, {AxiosRequestConfig} from "axios";
import {useCurrentGuild} from "./useGuilds";

function GuildsAxiosInterceptor() {
    const currentGuild = useCurrentGuild();
    useEffect(() => {
        const interceptor = axios.interceptors.request.use(SetAxiosHeader);
        return () => axios.interceptors.request.eject(interceptor);
    }, []);

    async function SetAxiosHeader(config: AxiosRequestConfig) {
        if(currentGuild == null || !config.headers){
            return;
        }
        config.headers["guildId"] = currentGuild.id;
    }

    return null;
}

export default React.memo(GuildsAxiosInterceptor);