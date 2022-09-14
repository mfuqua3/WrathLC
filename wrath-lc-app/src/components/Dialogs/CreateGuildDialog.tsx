import React from "react"
import {useServers} from "../../core/servers";
import {useGuilds} from "../../core/guilds";
import ModalFormLayout from "../Layouts/ModalFormLayout";
import {CreateGuild} from "../../domain/requests";
import {useModal} from "../../utils/modal";
import {Stack} from "@mui/material";
import FormikSelect from "../Formik/FormikSelect";
import FormikTextField from "../Formik/FormikTextField";

function CreateGuildDialog() {
    const {allServers, loading} = useServers();
    const {actions} = useGuilds();
    const {hideModal} = useModal();
    const eligibleServers = allServers.filter(x => x.guildId === null);
    const initialValue: CreateGuild = {
        serverId: eligibleServers.length > 0 ? eligibleServers[0].id : 0,
        name: ""
    }

    async function handleSubmit(request: CreateGuild) {
        await actions.createGuild(request);
        hideModal();
    }

    return (
        <ModalFormLayout initialValues={initialValue} onSubmit={handleSubmit}
                         title={"Create a new Guild"} loading={loading}>
            <Stack spacing={2}>
                <FormikSelect label={"Link an eligible Discord Server"}
                              name={"serverId"}
                              items={eligibleServers.map(x => ({content: x.name, value: x.id}))}
                              fullWidth/>
                <FormikTextField label={"Choose a name for your Guild"}
                                 name={"name"} type={"text"}
                                 helperText={"Will default to server name if left blank."}/>
            </Stack>
        </ModalFormLayout>
    )
}

export default React.memo(CreateGuildDialog);