import {Component} from '@angular/core';
import AuthService from "../auth.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private readonly authService: AuthService) {
  }

  async login() {
    try {
      await this.authService.signInRedirect();
    } finally {
      console.log("sigin succeeded");
    }
  }

}
