import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from "./auth/login/login.component";
import {CallbackComponent} from "./auth/callback/callback.component";
import {DashboardComponent} from "./dashboard/dashboard.component";
import {AuthorizeGuard} from "./auth/authorize.guard";

const routes: Routes = [
  {path: 'dashboard', component: DashboardComponent, canActivate: [AuthorizeGuard]},
  {path: "login", component: LoginComponent},
  {path: "signin-oidc", component: CallbackComponent},
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
