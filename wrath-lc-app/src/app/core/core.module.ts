import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {GuildsContext} from "./contracts";
import {GuildsContextService} from "./components";


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    {
      provide: GuildsContext,
      useClass: GuildsContextService
    }
  ]
})
export class CoreModule { }
