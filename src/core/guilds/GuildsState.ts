import {GuildDetail, GuildSummary} from "../../domain/models";

export type GuildsProviderState = "UNINITIALIZED" | "LOADING" | "READY" | "ERROR";
export interface GuildsState {
    state: GuildsProviderState;
    guilds: GuildSummary[];
    currentGuild: GuildDetail | null;
}
