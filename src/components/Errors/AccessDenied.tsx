import React from "react";
import ErrorOutlineIcon from "@mui/icons-material/ErrorOutline";
import { Box, Button, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";

function AccessDenied() {
    const navigate = useNavigate();
    return (
        <Box
            display={"flex"}
            width={"100%"}
            flexDirection={"column"}
            height={"100%"}
            alignItems={"center"}
            justifyContent={"center"}
        >
            <ErrorOutlineIcon color={"primary"} sx={{ fontSize: 50 }} />
            <Typography variant={"h4"} marginTop={3}>
                Access Denied
            </Typography>
            <Typography variant={"h5"} marginTop={3} maxWidth={"70%"} align={"center"}>
                Please try refreshing the page, or check back later if the problem persists.
            </Typography>
            <Button variant={"contained"} onClick={() => navigate("/")}>
                Return Home
            </Button>
        </Box>
    );
}

export default React.memo(AccessDenied);
