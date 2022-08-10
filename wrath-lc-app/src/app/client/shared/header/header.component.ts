import {Component, Inject} from '@angular/core';
import AuthService from "../../../utils/auth/auth.service";
import {GuildsContext} from "../../../core";
import {Observable} from "rxjs";
import {GuildSummary} from "../../../models";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  guildList: Observable<GuildSummary[]>;

  constructor(
    private readonly authService: AuthService,
    @Inject(GuildsContext) private readonly guildService: GuildsContext) {
    this.guildList = guildService.guildList;
  }

  ngOnInit(): void {
  }

  signout() {
    this.authService.logout();
  }
}
