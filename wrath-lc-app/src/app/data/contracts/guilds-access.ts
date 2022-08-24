import {Observable} from "rxjs";
import {GuildDetail, GuildSummary} from "../../models";

export interface GuildsAccess {
  getGuildList(): Observable<GuildSummary[]>
  selectGuild(guildId: number): Observable<GuildDetail>
  getGuild(guildId: number): Observable<GuildDetail>
}
export const GuildsAccess: unique symbol = Symbol.for("GuildsAccess");
