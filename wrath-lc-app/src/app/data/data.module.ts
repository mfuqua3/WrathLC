import {InjectionToken, NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';
import {GuildsAccess} from "./contracts";
import {GuildsAccessService} from "./components";
import {environment} from "../../environments/environment";


export const API_URL = new InjectionToken<string>('apiUrl');

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    {
      provide: GuildsAccess,
      useClass: GuildsAccessService
    },
    { provide: API_URL, useValue: environment.apiRoot}
  ]
})
export class DataModule { }
