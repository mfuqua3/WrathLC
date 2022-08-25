import { createTheme } from "@mui/material";

export const defaultTheme = createTheme({
    palette: {
        background: {
            default: "#ffffff",
        },
        primary: {
            main: "#3F51B5",
            light: "#C5CAE9",
            dark: "#303F9F",
            contrastText: "#FFFFFF",
        },
        secondary: {
            main: "#ffffff",
            light: "#ffffff",
            dark: "#ffffff",
            contrastText: "#FFFFFF",
        },
    },
    typography: {
        fontSize: 12,
        fontFamily: "Arial",
        body1: {
            fontWeight: 300,
            fontSize: "14px",
            lineHeight: "16px",
        },
    },
});
