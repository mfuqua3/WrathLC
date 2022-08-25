import { createTheme } from "@mui/material";

export const defaultTheme = createTheme({
    palette: {
        background: {
            default: "#ffffff",
        },
        primary: {
            main: "#001970",
            light: "#303f9f",
            dark: "#020223",
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
        fontFamily: "Helvetica",
        body1: {
            fontWeight: 300,
            fontSize: "14px",
            lineHeight: "16px",
        },
    },
});
