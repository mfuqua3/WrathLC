import React from "react";
import {createRoot} from 'react-dom/client';
import {BrowserRouter} from "react-router-dom";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import * as serviceWorkerRegistration from "./serviceWorkerRegistration";
import {CssBaseline, ThemeProvider} from "@mui/material";
import {defaultTheme} from "./themes/defaultTheme";
import AdapterMoment from "@date-io/moment";
import {SnackbarProvider} from "./utils/snackbar";
import ModalProvider from "./utils/modal/ModalProvider";
import {LocalizationProvider} from "@mui/x-date-pickers";

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");
// eslint-disable-next-line @typescript-eslint/no-non-null-assertion
const root = createRoot(rootElement!);
root.render(
    <React.StrictMode>
        <LocalizationProvider dateAdapter={AdapterMoment}>
            <ThemeProvider theme={defaultTheme}>
                <CssBaseline/>
                <BrowserRouter basename={baseUrl ?? undefined}>
                    <SnackbarProvider>
                        <ModalProvider>
                            <App/>
                        </ModalProvider>
                    </SnackbarProvider>
                </BrowserRouter>
            </ThemeProvider>
        </LocalizationProvider>
    </React.StrictMode>
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://cra.link/PWA
serviceWorkerRegistration.unregister();
// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
