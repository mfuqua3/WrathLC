import { createTheme } from "@mui/material";

export const defaultTheme = createTheme({
    palette: {
        background: {
            default: "#ffffff",
        },
        primary: {
            main: "#001970",
            light: "#44409f",
            dark: "#000044",
            contrastText: "#FFFFFF",
        },
        secondary: {
            main: "#e3f2fd",
            light: "#ffffff",
            dark: "#b1bfca",
            contrastText: "#000000",
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
