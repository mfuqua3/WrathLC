import {useAuth} from "../../utils/auth";
import React, {useEffect} from "react";
import {Box, CircularProgress, Typography} from "@mui/material";

function SignIn() {
    const {userManager} = useAuth();
    useEffect(() => {
        userManager.signinRedirect();
    }, [])

    return (
        <Box display={"flex"} alignItems={"center"} justifyContent={"center"} flexDirection={"column"}
             height={"100%"} width={"100%"}>
            <Typography>Redirecting to login...</Typography>
            <CircularProgress size="4rem"/>
        </Box>
    );
}

export default React.memo(SignIn);