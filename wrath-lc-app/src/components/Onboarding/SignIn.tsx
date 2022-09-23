import {useAuth} from "../../utils/auth";
import React, {useEffect, useState} from "react";
import {Box, CircularProgress, Typography} from "@mui/material";
import ErrorOutlineIcon from '@mui/icons-material/ErrorOutline';
import {useSnackbar} from "../../utils/snackbar";

function SignIn() {
    const {userManager} = useAuth();
    const [error, setError] = useState(false);
    const showMessage = useSnackbar();
    useEffect(() => {
        userManager.signinRedirect()
            .catch(err => {
                setError(true);
                showMessage({
                    type: "Error",
                    message: err.toString(),
                    position: "BottomCenter"
                });
            });
    }, [])

    return (
        <Box display={"flex"} alignItems={"center"} justifyContent={"center"} flexDirection={"column"}
             height={"100%"} width={"100%"}>
            {
                error &&
                <ErrorOutlineIcon fontSize={"large"} />

            }
            {
                !error ?
                    <Typography marginBottom={1}>Redirecting to login...</Typography> :
                    <Typography marginBottom={1}>Connection Error. Try again later.</Typography>
            }
            {
                !error &&
                <CircularProgress size="4rem"/>
            }
        </Box>
    );
}

export default React.memo(SignIn);