import {useSnackbar} from "../snackbar";
import {isApiError, isAxiosError} from "../guards";

export interface ProvidedErrorMessagingMethods<T> {
    invoke: <R>(action: (api: T) => Promise<R>, success?: string) => Promise<R>;
}

export function useApi<T>(api: T): ProvidedErrorMessagingMethods<T> {
    const showMessage = useSnackbar();
    const invoke = async <R>(action: (api: T) => Promise<R>, success?: string) => {
        try {
            const result = await action(api);
            if (success !== null && success !== undefined) {
                showMessage({
                    position: "BottomCenter",
                    type: "Success",
                    message: `${success}`,
                });
            }
            return result;
        }
        catch (error) {
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
        }
        // return action(api)
        //     .then((result: R) => {
        //         if (success !== null && success !== undefined) {
        //             showMessage({
        //                 position: "BottomCenter",
        //                 type: "Success",
        //                 message: `${success}`,
        //             });
        //         }
        //         return result;
        //     })
        //     .catch((error) => {
        //         debugger;
        //         let message: string;
        //         if (isAxiosError(error)) {
        //             if (error.response?.data && isApiError(error.response?.data)) {
        //                 message = error.response.data.message;
        //             } else {
        //                 message = error.message;
        //             }
        //         } else {
        //             message = "An unknown error has occurred.";
        //         }
        //         showMessage({
        //             position: "BottomCenter",
        //             type: "Error",
        //             message: message,
        //         });
        //         throw error;
        //     });
    };

    return {invoke};
}
