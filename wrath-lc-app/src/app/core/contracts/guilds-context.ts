import {Observable} from "rxjs";
import {GuildDetail, UserGuildSummary} from "../../models";

export interface GuildsContext {
  contextReady: Observable<boolean>;
  activeGuild: Observable<GuildDetail | null>;
  guildList: Observable<UserGuildSummary[]>;

  selectGuild(guildId: number): Observable<GuildDetail>;
}

export const GuildsContext: unique symbol = Symbol.for("GuildsContext");
