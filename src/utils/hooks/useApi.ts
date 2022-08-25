import { useSnackbar } from "../snackbar";
import { isAxiosError } from "../guards/isAxiosError";
import { isApiError } from "../guards/isApiError";

export interface ProvidedErrorMessagingMethods {
    invoke: <T>(p: Promise<T>, success?: string) => Promise<T>;
}

export const useApi = (): ProvidedErrorMessagingMethods => {
    const showMessage = useSnackbar();
    const invoke = <T>(promise: Promise<T>, success?: string) => {
        return promise
            .then((result: T) => {
                if (success !== null && success !== undefined) {
                    showMessage({
                        position: "BottomCenter",
                        type: "Success",
                        message: `${success}`,
                    });
                }
                return result;
            })
            .catch((error) => {
                let message: string;
                if (isAxiosError(error)) {
                    if (error.response?.data && isApiError(error.response?.data)) {
                        message = error.response.data.message;
                    } else {
                        message = error.message;
                    }
                } else {
                    message = "An unknown error has occurred.";
                }
                showMessage({
                    position: "BottomCenter",
                    type: "Error",
                    message: message,
                });
                throw error;
            });
    };

    return { invoke };
};
