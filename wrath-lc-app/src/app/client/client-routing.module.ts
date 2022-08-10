import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';;
import {DashboardComponent} from "./dashboard/dashboard.component";
import {MainLayoutComponent} from "./shared/main-layout.component";
import {AuthorizeGuard} from "../utils/auth";

const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    canActivate: [AuthorizeGuard],
    children: [
      {path: '', pathMatch: "full", redirectTo: 'dashboard'},
      {path: 'dashboard', component: DashboardComponent}
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientRoutingModule {
}
