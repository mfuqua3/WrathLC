import React from "react";
import {useServers} from "../../core/servers";
import {useGuilds} from "../../core/guilds";
import {useModal} from "../../utils/modal";
import {JoinGuild} from "../../domain/requests";
import ModalFormLayout from "../Layouts/ModalFormLayout";
import {Stack} from "@mui/material";
import FormikSelect from "../Formik/FormikSelect";

function JoinGuildDialog() {
    const {joinableServers, loading} = useServers();
    const {actions} = useGuilds();
    const {hideModal} = useModal();
    const initialValue: JoinGuild = {
        // eslint-disable-next-line @typescript-eslint/no-non-null-assertion
        guildId: joinableServers.length > 0 ? joinableServers[0].guildId! : 0
    }

    async function handleSubmit(request: JoinGuild) {
        await actions.joinGuild(request);
        hideModal();
    }

    return (
        <ModalFormLayout initialValues={initialValue} onSubmit={handleSubmit}
                         title={"Join an Existing Guild"} loading={loading}>
            <Stack spacing={2}>
                <FormikSelect label={"Select a Guild to join"}
                              name={"serverId"}
                              disabled={joinableServers.length === 0}
                    // eslint-disable-next-line @typescript-eslint/no-non-null-assertion
                              items={joinableServers.map(x => ({value: x.guildId!, content: x.name}))}
                              fullWidth/>
            </Stack>
        </ModalFormLayout>
    )

}

export default React.memo(JoinGuildDialog);