import React from "react";
import {Box, Button, Stack, Typography} from "@mui/material";
import {useNavigate} from "react-router-dom";

function NoCharacters() {
    const navigate = useNavigate();
    return (
        <Box minHeight={"60%"} display={"flex"} alignItems={"center"} justifyContent={"center"}>
            <Stack spacing={2} alignItems={"center"} width={"inherit"}>
                <Typography variant={"h5"}>You have no characters in this guild!</Typography>
                <Button variant={"contained"} sx={{width: 250}} onClick={()=>navigate("/user/characters")}>Go Make One!</Button>
            </Stack>
        </Box>

    )
}

export default React.memo(NoCharacters);