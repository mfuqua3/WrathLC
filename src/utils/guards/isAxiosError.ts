import axios, { AxiosError } from "axios";

export function isAxiosError(payload: Error): payload is AxiosError {
    return axios.isAxiosError(payload);
}
