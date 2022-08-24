import {GuildsAccess} from "../contracts";
import {Inject, Injectable} from "@angular/core";
import {flatMap, Observable, switchMap, tap} from "rxjs";
import {CreateGuildRequest, GuildDetail, GuildSummary} from "../../models";
import {HttpClient} from "@angular/common/http";
import {API_URL} from "../data.module";

@Injectable({
  providedIn: 'root'
})
export class GuildsAccessService implements GuildsAccess {
  private activeGuildKey = "guild-id";

  constructor(private readonly http: HttpClient, @Inject(API_URL) private readonly apiUrl: string) {
  }

  getGuildList(): Observable<GuildSummary[]> {
    return this.http.get<GuildSummary[]>(`${this.apiUrl}/guilds`)
  }

  selectGuild(guildId: number): Observable<GuildDetail> {
    return this.getGuild(guildId).pipe(tap(() =>
      localStorage.setItem(this.activeGuildKey, guildId.toString())));
  }

  getGuild(guildId: number): Observable<GuildDetail> {
    return this.http.get<GuildDetail>(`${this.apiUrl}/guilds/${guildId}`);
  }

  // createGuild(request: CreateGuildRequest): Observable<GuildDetail>{
  //   return this.http.post(`${this.apiUrl}/guilds`,request).pipe(switchMap((resp)=>{
  //     return this.http.get<GuildDetail>(resp.)
  //   }))
  // }
}
