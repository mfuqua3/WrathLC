import axios, {AxiosError} from "axios";

export function isAxiosError(payload: unknown): payload is AxiosError {
    return axios.isAxiosError(payload);
}
