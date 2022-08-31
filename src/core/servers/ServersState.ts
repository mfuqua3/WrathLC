import {DiscordServer, DiscordServerItem} from "../../domain/models";

export interface ServersState {
    loading: boolean;
    allServers: DiscordServer[];
    joinableServers: DiscordServerItem[];
}
