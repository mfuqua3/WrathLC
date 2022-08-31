import React from "react"
import {Box, Button, Divider, Paper, Stack, Typography} from "@mui/material";
import {useModal} from "../../utils/modal";
import CreateGuildDialog from "./CreateGuildDialog";

function NoGuilds() {
    const {showModal} = useModal("medium");
    return (
        <Box width={"100%"} height={"100%"} sx={(theme) => ({
            background: theme.palette.primary.light
        })} padding={3}>
            <Paper sx={{height: "100%"}}>
                <Stack spacing={2} padding={2} marginLeft={5} display={"flex"} direction={"column"}>
                    <Typography variant={"h2"}>
                        Welcome to WrathLC!
                    </Typography>
                    <Typography variant={"h5"}>
                        A full featured solution for your WoW Classic guild management.
                    </Typography>
                    <Divider />
                    <Typography variant={"h5"}>
                        Getting started is easy!
                    </Typography>
                    <Typography variant={"h6"}>
                        Wrath LC integrates with Discord.
                    </Typography>
                    <Typography variant={"h6"}>
                        Simply join or create a guild by connecting with one of your existing servers.
                    </Typography>
                    <Divider />
                    <Button variant={"contained"} onClick={()=>showModal(<CreateGuildDialog />)}>Create a new Guild</Button>
                    <Divider />
                    <Button variant={"contained"}>Join an existing Guild</Button>
                </Stack>
            </Paper>
        </Box>
    )
}

export default React.memo(NoGuilds);