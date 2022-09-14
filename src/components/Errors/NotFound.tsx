import React from "react";
import ErrorOutlineIcon from "@mui/icons-material/ErrorOutline";
import {Box, Button, Typography} from "@mui/material";
import {useNavigate} from "react-router-dom";

function NotFound() {
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
            <ErrorOutlineIcon color={"primary"} sx={{fontSize: 50}}/>
            <Typography variant={"h4"} marginTop={3}>
                Not Found
            </Typography>
            <Typography variant={"h5"} marginTop={3} maxWidth={"70%"} align={"center"}>
                The page you are looking for does not exist.
            </Typography>
            <Button variant={"contained"} onClick={() => navigate("/")}>
                Return Home
            </Button>
        </Box>
    );
}

export default React.memo(NotFound);
