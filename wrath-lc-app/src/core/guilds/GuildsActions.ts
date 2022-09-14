import {CreateGuild, JoinGuild, SelectGuild} from "../../domain/requests";
import {GuildDetail} from "../../domain/models";

export interface GuildsActions {
    createGuild(request: CreateGuild): Promise<GuildDetail>;

    joinGuild(request: JoinGuild): Promise<GuildDetail>;

    selectGuild(request: SelectGuild): Promise<GuildDetail>;
}