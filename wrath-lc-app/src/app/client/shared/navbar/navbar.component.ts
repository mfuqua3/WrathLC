import {Component, Inject, OnInit} from '@angular/core';
import {GuildsContext} from "../../../core";
import {Observable} from "rxjs";
import {GuildDetail} from "../../../models";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  activeGuild: Observable<GuildDetail | null>;

  constructor(
    @Inject(GuildsContext) private readonly guildContext: GuildsContext
  ) {
    this.activeGuild = guildContext.activeGuild;
  }

}
