import {DiscordServer} from "../domain/models";
import axios from "axios";

interface ServersApi {
    getDiscordServers(): Promise<DiscordServer[]>;
}

class ServersAccess implements ServersApi {
    private apiRoot = process.env.REACT_APP_API_ROOT + "/servers";

    async getDiscordServers(): Promise<DiscordServer[]> {
        const resp = await axios.get<DiscordServer[]>(this.apiRoot);
        return resp.data;
    }
}

export default new ServersAccess() as ServersApi;