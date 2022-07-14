import {Component} from '@angular/core';
import AuthService from "../../../utils/auth/auth.service";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  constructor(
    private readonly authService: AuthService) {
  }

  ngOnInit(): void {
  }

  signout() {
    this.authService.logout();
  }
}
