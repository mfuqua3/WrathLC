import {GuildsAccess} from "../contracts";
import {Injectable} from "@angular/core";
import {Observable, of} from "rxjs";
import {GuildDetail, GuildSummary} from "../../models";

@Injectable()
export class GuildsAccessService implements GuildsAccess {
  private fakeGuildList: GuildSummary[] =  [
    {name: "Buzz", id: 1},
    {name: "Banana Shaped Gamers", id: 2},
    {name: "God and Anime", id: 3}
  ];

  constructor() {
  }

  getGuildList(): Observable<GuildSummary[]> {
    return of(this.fakeGuildList);
  }

  selectGuild(guildId: number): Observable<GuildDetail> {
    const guild = this.fakeGuildList.find(x=>x.id === guildId);
    if(!guild){
      throw Error("Bad ID");
    }
    return of(guild);
  }
}
