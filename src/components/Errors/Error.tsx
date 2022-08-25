import React from "react";
import { Box, Button, Typography } from "@mui/material";
import ErrorOutlineIcon from "@mui/icons-material/ErrorOutline";
import { useNavigate } from "react-router-dom";

function Error() {
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
                An Error Has Occurred
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

export default React.memo(Error);
