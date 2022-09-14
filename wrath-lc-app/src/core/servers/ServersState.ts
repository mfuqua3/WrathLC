import {DiscordServer} from "../../domain/models";

export interface ServersState {
    loading: boolean;
    allServers: DiscordServer[];
    joinableServers: DiscordServer[];
}
