import React, {useEffect, useState} from "react";
import axios, {AxiosError} from "axios";
import {useAuth} from "./useAuth";

function SilentRefresh() {
    const {userManager} = useAuth();
    const [refreshing, setRefreshing] = useState(false);
    useEffect(() => {
        userManager.events.addAccessTokenExpiring(TryRefreshToken);
        return () => {
            userManager.events.removeAccessTokenExpiring(TryRefreshToken);
        };
    }, []);
    useEffect(() => {
        const interceptorId = axios.interceptors.response.use(
            (response) => {
                return response;
            },
            (error: Error | AxiosError) => {
                if (axios.isAxiosError(error) && error.response?.status === 401) {
                    return TryRefreshToken()
                        .then(userManager.getUser)
                        .then((user) => {
                            if (user) {
                                const config = {
                                    ...error.config,
                                    headers: {
                                        ...error.config.headers,
                                        authorization: `Bearer ${user.access_token}`,
                                    },
                                };
                                return axios
                                    .request(config)
                                    .then((resp) => {
                                        return resp.data;
                                    })
                                    .catch(() => {
                                        return error;
                                    });
                            }
                            return error;
                        })
                        .catch(() => {
                            return error;
                        });
                }
                return error;
            },
        );
        return () => {
            axios.interceptors.response.eject(interceptorId);
        };
    }, []);

    async function RefreshToken() {
        await userManager.signinSilent();
    }

    async function TryRefreshToken() {
        if (refreshing) return;
        setRefreshing(true);
        try {
            await RefreshToken();
        } catch (e) {
            await userManager.signinRedirect();
        } finally {
            setRefreshing(false);
        }
    }

    return null;
}

export default React.memo(SilentRefresh);
