import React, {useEffect} from "react";
import axios, {AxiosRequestConfig} from "axios";
import {useAuth} from "./useAuth";

function AxiosConfig() {
    const {user} = useAuth();
    useEffect(() => {
        const interceptor = axios.interceptors.request.use(SetAxiosHeader);
        return () => axios.interceptors.request.eject(interceptor);
    }, [user, user?.access_token]);

    async function SetAxiosHeader(config: AxiosRequestConfig) {
        if (!user || !user.access_token) {
            return config;
        }
        config.headers = {...config.headers, authorization: `Bearer ${user.access_token}`};
        return config;
    }

    return null;
}

export default React.memo(AxiosConfig);
