import {GuildDetail, GuildSummary} from "../domain/models";
import {CreateGuild} from "../domain/requests";
import axios from "axios";

interface GuildsApi {
    getGuilds(): Promise<GuildSummary[]>;

    getGuild(guildId: number): Promise<GuildDetail>;

    createGuild(request: CreateGuild): Promise<GuildDetail>;

    joinGuild(guildId: number): Promise<void>;
}

class GuildsAccess implements GuildsApi {
    private apiRoot = process.env.REACT_APP_API_ROOT + "/guilds";

    async createGuild(request: CreateGuild): Promise<GuildDetail> {
        const resp = await axios.post<GuildDetail>(this.apiRoot, request);
        return resp.data;
    }

    async getGuild(guildId: number): Promise<GuildDetail> {
        const resp = await axios.get<GuildDetail>(`${this.apiRoot}/${guildId}`);
        return resp.data;
    }

    async getGuilds(): Promise<GuildSummary[]> {
        const resp = await axios.get<GuildSummary[]>(`${this.apiRoot}`);
        return resp.data;
    }

    async joinGuild(guildId: number): Promise<void> {
        await axios.post(`${this.apiRoot}/${guildId}/user`);
    }
}

export default new GuildsAccess() as GuildsApi;