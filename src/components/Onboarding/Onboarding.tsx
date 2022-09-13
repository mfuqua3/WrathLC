import React from "react"
import {Box, Button, Divider, Paper, Stack, Typography} from "@mui/material";
import {useModal} from "../../utils/modal";
import {CreateGuildDialog, JoinGuildDialog} from "../Dialogs";
import ScrollWrapper from "../UtilityWrappers/ScrollWrapper";
import AuthWrapper from "../UtilityWrappers/AuthWrapper";
import {useAuth} from "../../utils/auth";

function Onboarding() {
    const {showModal} = useModal("medium");
    const {userManager} = useAuth();
    return (
        <Box width={"100%"} height={"100%"} sx={(theme) => ({
            background: theme.palette.secondary.dark
        })} padding={3} display={"flex"} alignItems={"center"} justifyContent={"center"}>
            <Paper sx={(theme) => ({height: "100%", maxWidth: "600px", background: theme.palette.secondary.light})}>
                <ScrollWrapper>
                    <Stack spacing={1} padding={2} margin={1} display={"flex"} direction={"column"}>
                        <Typography variant={"h2"}>
                            Welcome to WrathLC!
                        </Typography>
                        <Typography variant={"h5"}>
                            A full featured solution for your WoW Classic guild management.
                        </Typography>
                        <Divider/>
                        <Typography variant={"h5"}>
                            Getting started is easy!
                        </Typography>
                        <Typography variant={"h6"}>
                            Wrath LC integrates with Discord.
                        </Typography>
                        <Typography variant={"h6"}>
                            Simply join or create a guild by connecting with one of your existing servers.
                        </Typography>
                        <Divider/>
                        <AuthWrapper fallback={
                            <Typography variant={"h6"}>
                                <Button variant={"contained"} onClick={() => userManager.signinRedirect()}>
                                    Sign In to Access your Guilds
                                </Button>
                            </Typography>
                        }>
                            <>
                                <Button variant={"contained"} onClick={() => showModal(<CreateGuildDialog/>)}>Create a
                                    new
                                    Guild</Button>
                                <Divider/>
                                <Button variant={"contained"} onClick={() => showModal(<JoinGuildDialog/>)}>Join an
                                    Existing
                                    Guild</Button>
                            </>
                        </AuthWrapper>
                    </Stack>
                </ScrollWrapper>
            </Paper>
        </Box>
    )
}

export default React.memo(Onboarding);