import {Observable} from "rxjs";
import {GuildDetail, GuildSummary} from "../../models";

export interface GuildsContext {
  contextReady: Observable<boolean>;
  activeGuild: Observable<GuildDetail | null>;
  guildList: Observable<GuildSummary[]>;

  selectGuild(guildId: number): Observable<GuildDetail>;
}

export const GuildsContext: unique symbol = Symbol.for("GuildsContext");
