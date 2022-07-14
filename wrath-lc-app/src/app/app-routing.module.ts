import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {CallbackComponent, LoginComponent} from "./utils";

const routes: Routes = [
  {path: "login", component: LoginComponent},
  {path: "signin-oidc", component: CallbackComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
