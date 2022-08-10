import {GuildsContext} from "../contracts";
import {Inject, Injectable, OnInit} from "@angular/core";
import {GuildsAccess} from "../../data";
import {GuildDetail, UserGuildSummary} from "../../models";
import {BehaviorSubject, Observable, tap} from "rxjs";

@Injectable()
export class GuildsContextService implements GuildsContext, OnInit {
  private _activeGuild: BehaviorSubject<GuildDetail | null> = new BehaviorSubject<GuildDetail | null>(null);
  private _contextReady: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  private _guildList: BehaviorSubject<UserGuildSummary[]> = new BehaviorSubject<UserGuildSummary[]>([]);

  public activeGuild: Observable<GuildDetail | null> = this._activeGuild.asObservable();
  public contextReady: Observable<boolean> = this._contextReady.asObservable();
  public guildList: Observable<UserGuildSummary[]> = this._guildList.asObservable();

  constructor(@Inject(GuildsAccess) private readonly guildsAccess: GuildsAccess) {
  }


  public selectGuild(guildId: number): Observable<GuildDetail> {
    return this.guildsAccess.selectGuild(guildId)
      .pipe(tap(detail => {
        this._activeGuild.next(detail);
        const guildList = this._guildList.value;
        for (const userGuildSummary of guildList) {
          userGuildSummary.active = userGuildSummary.id === detail.id;
        }
        this._guildList.next(guildList);
      }));
  }

  ngOnInit(): void {
    this.guildsAccess.getGuildList()
      .subscribe(guilds => this._guildList.next(guilds));
    this._contextReady.next(true);
  }
}
