import {GuildsContext} from "../contracts";
import {Inject, Injectable, OnInit} from "@angular/core";
import {GuildDetail, GuildSummary} from "../../models";
import {BehaviorSubject, Observable, tap} from "rxjs";
import {GuildsAccess} from "../../data";

@Injectable()
export class GuildsContextService implements GuildsContext {
  private _activeGuild: BehaviorSubject<GuildDetail | null> = new BehaviorSubject<GuildDetail | null>(null);
  private _contextReady: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  private _guildList: BehaviorSubject<GuildSummary[]> = new BehaviorSubject<GuildSummary[]>([]);

  public activeGuild: Observable<GuildDetail | null> = this._activeGuild.asObservable();
  public contextReady: Observable<boolean> = this._contextReady.asObservable();
  public guildList: Observable<GuildSummary[]> = this._guildList.asObservable();

  constructor(@Inject(GuildsAccess) private readonly guildsAccess: GuildsAccess) {
    this.onInit();
  }


  public selectGuild(guildId: number): Observable<GuildDetail> {
    return this.guildsAccess.selectGuild(guildId)
      .pipe(tap(detail => {
        this._activeGuild.next(detail);
        const guildList = this._guildList.value;
        // for (const userGuildSummary of guildList) {
        //   userGuildSummary.active = userGuildSummary.id === detail.id;
        // }
        this._guildList.next(guildList);
      }));
  }

  onInit(): void {
    this.guildsAccess.getGuildList()
      .subscribe(guilds => {
          this._guildList.next(guilds);
        }
      );
    this._contextReady.next(false);
  }
}
