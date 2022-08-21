import {GuildsAccess} from "../contracts";
import {Injectable} from "@angular/core";
import {Observable, of} from "rxjs";
import {GuildDetail, GuildSummary, UserGuildSummary} from "../../models";

@Injectable({
  providedIn: 'root'
})
export class GuildsAccessService implements GuildsAccess {
  private fakeGuildList: UserGuildSummary[] =  [
    {name: "Buzz", id: 1, active: true},
    {name: "Banana Shaped Gamers", id: 2, active: false},
    {name: "God and Anime", id: 3, active: false}
  ];

  constructor() {
  }

  getGuildList(): Observable<UserGuildSummary[]> {
    return of(this.fakeGuildList);
  }

  selectGuild(guildId: number): Observable<GuildDetail> {
    const guild = this.fakeGuildList.find(x=>x.id === guildId);
    if(!guild){
      throw Error("Bad ID");
    }
    guild.active = true;
    return of(guild);
  }

  getGuild(guildId: number): Observable<GuildDetail> {
    const guild = this.fakeGuildList.find(x=>x.id === guildId);
    if(!guild){
      throw Error("Bad ID");
    }
    return of(guild);
  }
}
