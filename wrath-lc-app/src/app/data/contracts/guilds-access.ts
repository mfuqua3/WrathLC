import {Observable} from "rxjs";
import {GuildDetail, UserGuildSummary} from "../../models";

export interface GuildsAccess {
  getGuildList(): Observable<UserGuildSummary[]>
  selectGuild(guildId: number): Observable<GuildDetail>
  getGuild(guildId: number): Observable<GuildDetail>
}
export const GuildsAccess: unique symbol = Symbol.for("GuildsAccess");
