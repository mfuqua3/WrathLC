import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';;
import {DashboardComponent} from "./dashboard/dashboard.component";
import {MainLayoutComponent} from "./shared/main-layout.component";
import {AuthorizeGuard} from "../utils";
import {RaidPlanningComponent} from "./raid-planning/raid-planning.component";

const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    canActivate: [AuthorizeGuard],
    children: [
      {path: '', pathMatch: "full", redirectTo: 'dashboard'},
      {path: 'dashboard', component: DashboardComponent},
      {path: 'planning', component: RaidPlanningComponent}
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientRoutingModule {
}
