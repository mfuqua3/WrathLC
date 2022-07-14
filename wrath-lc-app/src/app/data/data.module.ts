import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {GuildsAccess} from "./contracts";
import {GuildsAccessService} from "./components";



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    {
      provide: GuildsAccess,
      useClass: GuildsAccessService
    }
  ]
})
export class DataModule { }
