import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {SharedModule} from "./shared/shared.module";
import {DashboardModule} from "./dashboard/dashboard.module";
import {ClientRoutingModule} from "./client-routing.module";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SharedModule,
    DashboardModule,
    ClientRoutingModule,
    BrowserAnimationsModule
  ]
})
export class ClientModule { }
