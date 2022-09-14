import React, {useEffect} from "react";
import axios, {AxiosRequestConfig} from "axios";
import {useCurrentGuild} from "./useGuilds";

function GuildsAxiosInterceptor() {
    const currentGuild = useCurrentGuild();
    useEffect(() => {
        const interceptor = axios.interceptors.request.use(SetAxiosHeader);
        return () => axios.interceptors.request.eject(interceptor);
    }, [currentGuild]);

    async function SetAxiosHeader(config: AxiosRequestConfig) {
        if (!currentGuild) {
            return config;
        }
        config.headers = {...config.headers, guildId: currentGuild.id};
        return config;
    }

    return null;
}

export default React.memo(GuildsAxiosInterceptor);